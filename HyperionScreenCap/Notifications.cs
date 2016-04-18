using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    static class Notifications
    {
        public static void Error(string errorMsg)
        {
            Form1.TrayIcon.ShowBalloonTip(3000, "", errorMsg, ToolTipIcon.Error);
            //Stop the timer if anything goes wrong
        }

        public static void Info(string infoMsg)
        {
            Form1.TrayIcon.ShowBalloonTip(1000, "", infoMsg, ToolTipIcon.Info);
            Console.WriteLine(infoMsg);
        }
    }
}
