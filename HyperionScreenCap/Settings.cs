using System;
using System.Configuration;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Settings
    {
        private static readonly Configuration Config =
            ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

        public static string HyperionServerIp;
        public static int HyperionServerPort;
        public static int HyperionMessagePriority;

        public static int HyperionMessageDuration;

        public static int HyperionWidth;
        public static int HyperionHeight;
        public static int CaptureInterval;
        public static int MonitorIndex;
        public static int ReconnectInterval;

        public static Form1.NotificationLevels NotificationLevel;

        public static void SaveSettings()
        {
            var setting = Config.AppSettings.Settings;

            setting["hyperionServerIP"].Value = HyperionServerIp;
            setting["hyperionServerPort"].Value = HyperionServerPort.ToString();
            setting["hyperionMessagePriority"].Value = HyperionMessagePriority.ToString();
            setting["hyperionMessageDuration"].Value = HyperionMessageDuration.ToString();
            setting["width"].Value = HyperionWidth.ToString();
            setting["height"].Value = HyperionHeight.ToString();
            setting["captureInterval"].Value = CaptureInterval.ToString();
            setting["monitorIndex"].Value = MonitorIndex.ToString();
            setting["reconnectInterval"].Value = ReconnectInterval.ToString();
            setting["notificationLevel"].Value = NotificationLevel.ToString();

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
                HyperionWidth = int.Parse(setting["width"].Value);
                HyperionHeight = int.Parse(setting["height"].Value);
                CaptureInterval = int.Parse(setting["captureInterval"].Value);
                MonitorIndex = int.Parse(setting["monitorIndex"].Value);
                ReconnectInterval = int.Parse(setting["reconnectInterval"].Value);
                NotificationLevel =
                    (Form1.NotificationLevels)
                        Enum.Parse(typeof(Form1.NotificationLevels), setting["notificationLevel"].Value);
            }
        }
    }
}
