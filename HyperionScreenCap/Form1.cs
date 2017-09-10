using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using HyperionScreenCap.Config;

namespace HyperionScreenCap
{
    public partial class Form1 : Form
    {
        #region Variables

        private static bool _initLock;
        private static DxScreenCapture _dxScreenCapture;
        private static ApiServer _apiServer;

        public static NotifyIcon TrayIcon;
        public static ContextMenuStrip TrayMenuIcons = new ContextMenuStrip();

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

            // Add menu icons
            TrayMenuIcons.Items.Add("Change monitor index", Resources.television__pencil.ToBitmap());
            TrayMenuIcons.Items.Add("Setup", Resources.gear.ToBitmap(), OnSetup);
            TrayMenuIcons.Items.Add("Exit", Resources.cross.ToBitmap(), OnExit);

            TrayIcon = new NotifyIcon {Text = AppConstants.TRAY_ICON_MSG_NOT_CONNECTED};
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
            TrayIcon.MouseClick += TrayIcon_Click;
            TrayIcon.Icon = Resources.Hyperion_disabled;
            TrayIconUpdateMonitorIndexes();

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenuStrip = TrayMenuIcons;
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

            // PowerModeChanged Handler
            SystemEvents.PowerModeChanged += PowerModeChanged;
        }

        private static void DisconnectProtoClient()
        {
            ProtoClient.Disconnect();
            Thread.Sleep(500);
            TrayIcon.Text = AppConstants.TRAY_ICON_MSG_NOT_CONNECTED;
        }

        public static void Init(bool reInit = false, bool forceOn = false)
        {
            if (!_initLock)
            {
                _initLock = true;

                // Stop current capture first on reinit
                if (reInit)
                {
                    _captureEnabled = false;
                    Thread.Sleep(500);

                    if (ProtoClient.Initialized)
                    {
                        DisconnectProtoClient();
                    }
                }

                ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort,
                    Settings.HyperionMessagePriority);

                if (Settings.CaptureOnStartup || forceOn)
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
                else
                {
                    _apiServer?.StopServer();
                }

                _initLock = false;
            }
        }
        private static void TrayIconUpdateMonitorIndexes()
        {
            int dropMenuCount = ((ToolStripMenuItem)TrayMenuIcons.Items[0]).DropDownItems.Count;

            if (dropMenuCount > 0)
            {
                int count = 0;
                while (count < dropMenuCount)
                {
                    try
                    {
                        ((ToolStripMenuItem) TrayMenuIcons.Items[0]).DropDownItems.RemoveAt(0);
                    }
                    catch (Exception) { }

                    count++; 
                }
            }

            for (int i = 0; i < DisplayMonitor.EnumerateMonitors().Length; i++)
            {
                ((ToolStripMenuItem)TrayMenuIcons.Items[0]).DropDownItems.Add($"#{i}",
                    Resources.television__arrow.ToBitmap(), OnChangeMonitor);
            }
        }

        private static void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            ToggleCapture(_captureEnabled ? "OFF" : "ON");
        }

        private static void TrayIcon_Click(object sender, EventArgs e)
        {
            TrayIconUpdateMonitorIndexes();
        }

        public static void ToggleCapture(string command)
        {
            if (_captureEnabled && command == "OFF")
            {
                _captureEnabled = false;

                TrayIcon.Icon = Resources.Hyperion_disabled;
                TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_DISABLED;
                ProtoClient.TryClearPriority(Settings.HyperionMessagePriority);
            }
            else if (!_captureEnabled && command == "ON")
            {
                _captureEnabled = true;

                TrayIcon.Icon = Resources.Hyperion_enabled;
                TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_ENABLED;
                var t = new Thread(StartCapture) {IsBackground = true};
                t.Start();
            }
        }

        private static void OnChangeMonitor(object sender, EventArgs e)
        {
            var selectedMenuItem = sender as ToolStripDropDownItem;
            if (selectedMenuItem != null)
            {
                int newMonitorIndex;
                var selectedItem = selectedMenuItem.Text.Replace("#", string.Empty);
                bool isValidInteger = int.TryParse(selectedItem, out newMonitorIndex);
                if (isValidInteger)
                {
                    Debug.WriteLine($"Selected new monitor index: {newMonitorIndex}");
                    Settings.MonitorIndex = newMonitorIndex;
                    Settings.SaveSettings();
                    Init(true, true);
                }
                else
                {
                    Debug.WriteLine($"Selected monitor index was invalid integer: {selectedItem}");
                }
            }
            else
            {
                Debug.WriteLine("OnChangeMonitor selected item was null");
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

            // Send clear priority
            if (ProtoClient.Initialized)
            {
                _captureEnabled = false;
                ProtoClient.TryClearPriority(Settings.HyperionMessagePriority);
                Thread.Sleep(50);
                ProtoClient.TryClearPriority(Settings.HyperionMessagePriority);
                DisconnectProtoClient();
            }

            if (Settings.ApiEnabled)
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
                _dxScreenCapture = new DxScreenCapture(Settings.MonitorIndex);
            }
            catch ( Exception ex )
            {
                Notifications.Error("Failed to initialize screen capture: " + ex.Message);
                ToggleCapture("OFF");
            }

            int captureAttempt = 1;
            while (_captureEnabled)
            {
                try
                {
                    if ( !ProtoClient.IsConnected() )
                    {
                        ProtoClient.Disconnect();
                        ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort, Settings.HyperionMessagePriority);
                    }

                    var s = _dxScreenCapture.CaptureScreen(Settings.HyperionWidth, Settings.HyperionHeight, _dxScreenCapture.MonitorIndex);
                    var dr = s.LockRectangle(LockFlags.None);
                    var ds = dr.Data;
                    var x = RemoveAlpha(ds);

                    s.UnlockRectangle();
                    s.Dispose();
                    ds.Dispose();

                    ProtoClient.SendImageToServer(x);

                    // Add small delay to reduce cpu usage (200FPS max)
                    Thread.Sleep(Settings.CaptureInterval);

                    // Reset attempt count
                    captureAttempt = 1;
                }
                catch ( Exception ex )
                {
                    if ( ++captureAttempt == AppConstants.MAX_CAPTURE_ATTEMPTS )
                    {
                        Notifications.Error("Error occured during capture: " + ex.Message);
                        ToggleCapture("OFF");
                    }
                    else
                    {
                        Thread.Sleep(AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS);
                    }
                }
            }

            _dxScreenCapture.Dispose();
            _dxScreenCapture = null;
        }

        private static byte[] RemoveAlpha(DataStream ia)
        {
            var newImage = new byte[(ia.Length * 3 / 4)];
            int counter = 0;
            while ( ia.Position < ia.Length )
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

        #endregion DXCapture

        #region PowerModeChanged Event

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs powerMode)
        {
            switch(powerMode.Mode)
            {
                case PowerModes.Resume:
                    // We try to disable capture on suspend but if capture is still enabled
                    // then restart after grace period
                    if ( _captureEnabled )
                    {
                        ToggleCapture("OFF");
                        Thread.Sleep(AppConstants.SYSTEM_RESUME_GRACE_MILLIS);
                        ToggleCapture("ON");
                    }
                    break;

                case PowerModes.Suspend:
                    ToggleCapture("OFF");
                    ProtoClient.Disconnect();
                    break;
            }
        }

        #endregion
    }
}