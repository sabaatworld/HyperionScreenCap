using HyperionScreenCap.Model;
using log4net;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    class NotificationUtils
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(NotificationUtils));

        private NotifyIcon _trayIcon;

        public NotificationUtils(NotifyIcon trayIcon)
        {
            _trayIcon = trayIcon;
        }

        public void Error(string errorMsg)
        {
            LOG.Error("Error notification: " + errorMsg);
            if ( SettingsManager.NotificationLevel != NotificationLevel.Info &&
                SettingsManager.NotificationLevel != NotificationLevel.Error ) return;
            _trayIcon.ShowBalloonTip(5000, "", errorMsg, ToolTipIcon.Error);
        }

        public void Info(string infoMsg)
        {
            LOG.Info("Info notification: " + infoMsg);
            if ( SettingsManager.NotificationLevel != NotificationLevel.Info ) return;
            _trayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
        }
    }
}