using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static Form1 _mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Set DPI awareness
            SetProcessDPIAware();

            // Check if already running and exit if that's the case
            if (IsProgramRunning("hyperionscreencap", 0) > 1)
            {
                try
                {
                    MessageBox.Show(@"HyperionScreenCap is already running!");
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            _mainForm = new Form1();
            Application.Run(_mainForm);
        }

        private static int IsProgramRunning(string name, int runtime)
        {
            runtime += Process.GetProcesses().Count(clsProcess => clsProcess.ProcessName.ToLower().Equals(name));
            return runtime;
        }
    }
}