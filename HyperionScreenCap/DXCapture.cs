using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SlimDX.Direct3D9;
using SlimDX.Windows;

namespace HyperionScreenCap
{
    public class DxScreenCapture
    {
        private readonly Device _d;
        public int MonitorIndex = 0;
        public DxScreenCapture(int monitorIndex)
        {
            try
            {
                var presentParams = new PresentParameters
                {
                    Windowed = true,
                    SwapEffect = SwapEffect.Discard,
                    PresentationInterval = PresentInterval.Immediate
                };

                MonitorIndex = GetMonitorIndex(monitorIndex);
                _d = new Device(new Direct3D(), MonitorIndex, DeviceType.Hardware, IntPtr.Zero,
                    CreateFlags.SoftwareVertexProcessing, presentParams);
            }
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
        }

        public Surface CaptureScreen(int width, int height, int monitorIndex)
        {
            try
            {
                var s = Surface.CreateOffscreenPlain(_d, Screen.AllScreens[monitorIndex].Bounds.Width,
                    Screen.AllScreens[monitorIndex].Bounds.Height,
                    Format.A8R8G8B8, Pool.Scratch);
                var b = Surface.CreateOffscreenPlain(_d, Settings.HyperionWidth, Settings.HyperionHeight, Format.A8R8G8B8,
                    Pool.Scratch);
                _d.GetFrontBufferData(0, s);
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

        public static int GetMonitorIndex(int monitorIndex)
        {
            var monitorArray = DisplayMonitor.EnumerateMonitors();

            // For anything other than index 0 (first screen) we do a lookup in monitor array
            if (monitorIndex == 0)
            {
                Debug.WriteLine($"Monitor index is 0, skipping lookup and using ==> device: {monitorArray[monitorIndex].DeviceName} | IsPrimary: {monitorArray[monitorIndex].IsPrimary} | Handle: {monitorArray[monitorIndex].Handle}");
                return monitorIndex;
            }

            // If we have only 1 monitor and monitor index is set higher fallback to first monitor
            if (monitorArray.Count() == 1 && monitorIndex > 0)
                return 0;

            if (monitorArray.Any())
            {
                foreach (var monitor in monitorArray)
                {
                    Debug.WriteLine($"Found ==> device: {monitor.DeviceName} | IsPrimary: {monitor.IsPrimary} | Handle: {monitor.Handle}");
                    var monitorShortname = monitor.DeviceName.Replace(@"\\.\DISPLAY", string.Empty);
                    var dmMonitorIndex = 0;
                    bool isdValidMonitorIndex = int.TryParse(monitorShortname, out dmMonitorIndex);
                    if (isdValidMonitorIndex)
                    {
                        if (dmMonitorIndex == monitorIndex)
                        {
                            Debug.WriteLine($"Using ==> device: {monitor.DeviceName} | IsPrimary: {monitor.IsPrimary} | Handle: {monitor.Handle}");
                            return dmMonitorIndex;
                        }
                    }
                }
            }

            return monitorIndex;
        }
    }
}