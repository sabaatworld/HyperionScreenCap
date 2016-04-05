using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap
{
    class Notifications
    {
        public static void Error(string errorMsg)
        {
            Form1.trayIcon.ShowBalloonTip(3000, "", errorMsg, System.Windows.Forms.ToolTipIcon.Error);
            //Stop the timer if anything goes wrong
            Program.DisableTimer();
        }

        public static void Info(string infoMsg)
        {
            Form1.trayIcon.ShowBalloonTip(1000, "", infoMsg, System.Windows.Forms.ToolTipIcon.Info);
            Console.WriteLine(infoMsg);
        }
    }
}
