using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SlimDX.Direct3D9;
using SlimDX.Windows;
using HyperionScreenCap.Capture;
using SlimDX;
using System.Threading;

namespace HyperionScreenCap
{
    public class DX9ScreenCapture : IScreenCapture
    {
        private readonly Device _device;
        private Direct3D _direct3D;
        private int _monitorIndex;
        private int _captureInterval;
        private bool _disposed;

        public int CaptureWidth { get; }
        public int CaptureHeight { get; }

        public DX9ScreenCapture(int monitorIndex, int captureWidth, int captureHeight, int captureInterval)
        {
            var presentParams = new PresentParameters
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                PresentationInterval = PresentInterval.Immediate
            };

            _monitorIndex = GetMonitorIndex(monitorIndex);
            _direct3D = new Direct3D();
            _device = new Device(_direct3D, _monitorIndex, DeviceType.Hardware, IntPtr.Zero,
                CreateFlags.SoftwareVertexProcessing, presentParams);
            CaptureWidth = captureHeight;
            CaptureHeight = captureHeight;
            _captureInterval = captureInterval;
            _disposed = false;
        }

        public byte[] Capture()
        {
            byte[] imageToSend;
            using ( var s = GetCaptureSurface() )
            {
                var dr = s.LockRectangle(LockFlags.None);
                using ( var ds = dr.Data )
                {
                    imageToSend = RemoveAlpha(ds);
                }
                s.UnlockRectangle();
            }
            return imageToSend;
        }

        private Surface GetCaptureSurface()
        {
            using ( var s = Surface.CreateOffscreenPlain(_device, Screen.AllScreens[_monitorIndex].Bounds.Width,
                Screen.AllScreens[_monitorIndex].Bounds.Height,
                Format.A8R8G8B8, Pool.Scratch) )
            {
                var b = Surface.CreateOffscreenPlain(_device, CaptureWidth, CaptureHeight, Format.A8R8G8B8, Pool.Scratch);
                _device.GetFrontBufferData(0, s);
                Surface.FromSurface(b, s, Filter.Triangle, 0);
                return b;
            }
        }

        private static byte[] RemoveAlpha(DataStream ia)
        {
            var newImage = new byte[(ia.Length * 3 / 4)];
            int counter = 0;
            while ( ia.Position < ia.Length )
            {
                var a = new byte[4];
                ia.Read(a, 0, 4);
                newImage[counter] = (a[2]);
                counter++;
                newImage[counter] = (a[1]);
                counter++;
                newImage[counter] = (a[0]);
                counter++;
            }
            return newImage;
        }

        private static int GetMonitorIndex(int monitorIndex)
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

        public void DelayNextCapture()
        {
            if ( _captureInterval > 0 )
            {
                Thread.Sleep(_captureInterval);
            }
        }

        public void Dispose()
        {
            _device?.Dispose();
            _direct3D?.Dispose();
            _disposed = true;
        }

        public bool IsDisposed()
        {
            return _disposed;
        }
    }
}