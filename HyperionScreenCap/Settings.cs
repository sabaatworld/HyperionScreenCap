using System;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Settings
    {
        private static readonly Configuration Config =
            ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        // Generic
        public static string HyperionServerIp;
        public static string HyperionServerIp2 = "0.0.0.0";
        public static int HyperionServerPort;
        public static int HyperionServerPort2;
        public static int HyperionMessagePriority;
        public static int HyperionMessagePriority2;
        public static int HyperionMessageDuration;
        public static int HyperionWidth;
        public static int HyperionHeight;
        public static int HyperionServerIndex = 1;
        public static int CaptureInterval;
        public static int MonitorIndex;
        public static int ReconnectInterval;
        public static bool CaptureOnStartup = true;

        // API
        public static int ApiPort = 29445;
        public static bool ApiEnabled;
        public static bool ApiExcludedTimesEnabled;
        public static DateTime ApiExcludeTimeStart = DateTime.Parse("08:00");
        public static DateTime ApiExcludeTimeEnd = DateTime.Parse("17:00");

        public static Form1.NotificationLevels NotificationLevel;

        public static void SaveSettings()
        {
            var setting = Config.AppSettings.Settings;

            setting["hyperionServerIP"].Value = HyperionServerIp;
            setting["hyperionServerPort"].Value = HyperionServerPort.ToString();
            setting["hyperionMessagePriority"].Value = HyperionMessagePriority.ToString();
            setting["hyperionMessageDuration"].Value = HyperionMessageDuration.ToString();

            if (setting["hyperionServerIP2"] != null)
            {
                setting["hyperionServerIP2"].Value = HyperionServerIp2;
                setting["hyperionServerPort2"].Value = HyperionServerPort2.ToString();
                setting["hyperionMessagePriority2"].Value = HyperionMessagePriority2.ToString();
            }

            setting["hyperionServerIndex"].Value = HyperionServerIndex.ToString();

            setting["width"].Value = HyperionWidth.ToString();
            setting["height"].Value = HyperionHeight.ToString();
            setting["captureInterval"].Value = CaptureInterval.ToString();
            setting["monitorIndex"].Value = MonitorIndex.ToString();
            setting["reconnectInterval"].Value = ReconnectInterval.ToString();
            setting["notificationLevel"].Value = NotificationLevel.ToString();
            if (setting["captureOnStartup"] != null)
                setting["captureOnStartup"].Value = CaptureOnStartup.ToString();

            if (setting["apiPort"] != null)
                setting["apiPort"].Value = ApiPort.ToString();
            if (setting["apiEnabled"] != null)
                setting["apiEnabled"].Value = ApiEnabled.ToString();
            if (setting["apiExcludedTimesEnabled"] != null)
                setting["apiExcludedTimesEnabled"].Value = ApiExcludedTimesEnabled.ToString();
            if (setting["apiExcludeTimeStart"] != null)
                setting["apiExcludeTimeStart"].Value = ApiExcludeTimeStart.ToString();
            if (setting["apiExcludeTimeEnd"] != null)
                setting["apiExcludeTimeEnd"].Value = ApiExcludeTimeEnd.ToString();

            Config.Save(ConfigurationSaveMode.Modified);
        }

        public static void LoadSetttings()
        {
            if (Config.HasFile)
            {
                var setting = Config.AppSettings.Settings;

                HyperionServerIp = setting["hyperionServerIP"].Value;
                HyperionServerPort = int.Parse(setting["hyperionServerPort"].Value);
                HyperionMessagePriority = int.Parse(setting["hyperionMessagePriority"].Value);
                HyperionMessageDuration = int.Parse(setting["hyperionMessageDuration"].Value);

                if (setting["hyperionServerIP2"] != null)
                {
                    HyperionServerIp2 = setting["hyperionServerIP2"].Value;
                    HyperionServerPort2 = int.Parse(setting["hyperionServerPort2"].Value);
                    HyperionMessagePriority2 = int.Parse(setting["hyperionMessagePriority2"].Value);
                }

                HyperionWidth = int.Parse(setting["width"].Value);
                HyperionHeight = int.Parse(setting["height"].Value);
                HyperionServerIndex = int.Parse(setting["hyperionServerIndex"].Value);

                CaptureInterval = int.Parse(setting["captureInterval"].Value);
                MonitorIndex = int.Parse(setting["monitorIndex"].Value);
                ReconnectInterval = int.Parse(setting["reconnectInterval"].Value);
                if (setting["captureOnStartup"] != null)
                    CaptureOnStartup = bool.Parse(setting["captureOnStartup"].Value);

                if (setting["apiPort"] != null)
                    ApiPort = int.Parse(setting["apiPort"].Value);
                if (setting["apiEnabled"] != null)
                    ApiEnabled = bool.Parse(setting["apiEnabled"].Value);
                if (setting["apiExcludedTimesEnabled"] != null)
                    ApiExcludedTimesEnabled = bool.Parse(setting["apiExcludedTimesEnabled"].Value);
                if (setting["apiExcludeTimeStart"] != null)
                    DateTime.TryParse(setting["apiExcludeTimeStart"].Value, out ApiExcludeTimeStart);
                if (setting["apiExcludeTimeEnd"] != null)
                    DateTime.TryParse(setting["apiExcludeTimeEnd"].Value, out ApiExcludeTimeEnd);

                NotificationLevel =
                    (Form1.NotificationLevels)
                        Enum.Parse(typeof(Form1.NotificationLevels), setting["notificationLevel"].Value);
            }
        }
    }
}
