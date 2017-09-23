using HyperionScreenCap.Model;
using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class NotificationUtils
    {
        public static void Error(string errorMsg)
        {
            if (SettingsManager.NotificationLevel != NotificationLevel.Info &&
                SettingsManager.NotificationLevel != NotificationLevel.Error) return;
            MainForm.TrayIcon.ShowBalloonTip(3000, "", errorMsg, ToolTipIcon.Error);
        }

        public static void Info(string infoMsg)
        {
            if (SettingsManager.NotificationLevel != NotificationLevel.Info) return;
            MainForm.TrayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
            Console.WriteLine(infoMsg);
        }
    }
}