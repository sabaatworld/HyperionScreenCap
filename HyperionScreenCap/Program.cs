using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    class Program
    {
        static public Form1 mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main()
        {

        mainForm = new Form1();
            Application.Run(mainForm);
            
        }

        public static void DisableTimer()
        {
            mainForm.screenCaptureInterval.Enabled = false;
        }

        
    }
}
