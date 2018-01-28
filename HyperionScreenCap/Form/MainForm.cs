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
using System.Collections.Generic;

namespace HyperionScreenCap
{
    public partial class MainForm : Form
    {
        #region Variables

        private static readonly ILog LOG = LogManager.GetLogger(typeof(MainForm));

        private ApiServer _apiServer;
        private NotifyIcon _trayIcon;
        private NotificationUtils _notificationUtils;

        private Thread _uiThread;
        private bool _initLock = false;
        private bool _captureSuspended = false;
        private bool _captureToggleInProgress = false;
        public bool CaptureEnabled { get; private set; } = false;

        private List<HyperionTask> _hyperionTasks = new List<HyperionTask>();

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
            _uiThread = Thread.CurrentThread;
            SettingsManager.LoadSetttings();

            if ( SettingsManager.CheckUpdateOnStartup )
            {
                UpdateChecker.StartUpdateCheck(true);
            }

            _trayIcon = new NotifyIcon { Text = AppConstants.TrayIcon.TOOLTIP_CAPTURE_DISABLED };
            _trayIcon.DoubleClick += TrayIcon_DoubleClick;
            _trayIcon.Icon = Resources.Hyperion_disabled;
            _notificationUtils = new NotificationUtils(_trayIcon);
            // Add menu to tray icon and show it.
            ContextMenuStrip trayMenuIcons = new ContextMenuStrip();
            trayMenuIcons.ImageScalingSize = SystemInformation.SmallIconSize;
            trayMenuIcons.Items.Add(AppConstants.TrayIcon.MENU_TXT_START_CAPTURE, Resources.enable_capture.ToBitmap(), TrayIcon_OnCaptureToggleClick);
            trayMenuIcons.Items.Add(AppConstants.TrayIcon.MENU_TXT_SETUP, Resources.gear.ToBitmap(), TrayIcon_OnSetupClick);
            trayMenuIcons.Items.Add(AppConstants.TrayIcon.MENU_TXT_EXIT, Resources.cross.ToBitmap(), TrayIcon_OnExitClick);
            _trayIcon.ContextMenuStrip = trayMenuIcons;
            _trayIcon.Visible = true;

            LOG.Info("MainForm Instantiated");
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            LOG.Info("MainForm Shown");
            // TODO change the following condition
            if ( SettingsManager.HyperionTaskConfigurations.Count == 0
                || SettingsManager.HyperionTaskConfigurations.Count == 1 && SettingsManager.HyperionTaskConfigurations[0].HyperionServers[0].Host.Equals("0.0.0.0") )
            {
                LOG.Info("Saved settings not available. Prompting to configure app.");
                MessageBox.Show("No configuration found, please setup in the next window.");
                ShowSetupFrom();
            }
            else
            {
                Init();
            }

            // Register various event handlers
            SystemEvents.PowerModeChanged += PowerModeChanged;
            SystemEvents.SessionSwitch += SessionSwitched;
        }

        public void Init(bool reInit = false, bool forceOn = false)
        {
            LOG.Info($"Initialization requested with parameters reInit={reInit}, forceOn={forceOn}");
            if ( _initLock )
            {
                LOG.Info("Initialization already in progress. Ignoring request.");
                return;
            }
            _initLock = true;
            LOG.Info("Initialization lock set");

            // Stop current capture first on reinit
            if ( reInit )
            {
                ToggleCapture(CaptureCommand.OFF, false, false);
            }

            if ( SettingsManager.CaptureOnStartup || forceOn )
            {
                ToggleCapture(CaptureCommand.ON);
            }

            if ( SettingsManager.ApiEnabled )
            {
                _apiServer = new ApiServer(this);
                _apiServer.StartServer("localhost", SettingsManager.ApiPort.ToString());
            }
            else
            {
                _apiServer?.StopServer();
            }
            _initLock = false;
            LOG.Info("Initialization lock unset");
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            LOG.Info("Tray icon double clicked");
            ToggleCapture(CaptureEnabled ? CaptureCommand.OFF : CaptureCommand.ON);
        }

        private void TrayIcon_OnCaptureToggleClick(object sender, EventArgs e)
        {
            TrayIcon_DoubleClick(sender, e);
        }

        public void ToggleCapture(CaptureCommand command)
        {
            ToggleCapture(command, true, true);
        }

        private void ToggleCapture(CaptureCommand command, bool executeOnNewThread, bool useBackgroundThread)
        {
            LOG.Info($"Processing toggle capture command: {command}");
            // Don't accept toggle commands until previous one completes
            if ( _captureToggleInProgress )
            {
                LOG.Info($"Toggle capture in progress. Ignoring command: {command}");
                return;
            }

            if(OnUiThread())
            {
                GetCaptureToggleTrayMenuItem().Enabled = false;
            } else
            {
                Invoke(new Action(() =>
                {
                    GetCaptureToggleTrayMenuItem().Enabled = false;
                }));
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
                if ( executeOnNewThread )
                {
                    LOG.Info($"Executing toggle capture command on a new Thread[IsBackground = {useBackgroundThread}]");
                    new Thread(() => ExecuteToggleCaptureCommand(command)) { IsBackground = useBackgroundThread }.Start();
                } else
                {
                    LOG.Info("Executing toggle capture command on the same Thread");
                    ExecuteToggleCaptureCommand(command);
                }
            }
        }

        private void ExecuteToggleCaptureCommand(CaptureCommand command)
        {
            try
            {
                switch ( command )
                {
                    case CaptureCommand.ON:
                        _trayIcon.Icon = Resources.Hyperion_enabled;
                        _trayIcon.Text = AppConstants.TrayIcon.TOOLTIP_CAPTURE_ENABLED;
                        Invoke(new Action(() =>
                        {
                            GetCaptureToggleTrayMenuItem().Text = AppConstants.TrayIcon.MENU_TXT_STOP_CAPTURE;
                            GetCaptureToggleTrayMenuItem().Image = Resources.disable_capture.ToBitmap();
                        }));
                        EnableCapture();
                        break;

                    case CaptureCommand.OFF:
                        _trayIcon.Icon = Resources.Hyperion_disabled;
                        _trayIcon.Text = AppConstants.TrayIcon.TOOLTIP_CAPTURE_DISABLED;
                        Invoke(new Action(() =>
                        {
                            GetCaptureToggleTrayMenuItem().Text = AppConstants.TrayIcon.MENU_TXT_START_CAPTURE;
                            GetCaptureToggleTrayMenuItem().Image = Resources.enable_capture.ToBitmap();
                        }));
                        DisableCapture();
                        break;

                    default:
                        throw new NotImplementedException($"The capture command {command} is not supported");
                }
                LOG.Info($"Toggle capture command {command} completed");
            }
            finally
            {
                Invoke(new Action(() =>
                {
                    GetCaptureToggleTrayMenuItem().Enabled = true;
                }));
                _captureToggleInProgress = false;
                LOG.Info("Toggle capture lock unset");
            }
        }

        private ToolStripItem GetCaptureToggleTrayMenuItem()
        {
            return _trayIcon.ContextMenuStrip.Items[0];
        }

        private bool OnUiThread()
        {
            return Thread.CurrentThread == _uiThread;
        }

        private void EnableCapture()
        {
            LOG.Info($"Enabling {SettingsManager.HyperionTaskConfigurations.Count} screen capture(s)");
            _hyperionTasks.Clear();
            foreach ( HyperionTaskConfiguration configuration in SettingsManager.HyperionTaskConfigurations )
            {
                HyperionTask hyperionTask = new HyperionTask(configuration, _notificationUtils);
                hyperionTask.EnableCapture();
                _hyperionTasks.Add(hyperionTask);
            }
            CaptureEnabled = true;
            new Thread(DisableCaptureOnFailure) { IsBackground = true }.Start();
            LOG.Info($"Enabled {_hyperionTasks.Count} screen capture(s)");
        }

        private void DisableCapture()
        {
            LOG.Info($"Disabling {_hyperionTasks.Count} screen capture(s)");
            foreach ( HyperionTask task in _hyperionTasks )
            {
                task.DisableCapture();
            }
            CaptureEnabled = false;
            Thread.Sleep(SettingsManager.CaptureInterval + AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS + 1000);
            LOG.Info($"Disabled {_hyperionTasks.Count} screen capture(s)");
        }

        private void DisableCaptureOnFailure()
        {
            while ( CaptureEnabled )
            {
                foreach ( HyperionTask task in _hyperionTasks )
                {
                    if ( !task.CaptureEnabled )
                    {
                        // We have found a task for which capture has been disabled due to failure
                        // Turning off capture and exiting this thread
                        LOG.Error($"Found {task} with capture disabled due to failure. Issuing OFF command.");
                        ToggleCapture(CaptureCommand.OFF, false, false);
                        return;
                    }
                }
                Thread.Sleep(AppConstants.CAPTURE_FAILURE_DETECTION_INTERVAL);
            }
        }

        private void TrayIcon_OnSetupClick(object sender, EventArgs e)
        {
            ShowSetupFrom();
        }

        private void ShowSetupFrom()
        {
            LOG.Info("Loading SetupForm");
            SetupForm setupForm = new SetupForm(this);
            setupForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LOG.Info("Initiating cleanup");
            // Unregister various event handlers
            SystemEvents.PowerModeChanged -= PowerModeChanged;
            SystemEvents.SessionSwitch -= SessionSwitched;
            // Clear tray icon on close
            if ( _trayIcon != null )
            {
                _trayIcon.Visible = false;
            }
            if ( SettingsManager.ApiEnabled )
                _apiServer.StopServer();
            ToggleCapture(CaptureCommand.OFF, false, false);
            LOG.Info("**********************************************************");
            LOG.Info("Exit cleanup complete. Application normal shutdown.");
            LOG.Info("**********************************************************");
        }

        private void TrayIcon_OnExitClick(object sender, EventArgs e)
        {
            LOG.Info("Clicked exit taskbar menu option");
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            base.OnLoad(e);
        }

        #region PowerMode & SessionSwitch Events

        private void PowerModeChanged(object sender, PowerModeChangedEventArgs powerMode)
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

        private void SessionSwitched(object sender, SessionSwitchEventArgs switchEvent)
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

        private void ResumeCapture()
        {
            if ( _captureSuspended )
            {
                LOG.Info("Capture was suspended. Resuming capture.");
                _captureSuspended = false;
                Thread.Sleep(AppConstants.CAPTURE_RESUME_GRACE_MILLIS);
                ToggleCapture(CaptureCommand.ON);
            }
        }

        private void SuspendCapture()
        {
            if ( CaptureEnabled )
            {
                LOG.Info("Capture running. Suspending capture");
                _captureSuspended = true;
                ToggleCapture(CaptureCommand.OFF);
            }
        }

        #endregion

    }
}