using System;
using System.Threading;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;

namespace HyperionScreenCap
{
    public partial class Form1 : Form
    {
        #region Variables

        private static bool _initLock;
        private static DxScreenCapture _d;
        private static ProtoClient _protoClient;
        private static ApiServer _apiServer;

        public static NotifyIcon TrayIcon;
        public static bool _captureEnabled;

        public enum NotificationLevels
        {
            None,
            Info,
            Error
        }

        #endregion Variables

        public Form1()
        {
            InitializeComponent();

            #region TrayIcon

            // Add menu icons
            var trayMenuIcons = new ContextMenuStrip();
            trayMenuIcons.Items.Add("Change monitor index", Resources.television__pencil.ToBitmap(), onChangeMonitor);

            // Create a simple tray menu with only one item.

            for (int i = 0; i < DisplayMonitor.EnumerateMonitors().Length; i++)
            {
                ((ToolStripMenuItem) trayMenuIcons.Items[0]).DropDownItems.Add(string.Format("#{0}", i),
                    Resources.television__arrow.ToBitmap(), onChangeMonitor);
            }

            trayMenuIcons.Items.Add("Setup", Resources.gear.ToBitmap(), OnSetup);
            trayMenuIcons.Items.Add("Exit", Resources.cross.ToBitmap(), OnExit);

            TrayIcon = new NotifyIcon {Text = @"Hyperion Screen Capture (Not Connected) {}"};
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
            TrayIcon.Icon = Resources.Hyperion_disabled;

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenuStrip = trayMenuIcons;
            //TrayIcon.ContextMenu = trayMenu;

            TrayIcon.Visible = true;

            Settings.LoadSetttings();

            if (Settings.HyperionServerIp == "0.0.0.0")
            {
                MessageBox.Show(@"No configuration found, please setup in the next window.");
                SetupForm setupForm = new SetupForm();
                setupForm.Show();
            }
            else
            {
                Init();
            }

            #endregion TrayIcon
        }

        public static void Init(bool reInit = false)
        {
            if (!_initLock)
            {
                _initLock = true;

                // Stop current capture first on reinit
                if (reInit)
                {
                    _captureEnabled = false;
                    Thread.Sleep(500 + Settings.CaptureInterval);

                    if (_protoClient != null)
                    {
                        ProtoClient.Disconnect();
                        Thread.Sleep(500);
                    }
                }

                _d = new DxScreenCapture(Settings.MonitorIndex);

                _protoClient = new ProtoClient();
                ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort,
                    Settings.HyperionMessagePriority);

                if (Settings.CaptureOnStartup)
                {
                    if (ProtoClient.IsConnected())
                    {
                        Notifications.Info($"Connected to Hyperion server on {Settings.HyperionServerIp}!");
                        ToggleCapture("ON");
                    }
                }

                if (Settings.ApiEnabled)
                {
                    _apiServer = new ApiServer();
                    _apiServer.StartServer("localhost", Settings.ApiPort.ToString());
                }
                else if (_apiServer != null)
                {
                    _apiServer.StopServer();
                }

                _initLock = false;
            }
        }

      private static void TrayIcon_DoubleClick(object sender, EventArgs e)
      {
        ToggleCapture(_captureEnabled ? "OFF" : "ON");
      }

      public static void ToggleCapture(string command)
      {
        if (_captureEnabled && command == "OFF")
        {
        _captureEnabled = false;

        TrayIcon.Icon = Resources.Hyperion_disabled;
          TrayIcon.Text = @"Hyperion Screen Capture (Disabled)";
          ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
        }
        else if (!_captureEnabled && command == "ON")
        {
        _captureEnabled = true;

        TrayIcon.Icon = Resources.Hyperion_enabled;
          TrayIcon.Text = @"Hyperion Screen Capture (Enabled)";
          Thread.Sleep(50);
          var t = new Thread(StartCapture) {IsBackground = true};
          t.Start();
        }
      }

      private static void onChangeMonitor(object sender, EventArgs e)
        {
            MenuItem selectedMenuItem = sender as MenuItem;
            if (selectedMenuItem != null)
            {
                int newMonitorIndex;
                bool isValidInteger = int.TryParse(selectedMenuItem.Text.Replace("#", string.Empty), out newMonitorIndex);
                if (isValidInteger)
                {
                    Settings.MonitorIndex = newMonitorIndex;
                    Settings.SaveSettings();
                    Init(true);
                }
            }
        }

        private static void OnSetup(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }

        private static void OnExit(object sender, EventArgs e)
        {
            // Clear tray icon on close
            if (TrayIcon != null)
            {
                TrayIcon.Visible = false;
            }

            // On send clear priority
            if (_protoClient != null)
            {
                _captureEnabled = false;
                ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
                Thread.Sleep(50);
                ProtoClient.ClearPriority(Settings.HyperionMessagePriority);
                ProtoClient.Disconnect();
            }

            if(Settings.ApiEnabled)
                _apiServer.StopServer();

            Environment.Exit(0);
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        #region DXCapture

        private static void StartCapture()
        {
            try
            {
                while (_captureEnabled)
                {
                    if (!ProtoClient.IsConnected())
                    {
                        // Reconnect every 5s (default)
                        ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort,
                            Settings.HyperionMessagePriority);
                        Thread.Sleep(Settings.ReconnectInterval);
                        continue;
                    }

                    var s = _d.CaptureScreen(Settings.HyperionWidth, Settings.HyperionHeight);
                    var dr = s.LockRectangle(LockFlags.None);
                    var ds = dr.Data;
                    var x = RemoveAlpha(ds);

                    s.UnlockRectangle();
                    s.Dispose();
                    ds.Dispose();

                    ProtoClient.SendImageToServer(x);

                    // Add small delay to reduce cpu usage (200FPS max)
                    Thread.Sleep(Settings.CaptureInterval);
                }
            }
            catch (Exception ex)
            {
                _captureEnabled = false;
                Notifications.Error("Failed to take screenshot." + ex.Message);
            }
        }

        #endregion DXCapture

        private static byte[] RemoveAlpha(DataStream ia)
        {
            var newImage = new byte[(ia.Length*3/4)];
            int counter = 0;
            while (ia.Position < ia.Length)
            {
                var a = new byte[4];
                ia.Read(a, 0, 4);
                newImage[counter] = (a[2]);
                counter++;
                newImage[counter] = (a[1]);
                counter++;
                newImage[counter] = (a[0]);
                counter++;
            }
            return newImage;
        }
    }
}