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
using HyperionScreenCap.Model;
using HyperionScreenCap.Capture;
using HyperionScreenCap.Helper;
using System.Text;
using HyperionScreenCap.Model.GitHub;
using log4net;

namespace HyperionScreenCap
{
    public partial class MainForm : Form
    {
        #region Variables

        private static readonly ILog LOG = LogManager.GetLogger(typeof(MainForm));

        private static bool _initLock;
        private static IScreenCapture _screenCapture;
        private static ApiServer _apiServer;

        public static NotifyIcon TrayIcon;
        public static ContextMenuStrip TrayMenuIcons = new ContextMenuStrip();

        private static bool _captureSuspended = false;
        private static bool _captureEnabled = false;
        private static bool _captureToggleInProgress = false;
        private static Thread _captureThread;

        #endregion Variables

        public enum CaptureCommand
        {
            ON,
            OFF
        }

        public MainForm()
        {
            LOG.Info("Instantiating MainForm");
            InitializeComponent();
            SettingsManager.LoadSetttings();

            if ( SettingsManager.CheckUpdateOnStartup )
            {
                UpdateChecker.StartUpdateCheck(true);
            }

            // Add menu icons
            TrayMenuIcons.Items.Add("Change DX9 monitor index", Resources.television__pencil.ToBitmap());
            TrayMenuIcons.Items.Add("Setup", Resources.gear.ToBitmap(), OnSetup);
            TrayMenuIcons.Items.Add("Exit", Resources.cross.ToBitmap(), OnExit);

            TrayIcon = new NotifyIcon { Text = AppConstants.TRAY_ICON_MSG_NOT_CONNECTED };
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
            TrayIcon.MouseClick += TrayIcon_Click;
            TrayIcon.Icon = Resources.Hyperion_disabled;
            TrayIconUpdateMonitorIndexes();

            // Add menu to tray icon and show it.
            TrayIcon.ContextMenuStrip = TrayMenuIcons;
            //TrayIcon.ContextMenu = trayMenu;

            TrayIcon.Visible = true;

            if ( SettingsManager.HyperionServerIp == "0.0.0.0" )
            {
                LOG.Info("Saved settings not available. Prompting to configure app.");
                MessageBox.Show("No configuration found, please setup in the next window.");
                SetupForm setupForm = new SetupForm();
                setupForm.Show();
            }
            else
            {
                Init();
            }

            // Register various event handlers
            SystemEvents.PowerModeChanged += PowerModeChanged;
            SystemEvents.SessionSwitch += SessionSwitched;
            LOG.Info("MainForm Instantiated");
        }

        public static void Init(bool reInit = false, bool forceOn = false)
        {
            if ( !_initLock )
            {
                _initLock = true;
                LOG.Info("Initialization lock set");
                new Thread(() => ExecuteInitialization(reInit, forceOn)) { IsBackground = true }.Start();
            }
        }

        private static void ExecuteInitialization(bool reInit, bool forceOn)
        {
            LOG.Info($"Initialization requested with parameters reInit={reInit}, forceOn={forceOn}");
            // Stop current capture first on reinit
            if ( reInit )
            {
                TerminateScreenCapture();
                DisconnectProtoClient();
            }

            if ( SettingsManager.CaptureOnStartup || forceOn )
            {
                ToggleCapture(CaptureCommand.ON);
            }

            if ( SettingsManager.ApiEnabled )
            {
                _apiServer = new ApiServer();
                _apiServer.StartServer("localhost", SettingsManager.ApiPort.ToString());
            }
            else
            {
                _apiServer?.StopServer();
            }
            _initLock = false;
            LOG.Info("Initialization lock unset");
        }

        private static void TrayIconUpdateMonitorIndexes()
        {
            LOG.Info("Updating available monitors in tray icon");
            int dropMenuCount = ((ToolStripMenuItem) TrayMenuIcons.Items[0]).DropDownItems.Count;

            if ( dropMenuCount > 0 )
            {
                int count = 0;
                while ( count < dropMenuCount )
                {
                    try
                    {
                        ((ToolStripMenuItem) TrayMenuIcons.Items[0]).DropDownItems.RemoveAt(0);
                    }
                    catch ( Exception ) { }

                    count++;
                }
            }

            for ( int i = 0; i < DisplayMonitor.EnumerateMonitors().Length; i++ )
            {
                ((ToolStripMenuItem) TrayMenuIcons.Items[0]).DropDownItems.Add($"#{i}",
                    Resources.television__arrow.ToBitmap(), OnChangeMonitor);
            }
        }

        private static void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            LOG.Info("Tray icon double clicked");
            ToggleCapture(IsScreenCaptureRunning() ? CaptureCommand.OFF : CaptureCommand.ON);
        }

        private static void TrayIcon_Click(object sender, EventArgs e)
        {
            LOG.Info("Tray icon clicked");
            TrayIconUpdateMonitorIndexes();
        }

        public static void ToggleCapture(CaptureCommand command)
        {
            LOG.Info($"Processing toggle capture command: {command}");
            // Don't accept toggle commands until previous one completes
            if ( _captureToggleInProgress )
            {
                LOG.Info($"Toggle capture in progress. Ignoring command: {command}");
                return;
            }
            _captureToggleInProgress = true;
            LOG.Info("Toggle capture lock set");

            // Don't execute toggle task on a separate thread if already running on a background thread
            if ( Thread.CurrentThread.IsBackground )
            {
                LOG.Info("Executing toggle capture command on the same thread");
                ExecuteToggleCaptureCommand(command);
            }
            else
            {
                LOG.Info("Executing toggle capture command on a new background thread");
                new Thread(() => ExecuteToggleCaptureCommand(command)) { IsBackground = true }.Start();
            }
        }

        private static void ExecuteToggleCaptureCommand(CaptureCommand command)
        {
            try
            {
                switch ( command )
                {
                    case CaptureCommand.ON:
                        TrayIcon.Icon = Resources.Hyperion_enabled;
                        TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_ENABLED;
                        _captureEnabled = true;
                        _captureThread = new Thread(TryStartCapture) { IsBackground = true };
                        _captureThread.Start();
                        break;

                    case CaptureCommand.OFF:
                        TrayIcon.Icon = Resources.Hyperion_disabled;
                        TrayIcon.Text = AppConstants.TRAY_ICON_MSG_CAPTURE_DISABLED;
                        TerminateScreenCapture();
                        ProtoClient.TryClearPriority(SettingsManager.HyperionMessagePriority);
                        DisconnectProtoClient();
                        break;

                    default:
                        throw new NotImplementedException($"The capture command {command} is not supported");
                }
                LOG.Info($"Toggle capture command {command} completed");
            }
            finally
            {
                _captureToggleInProgress = false;
                LOG.Info("Toggle capture lock unset");
            }
        }

        private static void DisconnectProtoClient()
        {
            ProtoClient.Disconnect();
            Thread.Sleep(500);
            TrayIcon.Text = AppConstants.TRAY_ICON_MSG_NOT_CONNECTED;
            LOG.Info("Proto Client disconnect action completed");
        }

        public static bool IsScreenCaptureRunning()
        {
            return _captureThread != null && _captureThread.IsAlive && _captureEnabled;
        }

        private static void TerminateScreenCapture()
        {
            LOG.Info("Terminating screen capture");
            _captureEnabled = false;
            Thread.Sleep(SettingsManager.CaptureInterval + AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS + 1000);
            LOG.Info("Screen capture terminated");
        }

        private static void OnChangeMonitor(object sender, EventArgs e)
        {
            LOG.Info("DX9 monitor selection changed using tray icon");
            var selectedMenuItem = sender as ToolStripDropDownItem;
            if ( selectedMenuItem != null )
            {
                int newMonitorIndex;
                var selectedItem = selectedMenuItem.Text.Replace("#", string.Empty);
                bool isValidInteger = int.TryParse(selectedItem, out newMonitorIndex);
                if ( isValidInteger )
                {
                    LOG.Info($"Selected new monitor index: {newMonitorIndex}");
                    SettingsManager.MonitorIndex = newMonitorIndex;
                    SettingsManager.SaveSettings();
                    Init(true, true);
                }
                else
                {
                    LOG.Info($"Selected monitor index was invalid integer: {selectedItem}");
                }
            }
            else
            {
                LOG.Info("OnChangeMonitor selected item was null");
            }
        }

        private static void OnSetup(object sender, EventArgs e)
        {
            LOG.Info("Loading SetupForm");
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }

        private static void OnExit(object sender, EventArgs e)
        {
            LOG.Info("Exiting Application");
            // Clear tray icon on close
            if ( TrayIcon != null )
            {
                TrayIcon.Visible = false;
            }

            // Send clear priority
            if ( ProtoClient.Initialized )
            {
                TerminateScreenCapture();
                ProtoClient.TryClearPriority(SettingsManager.HyperionMessagePriority);
                DisconnectProtoClient();
            }

            if ( SettingsManager.ApiEnabled )
                _apiServer.StopServer();

            // Unregister various event handlers
            SystemEvents.PowerModeChanged -= PowerModeChanged;
            SystemEvents.SessionSwitch -= SessionSwitched;
            LOG.Info("Exit cleanup complete");
            Environment.Exit(0);
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        #region DXCapture

        private static void InitScreenCapture()
        {
            if ( _screenCapture != null && !_screenCapture.IsDisposed() )
            {
                // Screen capture already initialized
                return;
            }
            try
            {
                LOG.Info($"Initializing screen capture for {SettingsManager.CaptureMethod}");
                switch ( SettingsManager.CaptureMethod )
                {
                    case CaptureMethod.DX9:
                        _screenCapture = new DX9ScreenCapture(SettingsManager.MonitorIndex, SettingsManager.HyperionWidth, SettingsManager.HyperionHeight,
                            SettingsManager.CaptureInterval);
                        break;

                    case CaptureMethod.DX11:
                        _screenCapture = new DX11ScreenCapture(SettingsManager.Dx11AdapterIndex, SettingsManager.Dx11MonitorIndex, SettingsManager.Dx11ImageScalingFactor,
                            SettingsManager.Dx11MaxFps, SettingsManager.Dx11FrameCaptureTimeout);
                        break;

                    default:
                        throw new NotImplementedException($"The capture method {SettingsManager.CaptureMethod} is not supported yet");
                }
                LOG.Info("Screen capture initialized");
            }
            catch ( Exception ex )
            {
                throw new Exception("Failed to initialize screen capture: " + ex.Message, ex);
            }
        }

        private static String GetProtoInitFailedMsg()
        {
            return $"Failed to connect to Hyperion server on {SettingsManager.HyperionServerIp}:{SettingsManager.HyperionServerPort}";
        }

        private static void InitProtoClient()
        {
            if ( ProtoClient.IsConnected() )
            {
                // Proto client already initialized
                return;
            }
            try
            {
                LOG.Info("Initializing Proto Client");
                ProtoClient.Disconnect();
                ProtoClient.Init(SettingsManager.HyperionServerIp, SettingsManager.HyperionServerPort, SettingsManager.HyperionMessagePriority);
                // Double checking since sometimes exceptions are not thrown even if connection fails
                if ( ProtoClient.IsConnected() )
                {
                    LOG.Info("Proto Client initialized");
                    NotificationUtils.Info($"Connected to Hyperion server on {SettingsManager.HyperionServerIp}:{SettingsManager.HyperionServerPort}!");
                }
                else
                    throw new Exception(GetProtoInitFailedMsg());
            }
            catch ( Exception ex )
            {
                throw new Exception(GetProtoInitFailedMsg(), ex);
            }
        }

        private static void TransmitNextFrame()
        {
            try
            {
                byte[] imageData = _screenCapture.Capture();
                ProtoClient.SendImageToServer(imageData, _screenCapture.CaptureWidth, _screenCapture.CaptureHeight);

                // Uncomment the following to enable debugging
                // MiscUtils.SaveRGBArrayToImageFile(imageData, _screenCapture.CaptureWidth, _screenCapture.CaptureHeight, AppConstants.DEBUG_IMAGE_FILE_NAME);
            }
            catch ( Exception ex )
            {
                throw new Exception("Error occured during capture: " + ex.Message, ex);
            }
        }

        private static void StartCapture()
        {
            int captureAttempt = 1;
            while ( _captureEnabled )
            {
                try // This block will help retry capture before giving up
                {
                    InitScreenCapture();
                    InitProtoClient();
                    TransmitNextFrame();
                    _screenCapture.DelayNextCapture();

                    // Reset attempt count
                    captureAttempt = 1;
                }
                catch ( Exception ex )
                {
                    LOG.Error($"Exception in screen capture attempt: {captureAttempt}", ex);
                    if ( captureAttempt > AppConstants.REINIT_CAPTURE_AFTER_ATTEMPTS )
                    {
                        // After a few attempt, try disposing screen capture object as well
                        _screenCapture?.Dispose();
                        LOG.Info("Will re-initialize screen capture on retry");
                    }
                    if ( ++captureAttempt == AppConstants.MAX_CAPTURE_ATTEMPTS )
                    {
                        LOG.Error("Max screen capture attempts reached. Giving up.");
                        NotificationUtils.Error(ex.Message);
                        return;
                    }
                    else
                    {
                        LOG.Info("Waiting before next screen capture attempt");
                        Thread.Sleep(AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS);
                    }
                }
            }
        }

        private static void TryStartCapture()
        {
            try // Properly dispose screenCapture object when turning off capture
            {
                StartCapture();
            }
            finally
            {
                _screenCapture.Dispose();
            }
            LOG.Info("Screen Capture finished");
            ToggleCapture(CaptureCommand.OFF);
        }

        #endregion DXCapture

        #region PowerMode & SessionSwitch Events

        private static void PowerModeChanged(object sender, PowerModeChangedEventArgs powerMode)
        {
            if ( !SettingsManager.PauseOnSystemSuspend )
                return;

            LOG.Info($"Applying Power Mode: {powerMode.Mode}");
            switch ( powerMode.Mode )
            {
                case PowerModes.Resume:
                    ResumeCapture();
                    break;

                case PowerModes.Suspend:
                    SuspendCapture();
                    break;
            }
        }

        private static void SessionSwitched(object sender, SessionSwitchEventArgs switchEvent)
        {
            if ( !SettingsManager.PauseOnUserSwitch )
                return;

            LOG.Info($"Applying Session Switch Event: {switchEvent.Reason}");
            switch ( switchEvent.Reason )
            {
                case SessionSwitchReason.SessionUnlock:
                    ResumeCapture();
                    break;

                case SessionSwitchReason.SessionLock:
                    SuspendCapture();
                    break;
            }
        }

        private static void ResumeCapture()
        {
            if ( _captureSuspended )
            {
                LOG.Info("Capture was suspended. Resuming capture.");
                _captureSuspended = false;
                Thread.Sleep(AppConstants.CAPTURE_RESUME_GRACE_MILLIS);
                ToggleCapture(CaptureCommand.ON);
            }
        }

        private static void SuspendCapture()
        {
            if ( IsScreenCaptureRunning() )
            {
                LOG.Info("Capture running. Suspending capture");
                _captureSuspended = true;
                ToggleCapture(CaptureCommand.OFF);
            }
        }

        #endregion
    }
}