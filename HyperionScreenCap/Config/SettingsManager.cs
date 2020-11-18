using HyperionScreenCap.Model;
using HyperionScreenCap.Properties;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class SettingsManager
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(SettingsManager));

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
        public static bool CheckUpdateOnStartup;

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

        public static List<HyperionTaskConfiguration> HyperionTaskConfigurations;

        public static NotificationLevel NotificationLevel;

        public static void SaveSettings()
        {
            LOG.Info("Saving settings to user.config");
            Settings.Default.hyperionServerIP = HyperionServerIp;
            Settings.Default.hyperionServerPort = HyperionServerPort;
            Settings.Default.hyperionMessagePriority = HyperionMessagePriority;
            Settings.Default.hyperionMessageDuration = HyperionMessageDuration;
            Settings.Default.width = HyperionWidth;
            Settings.Default.height = HyperionHeight;
            Settings.Default.captureInterval = CaptureInterval;
            Settings.Default.monitorIndex = MonitorIndex;
            Settings.Default.notificationLevel = NotificationLevel;
            Settings.Default.captureOnStartup = CaptureOnStartup;
            Settings.Default.pauseOnUserSwitch = PauseOnUserSwitch;
            Settings.Default.pauseOnSystemSuspend = PauseOnSystemSuspend;
            Settings.Default.apiPort = ApiPort;
            Settings.Default.apiEnabled = ApiEnabled;
            Settings.Default.apiExcludedTimesEnabled = ApiExcludedTimesEnabled;
            Settings.Default.apiExcludeTimeStart = ApiExcludeTimeStart;
            Settings.Default.apiExcludeTimeEnd = ApiExcludeTimeEnd;
            Settings.Default.captureMethod = CaptureMethod;
            Settings.Default.dx11MaxFps = Dx11MaxFps;
            Settings.Default.dx11FrameCaptureTimeout = Dx11FrameCaptureTimeout;
            Settings.Default.dx11ImageScalingFactor = Dx11ImageScalingFactor;
            Settings.Default.dx11AdapterIndex = Dx11AdapterIndex;
            Settings.Default.dx11MonitorIndex = Dx11MonitorIndex;
            Settings.Default.checkUpdateOnStartup = CheckUpdateOnStartup;
            Settings.Default.hyperionTaskConfigurations = JsonConvert.SerializeObject(HyperionTaskConfigurations);
            Settings.Default.Save();
            LOG.Info("Settings saved to user.config");
        }

        public static void LoadSetttings()
        {
            LOG.Info("Loading settings from user.config");
            HyperionServerIp = Settings.Default.hyperionServerIP;
            HyperionServerPort = Settings.Default.hyperionServerPort;
            HyperionMessagePriority = Settings.Default.hyperionMessagePriority;
            HyperionMessageDuration = Settings.Default.hyperionMessageDuration;
            HyperionWidth = Settings.Default.width;
            HyperionHeight = Settings.Default.height;
            CaptureInterval = Settings.Default.captureInterval;
            MonitorIndex = Settings.Default.monitorIndex;
            NotificationLevel = Settings.Default.notificationLevel;
            CaptureOnStartup = Settings.Default.captureOnStartup;
            PauseOnUserSwitch = Settings.Default.pauseOnUserSwitch;
            PauseOnSystemSuspend = Settings.Default.pauseOnSystemSuspend;
            ApiPort = Settings.Default.apiPort;
            ApiEnabled = Settings.Default.apiEnabled;
            ApiExcludedTimesEnabled = Settings.Default.apiExcludedTimesEnabled;
            ApiExcludeTimeStart = Settings.Default.apiExcludeTimeStart;
            ApiExcludeTimeEnd = Settings.Default.apiExcludeTimeEnd;
            CaptureMethod = Settings.Default.captureMethod;
            Dx11MaxFps = Settings.Default.dx11MaxFps;
            Dx11FrameCaptureTimeout = Settings.Default.dx11FrameCaptureTimeout;
            Dx11ImageScalingFactor = Settings.Default.dx11ImageScalingFactor;
            Dx11AdapterIndex = Settings.Default.dx11AdapterIndex;
            Dx11MonitorIndex = Settings.Default.dx11MonitorIndex;
            CheckUpdateOnStartup = Settings.Default.checkUpdateOnStartup;
            HyperionTaskConfigurations = JsonConvert.DeserializeObject<List<HyperionTaskConfiguration>>(Settings.Default.hyperionTaskConfigurations);
            LOG.Info("Loaded settings from user.config");
        }

        public static void CopySettingsFromPreviousVersion()
        {
            if ( Settings.Default.upgradeRequired )
            {
                LOG.Info("[Settings Upgrade] Going to copy over settings from previous version");
                try
                {
                    Settings.Default.Upgrade();
                    LOG.Info("[Settings Upgrade] Successfully copied settings");
                }
                catch ( ConfigurationErrorsException ex )
                {
                    LOG.Error("[Settings Upgrade] Failed to copy settings", ex);
                    MessageBox.Show("Failed to copy settings from previous version of the app. All settings have been reset.");
                }
                Settings.Default.upgradeRequired = false;
                Settings.Default.Save();
            }
        }

        public static void MigrateLegacySettings()
        {
            if ( Settings.Default.migrateLegacyHyperionConfiguration )
            {
                LOG.Info("[Settings Migration] Migrating legacy hyperion configuration to JSON string");
                List<HyperionTaskConfiguration> configurations = new List<HyperionTaskConfiguration>();
                configurations.Add(HyperionTaskConfiguration.BuildUsingLegacySettings());
                Settings.Default.hyperionTaskConfigurations = JsonConvert.SerializeObject(configurations);
                Settings.Default.migrateLegacyHyperionConfiguration = false;
                Settings.Default.migrateFromBefore2_7 = false;
                Settings.Default.Save();
                LOG.Info("[Settings Migration] Saved legacy hyperion configuration as JSON string");
            } else if ( Settings.Default.migrateFromBefore2_7 )
            {
                LOG.Info("[Settings Migration] Migrating settings from before version 2.7");
                var configurations = JsonConvert.DeserializeObject<List<HyperionTaskConfiguration>>(Settings.Default.hyperionTaskConfigurations);
                foreach (HyperionTaskConfiguration configuration in configurations)
                {
                    configuration.Enabled = true;
                    foreach (HyperionServer server in configuration.HyperionServers)
                    {
                        server.Protocol = HyperionServerProtocol.PROTOCOL_BUFFERS;
                        if (server.Priority < HyperionServer.MIN_PRIORITY)
                        {
                            server.Priority = HyperionServer.MIN_PRIORITY;
                        }
                        if (server.Priority > HyperionServer.MAX_PRIORITY)
                        {
                            server.Priority = HyperionServer.MAX_PRIORITY;
                        }
                    }
                }
                Settings.Default.hyperionTaskConfigurations = JsonConvert.SerializeObject(configurations);
                Settings.Default.migrateFromBefore2_7 = false;
                Settings.Default.Save();
                LOG.Info("[Settings Migration] Settings from befor version 2.7 were migrated successfully");
            }
        }
    }
}
