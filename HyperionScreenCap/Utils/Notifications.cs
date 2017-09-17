using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Notifications
    {
        public static void Error(string errorMsg)
        {
            if (Settings.NotificationLevel != Form1.NotificationLevels.Info &&
                Settings.NotificationLevel != Form1.NotificationLevels.Error) return;
            Form1.TrayIcon.ShowBalloonTip(3000, "", errorMsg, ToolTipIcon.Error);
        }

        public static void Info(string infoMsg)
        {
            if (Settings.NotificationLevel != Form1.NotificationLevels.Info) return;
            Form1.TrayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
            Console.WriteLine(infoMsg);
        }
    }
}