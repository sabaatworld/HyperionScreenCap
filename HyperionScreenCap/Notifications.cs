using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Notifications
    {
        public static void Error(string errorMsg)
        {
            if (Form1.NotificationLevel != Form1.NotifcationLevels.Info &&
                Form1.NotificationLevel != Form1.NotifcationLevels.Error) return;
            Form1.TrayIcon.ShowBalloonTip(3000, "", errorMsg, ToolTipIcon.Error);
        }

        public static void Info(string infoMsg)
        {
            if (Form1.NotificationLevel != Form1.NotifcationLevels.Info) return;
            Form1.TrayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
            Console.WriteLine(infoMsg);
        }
    }
}