using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    public class DxScreenCapture
    {
        Device d;

        public DxScreenCapture()
        {
            try
            {
                PresentParameters present_params = new PresentParameters();
                present_params.Windowed = true;
                present_params.SwapEffect = SwapEffect.Discard;

                d = new Device(new Direct3D(), getMonitor(Form1.monitorIndex), DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
            }
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
            
        }

        public Surface CaptureScreen()
        {
            try
            {
                Surface s = Surface.CreateOffscreenPlain(d, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
                Surface b = Surface.CreateOffscreenPlain(d, (Form1.hyperionWidth), (Form1.hyperionHeight), Format.A8R8G8B8, Pool.Scratch);
                d.GetFrontBufferData(0, s);
                Surface.FromSurface(b, s, Filter.Triangle, 0);
                s.Dispose();
                return b;
            }
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
            return null;
        }

        private int getMonitor(int monitorIndex)
        {
            var monitorArray = SlimDX.Windows.DisplayMonitor.EnumerateMonitors();
            if ((monitorArray.Length -1) >= monitorIndex)
            {
                return (monitorArray[monitorIndex] != null) ? monitorIndex : 0;
            }
            return 0;
        }
    }
}
