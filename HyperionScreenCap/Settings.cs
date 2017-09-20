using System;
using System.Configuration;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Settings
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

        // API
        public static int ApiPort = 29445;
        public static bool ApiEnabled;
        public static bool ApiExcludedTimesEnabled;
        public static DateTime ApiExcludeTimeStart = DateTime.Parse("08:00");
        public static DateTime ApiExcludeTimeEnd = DateTime.Parse("17:00");

        public static string CaptureMethod;
        public static int Dx11MaxFps;
        public static int Dx11FrameCaptureTimeout;
        public static int Dx11ImageScalingFactor;
        public static int Dx11AdapterIndex;
        public static int Dx11MonitorIndex;

        public static Form1.NotificationLevels NotificationLevel;

        public static void SaveSettings()
        {
            var setting = Config.AppSettings.Settings;

            setting.Clear();
            setting.Add("hyperionServerIP", HyperionServerIp);
            setting.Add("hyperionServerPort", HyperionServerPort.ToString());
            setting.Add("hyperionMessagePriority", HyperionMessagePriority.ToString());
            setting.Add("hyperionMessageDuration", HyperionMessageDuration.ToString());
            setting.Add("width", HyperionWidth.ToString());
            setting.Add("height", HyperionHeight.ToString());
            setting.Add("captureInterval", CaptureInterval.ToString());
            setting.Add("monitorIndex", MonitorIndex.ToString());
            setting.Add("notificationLevel", NotificationLevel.ToString());

            setting.Add("captureOnStartup", CaptureOnStartup.ToString());
            setting.Add("apiPort", ApiPort.ToString());
            setting.Add("apiEnabled", ApiEnabled.ToString());
            setting.Add("apiExcludedTimesEnabled", ApiExcludedTimesEnabled.ToString());
            setting.Add("apiExcludeTimeStart", ApiExcludeTimeStart.ToString());
            setting.Add("apiExcludeTimeEnd", ApiExcludeTimeEnd.ToString());

            setting.Add("captureMethod", CaptureMethod);
            setting.Add("dx11MaxFps", Dx11MaxFps.ToString());
            setting.Add("dx11FrameCaptureTimeout", Dx11FrameCaptureTimeout.ToString());
            setting.Add("dx11ImageScalingFactor", Dx11ImageScalingFactor.ToString());
            setting.Add("dx11AdapterIndex", Dx11AdapterIndex.ToString());
            setting.Add("dx11MonitorIndex", Dx11MonitorIndex.ToString());

            Config.Save(ConfigurationSaveMode.Modified);
        }

        public static void LoadSetttings()
        {
            if ( Config.HasFile )
            {
                var setting = Config.AppSettings.Settings;

                HyperionServerIp = setting["hyperionServerIP"].Value;
                HyperionServerPort = int.Parse(setting["hyperionServerPort"].Value);
                HyperionMessagePriority = int.Parse(setting["hyperionMessagePriority"].Value);
                HyperionMessageDuration = int.Parse(setting["hyperionMessageDuration"].Value);
                HyperionWidth = int.Parse(setting["width"].Value);
                HyperionHeight = int.Parse(setting["height"].Value);
                CaptureInterval = int.Parse(setting["captureInterval"].Value);
                MonitorIndex = int.Parse(setting["monitorIndex"].Value);

                if ( setting["captureOnStartup"] != null )
                    CaptureOnStartup = bool.Parse(setting["captureOnStartup"].Value);
                if ( setting["apiPort"] != null )
                    ApiPort = int.Parse(setting["apiPort"].Value);
                if ( setting["apiEnabled"] != null )
                    ApiEnabled = bool.Parse(setting["apiEnabled"].Value);
                if ( setting["apiExcludedTimesEnabled"] != null )
                    ApiExcludedTimesEnabled = bool.Parse(setting["apiExcludedTimesEnabled"].Value);
                if ( setting["apiExcludeTimeStart"] != null )
                    ApiExcludeTimeStart = DateTime.Parse(setting["apiExcludeTimeStart"].Value);
                if ( setting["apiExcludeTimeEnd"] != null )
                    ApiExcludeTimeEnd = DateTime.Parse(setting["apiExcludeTimeEnd"].Value);

                CaptureMethod = setting["captureMethod"].Value;
                Dx11MaxFps = int.Parse(setting["dx11MaxFps"].Value);
                Dx11FrameCaptureTimeout = int.Parse(setting["dx11FrameCaptureTimeout"].Value);
                Dx11ImageScalingFactor = int.Parse(setting["dx11ImageScalingFactor"].Value);
                Dx11AdapterIndex = int.Parse(setting["dx11AdapterIndex"].Value);
                Dx11MonitorIndex = int.Parse(setting["dx11MonitorIndex"].Value);

                NotificationLevel =
                    (Form1.NotificationLevels)
                        Enum.Parse(typeof(Form1.NotificationLevels), setting["notificationLevel"].Value);
            }
        }
    }
}
