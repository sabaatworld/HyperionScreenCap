using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SlimDX.Direct3D9;
using SlimDX.Windows;

namespace HyperionScreenCap
{
    public class DX9ScreenCapture : IDisposable
    {
        private readonly Device _device;
        private Direct3D _direct3D;
        public int MonitorIndex = 0;

        public DX9ScreenCapture(int monitorIndex)
        {
            var presentParams = new PresentParameters
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                PresentationInterval = PresentInterval.Immediate
            };

            MonitorIndex = GetMonitorIndex(monitorIndex);
            _direct3D = new Direct3D();
            _device = new Device(_direct3D, MonitorIndex, DeviceType.Hardware, IntPtr.Zero,
                CreateFlags.SoftwareVertexProcessing, presentParams);
        }

        public Surface CaptureScreen(int width, int height, int monitorIndex)
        {
            using ( var s = Surface.CreateOffscreenPlain(_device, Screen.AllScreens[monitorIndex].Bounds.Width,
                Screen.AllScreens[monitorIndex].Bounds.Height,
                Format.A8R8G8B8, Pool.Scratch) )
            {
                var b = Surface.CreateOffscreenPlain(_device, SettingsManager.HyperionWidth, SettingsManager.HyperionHeight, Format.A8R8G8B8,
                    Pool.Scratch);
                _device.GetFrontBufferData(0, s);
                Surface.FromSurface(b, s, Filter.Triangle, 0);
                return b;
            }
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

        public void Dispose()
        {
            _device?.Dispose();
            _direct3D?.Dispose();
        }
    }
}