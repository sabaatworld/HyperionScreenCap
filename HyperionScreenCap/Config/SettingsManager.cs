using HyperionScreenCap.Model;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class SettingsManager
    {
        private static readonly Configuration Config =
            ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        // Generic
        public static string HyperionServerIp;
        public static int HyperionServerPort;
        public static int HyperionMessagePriority;
        public static int HyperionMessageDuration;
        public static int HyperionWidth;
        public static int HyperionHeight;
        public static int CaptureInterval;
        public static int MonitorIndex;
        public static bool CaptureOnStartup;
        public static bool PauseOnUserSwitch;
        public static bool PauseOnSystemSuspend;

        // API
        public static int ApiPort = 29445;
        public static bool ApiEnabled;
        public static bool ApiExcludedTimesEnabled;
        public static DateTime ApiExcludeTimeStart;
        public static DateTime ApiExcludeTimeEnd;

        public static CaptureMethod CaptureMethod;
        public static int Dx11MaxFps;
        public static int Dx11FrameCaptureTimeout;
        public static int Dx11ImageScalingFactor;
        public static int Dx11AdapterIndex;
        public static int Dx11MonitorIndex;

        public static NotificationLevel NotificationLevel;

        public static void SaveSettings()
        {
            Properties.Settings.Default.hyperionServerIP = HyperionServerIp;
            Properties.Settings.Default.hyperionServerPort = HyperionServerPort;
            Properties.Settings.Default.hyperionMessagePriority = HyperionMessagePriority;
            Properties.Settings.Default.hyperionMessageDuration = HyperionMessageDuration;
            Properties.Settings.Default.width = HyperionWidth;
            Properties.Settings.Default.height = HyperionHeight;
            Properties.Settings.Default.captureInterval = CaptureInterval;
            Properties.Settings.Default.monitorIndex = MonitorIndex;
            Properties.Settings.Default.notificationLevel = NotificationLevel;
            Properties.Settings.Default.captureOnStartup = CaptureOnStartup;
            Properties.Settings.Default.pauseOnUserSwitch = PauseOnUserSwitch;
            Properties.Settings.Default.pauseOnSystemSuspend = PauseOnSystemSuspend;
            Properties.Settings.Default.apiPort = ApiPort;
            Properties.Settings.Default.apiEnabled = ApiEnabled;
            Properties.Settings.Default.apiExcludedTimesEnabled = ApiExcludedTimesEnabled;
            Properties.Settings.Default.apiExcludeTimeStart = ApiExcludeTimeStart;
            Properties.Settings.Default.apiExcludeTimeEnd = ApiExcludeTimeEnd;
            Properties.Settings.Default.captureMethod = CaptureMethod;
            Properties.Settings.Default.dx11MaxFps = Dx11MaxFps;
            Properties.Settings.Default.dx11FrameCaptureTimeout = Dx11FrameCaptureTimeout;
            Properties.Settings.Default.dx11ImageScalingFactor = Dx11ImageScalingFactor;
            Properties.Settings.Default.dx11AdapterIndex = Dx11AdapterIndex;
            Properties.Settings.Default.dx11MonitorIndex = Dx11MonitorIndex;
            Properties.Settings.Default.Save();
        }

        public static void LoadSetttings()
        {
            HyperionServerIp = Properties.Settings.Default.hyperionServerIP;
            HyperionServerPort = Properties.Settings.Default.hyperionServerPort;
            HyperionMessagePriority = Properties.Settings.Default.hyperionMessagePriority;
            HyperionMessageDuration = Properties.Settings.Default.hyperionMessageDuration;
            HyperionWidth = Properties.Settings.Default.width;
            HyperionHeight = Properties.Settings.Default.height;
            CaptureInterval = Properties.Settings.Default.captureInterval;
            MonitorIndex = Properties.Settings.Default.monitorIndex;
            NotificationLevel = Properties.Settings.Default.notificationLevel;
            CaptureOnStartup = Properties.Settings.Default.captureOnStartup;
            PauseOnUserSwitch = Properties.Settings.Default.pauseOnUserSwitch;
            PauseOnSystemSuspend = Properties.Settings.Default.pauseOnSystemSuspend;
            ApiPort = Properties.Settings.Default.apiPort;
            ApiEnabled = Properties.Settings.Default.apiEnabled;
            ApiExcludedTimesEnabled = Properties.Settings.Default.apiExcludedTimesEnabled;
            ApiExcludeTimeStart = Properties.Settings.Default.apiExcludeTimeStart;
            ApiExcludeTimeEnd = Properties.Settings.Default.apiExcludeTimeEnd;
            CaptureMethod = Properties.Settings.Default.captureMethod;
            Dx11MaxFps = Properties.Settings.Default.dx11MaxFps;
            Dx11FrameCaptureTimeout = Properties.Settings.Default.dx11FrameCaptureTimeout;
            Dx11ImageScalingFactor = Properties.Settings.Default.dx11ImageScalingFactor;
            Dx11AdapterIndex = Properties.Settings.Default.dx11AdapterIndex;
            Dx11MonitorIndex = Properties.Settings.Default.dx11MonitorIndex;
        }
    }
}
