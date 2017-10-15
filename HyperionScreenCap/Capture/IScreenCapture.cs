using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap.Capture
{
    interface IScreenCapture : IDisposable
    {

        int CaptureWidth { get; }
        int CaptureHeight { get; }

        byte[] Capture();

        void DelayNextCapture();

        bool IsDisposed();

    }
}
