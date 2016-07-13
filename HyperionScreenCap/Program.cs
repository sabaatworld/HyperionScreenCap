using System;
using System.Diagnostics;
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


      // Check if already running and exit if that's the case
      if (isProgramRunning("hyperionscreencap", 0) > 1)
      {
        try
        {
          MessageBox.Show("HyperionScreenCap is already running!");
          Environment.Exit(0);
        }
        catch (Exception)
        {
        }
      }
      _mainForm = new Form1();
      Application.Run(_mainForm);

    }

    private static int isProgramRunning(string name, int runtime)
    {
      foreach (var clsProcess in Process.GetProcesses())
      {
        if (clsProcess.ProcessName.ToLower().Equals(name))
        {
          runtime++;
        }
      }
      return runtime;
    }
  }
}
