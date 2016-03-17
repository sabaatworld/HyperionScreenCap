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
            #region Use Embedded SlimDX Assembly

            AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
            {
                String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args.Name);
                String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return System.Reflection.Assembly.Load(assemblyData);
                }
            };

            #endregion

            mainForm = new Form1();
            Application.Run(mainForm);
            
        }
        public static void disableTimer()
        {
            mainForm.screenCaptureInterval.Enabled = false;
        }

        
    }
}
