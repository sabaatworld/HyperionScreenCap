using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using HyperionScreenCap.Config;
using System.Drawing;

namespace HyperionScreenCap
{
    public partial class Form1 : Form
    {
        #region Variables

        private static bool _initLock;
        private static DX9ScreenCapture _dx9ScreenCapture;
        private static DX11ScreenCapture _dx11ScreenCapture;
        private static ApiServer _apiServer;

        public static NotifyIcon TrayIcon;
        public static ContextMenuStrip TrayMenuIcons = new ContextMenuStrip();

        private static bool _captureSuspended = false;
        private static bool _captureEnabled = false;
        private static Thread _captureThread;

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
            TrayMenuIcons.Items.Add("Change DX9 monitor index", Resources.television__pencil.ToBitmap());
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
            SystemEvents.SessionSwitch += SessionSwitched;
        }

        public static void Init(bool reInit = false, bool forceOn = false)
        {
            if (!_initLock)
            {
                _initLock = true;

                // Stop current capture first on reinit
                if (reInit)
                {
                    TerminateScreenCapture();
                    DisconnectProtoClient();
                }

                if (Settings.CaptureOnStartup || forceOn)
                {
                    ToggleCapture("ON");
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
            ToggleCapture(IsScreenCaptureRunning() ? "OFF" : "ON");
        }

        private static void TrayIcon_Click(object sender, EventArgs e)
        {
            TrayIconUpdateMonitorIndexes();
        }

        public static void ToggleCapture(string command)
        {
            if ( command == "OFF" )
            {
                TerminateScreenCapture();

                TrayIcon.Icon = Resources.Hyperion_disabled;
                TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_DISABLED;
                ProtoClient.TryClearPriority(Settings.HyperionMessagePriority);
                DisconnectProtoClient();
            }
            else if ( command == "ON" )
            {
                TrayIcon.Icon = Resources.Hyperion_enabled;
                TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_ENABLED;
                _captureEnabled = true;
                _captureThread = new Thread(TryStartCapture) { IsBackground = true };
                _captureThread.Start();
            }
        }

        private static void DisconnectProtoClient()
        {
            ProtoClient.Disconnect();
            Thread.Sleep(500);
            TrayIcon.Text = AppConstants.TRAY_ICON_MSG_NOT_CONNECTED;
        }

        public static bool IsScreenCaptureRunning()
        {
            return _captureThread != null && _captureThread.IsAlive && _captureEnabled;
        }

        private static void TerminateScreenCapture()
        {
            _captureEnabled = false;
            Thread.Sleep(Settings.CaptureInterval + AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS + 500);
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
                TerminateScreenCapture();
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

        private static void TryStartCapture()
        {
            try
            {
                StartCapture(SetupForm.CaptureMethod.DX9.ToString().Equals(Settings.CaptureMethod));
            }
            finally
            {
                _dx9ScreenCapture?.Dispose();
                _dx11ScreenCapture?.Dispose();
            }
        }

        private static void StartCapture(bool dx9Capture)
        {
            try
            {
                _dx9ScreenCapture = new DX9ScreenCapture(Settings.MonitorIndex);
                _dx11ScreenCapture = new DX11ScreenCapture(Settings.Dx11AdapterIndex, Settings.Dx11MonitorIndex, Settings.Dx11ImageScalingFactor);
            }
            catch ( Exception ex )
            {
                Notifications.Error("Failed to initialize screen capture: " + ex.Message);
                ToggleCapture("OFF");
            }

            // Use the following to figure out how much time each Hyperion update requires
            bool debugCaptureTime = false;
            Stopwatch stopwatch = new Stopwatch();

            int captureAttempt = 1;
            while ( _captureEnabled )
            {
                try
                {
                    if ( !ProtoClient.IsConnected() )
                    {
                        ProtoClient.Disconnect();
                        ProtoClient.Init(Settings.HyperionServerIp, Settings.HyperionServerPort, Settings.HyperionMessagePriority);
                        // Double checking since sometimes exceptions are not thrown on initialization
                        if ( ProtoClient.IsConnected() )
                            Notifications.Info($"Connected to Hyperion server on {Settings.HyperionServerIp}!");
                        else
                            throw new Exception($"Failed to connect to Hyperion server on {Settings.HyperionServerIp}!");
                    }

                    byte[] imageData;
                    int imageWidth, imageHeight;

                    if ( debugCaptureTime )
                        stopwatch.Start();

                    if ( dx9Capture )
                    {
                        var s = _dx9ScreenCapture.CaptureScreen(Settings.HyperionWidth, Settings.HyperionHeight, _dx9ScreenCapture.MonitorIndex);
                        var dr = s.LockRectangle(LockFlags.None);
                        var ds = dr.Data;
                        imageData = RemoveAlpha(ds);
                        s.UnlockRectangle();
                        s.Dispose();
                        ds.Dispose();
                        imageWidth = Settings.HyperionWidth;
                        imageHeight = Settings.HyperionHeight;
                    }
                    else
                    {
                        imageData = _dx11ScreenCapture.Capture();
                        imageWidth = _dx11ScreenCapture.CaptureWidth;
                        imageHeight = _dx11ScreenCapture.CaptureHeight;
                    }

                    // Uncomment the following to enable debugging
                    // MiscUtils.SaveRGBArrayToImageFile(imageData, imageWidth, imageHeight);

                    ProtoClient.SendImageToServer(imageData, imageWidth, imageHeight);

                    if ( debugCaptureTime )
                    {
                        stopwatch.Stop();
                        Debug.WriteLine("Hyperion update took: " + stopwatch.ElapsedMilliseconds);
                        stopwatch.Reset();
                    }

                    // Add small delay to reduce cpu usage (200FPS max)
                    if ( dx9Capture && Settings.CaptureInterval > 0 )
                        Thread.Sleep(Settings.CaptureInterval);

                    // Reset attempt count
                    captureAttempt = 1;
                }
                catch ( Exception ex )
                {
                    if ( ++captureAttempt == AppConstants.MAX_CAPTURE_ATTEMPTS )
                    {
                        _captureEnabled = false;
                        Notifications.Error("Error occured during capture: " + ex.Message);
                        ToggleCapture("OFF");
                    }
                    else
                    {
                        Thread.Sleep(AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS);
                    }
                }
            }
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

        #region PowerMode & SessionSwitch Events

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs powerMode)
        {
            switch(powerMode.Mode)
            {
                case PowerModes.Resume:
                    ResumeCapture();
                    break;

                case PowerModes.Suspend:
                    SuspendCapture();
                    break;
            }
        }

        private void SessionSwitched(object sender, SessionSwitchEventArgs switchEvent)
        {
            switch(switchEvent.Reason)
            {
                case SessionSwitchReason.SessionUnlock:
                    ResumeCapture();
                    break;

                case SessionSwitchReason.SessionLock:
                    SuspendCapture();
                    break;
            }
        }

        private void ResumeCapture()
        {
            if ( _captureSuspended )
            {
                _captureSuspended = false;
                Thread.Sleep(AppConstants.CAPTURE_RESUME_GRACE_MILLIS);
                ToggleCapture("ON");
            }
        }

        private void SuspendCapture()
        {
            if ( IsScreenCaptureRunning() )
            {
                _captureSuspended = true;
                ToggleCapture("OFF");
            }
        }

        #endregion
    }
}