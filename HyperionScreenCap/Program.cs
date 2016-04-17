using System;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Program
    {
        private static Form1 _mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

        _mainForm = new Form1();
            Application.Run(_mainForm);
            
        }

        public static void DisableTimer()
        {
            _mainForm.screenCaptureInterval.Enabled = false;
        }

        
    }
}
