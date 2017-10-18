using HyperionScreenCap.Model;
using log4net;
using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class NotificationUtils
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(NotificationUtils));

        public static void Error(string errorMsg)
        {
            LOG.Error("Error notification: " + errorMsg);
            if ( SettingsManager.NotificationLevel != NotificationLevel.Info &&
                SettingsManager.NotificationLevel != NotificationLevel.Error ) return;
            MainForm.TrayIcon.ShowBalloonTip(5000, "", errorMsg, ToolTipIcon.Error);
        }

        public static void Info(string infoMsg)
        {
            LOG.Info("Info notification: " + infoMsg);
            if ( SettingsManager.NotificationLevel != NotificationLevel.Info ) return;
            MainForm.TrayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
        }
    }
}