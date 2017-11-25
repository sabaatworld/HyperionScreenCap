using HyperionScreenCap.Config;
using HyperionScreenCap.Model;
using log4net;
using log4net.Config;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    internal static class Program
    {

        private static ILog LOG;

        static Program()
        {
            CosturaUtility.Initialize();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ConfigureLog4Net();
            LOG = LogManager.GetLogger(typeof(Program));
            LOG.Info("Logger Initialized");

            // Set DPI awareness
            SetProcessDPIAware();

            // Check if already running and exit if that's the case
            if (IsProgramRunning("hyperionscreencap", 0) > 1)
            {
                LOG.Error("Hyperion Screen Capture process already running.");
                try
                {
                    MessageBox.Show("HyperionScreenCap is already running!");
                    LOG.Info("Exiting application");
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            // Copy settings from previous version
            SettingsManager.CopySettingsFromPreviousVersion();

            // Migrate legacy settings
            SettingsManager.MigrateLegacySettings();

            MainForm _mainForm = new MainForm();
            Application.Run(_mainForm);
        }

        private static void ConfigureLog4Net()
        {
            log4net.GlobalContext.Properties["logFilePath"] = MiscUtils.GetLogDirectory() + Path.DirectorySeparatorChar + AppConstants.LOG_FILE_NAME;
            using ( Stream configStream = MiscUtils.GenerateStreamFromString(Resources.LogConfiguration) )
            {
                XmlConfigurator.Configure(configStream);
            }
        }

        private static int IsProgramRunning(string name, int runtime)
        {
            runtime += Process.GetProcesses().Count(clsProcess => clsProcess.ProcessName.ToLower().Equals(name));
            return runtime;
        }
    }
}