using System;
using System.Windows.Forms;
using SlimDX.Direct3D9;
using SlimDX.Windows;

namespace HyperionScreenCap
{
  public class DxScreenCapture
  {
    private readonly Device _d;

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

        _d = new Device(new Direct3D(), GetMonitor(monitorIndex), DeviceType.Hardware, IntPtr.Zero,
          CreateFlags.SoftwareVertexProcessing, presentParams);
      }
      catch (Exception){
      }

    }

    public Surface CaptureScreen(int width, int height)
    {
      try
      {
        var s = Surface.CreateOffscreenPlain(_d, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,
          Format.A8R8G8B8, Pool.Scratch);
        var b = Surface.CreateOffscreenPlain(_d, (Form1.HyperionWidth), (Form1.HyperionHeight), Format.A8R8G8B8,
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

    private static int GetMonitor(int monitorIndex)
    {
      var monitorArray = DisplayMonitor.EnumerateMonitors();
      if ((monitorArray.Length - 1) >= monitorIndex)
      {
        return (monitorArray[monitorIndex] != null) ? monitorIndex : 0;
      }
      return 0;
    }
  }
}
