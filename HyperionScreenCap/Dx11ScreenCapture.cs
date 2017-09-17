using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace HyperionScreenCap
{
    class DX11ScreenCapture : IDisposable
    {
        private const int ACQUIRE_FRAME_TIMEOUT = 1000; //TODO make timeout configurable

        private const int REPEAT_TRANSMISSION_EXPLICIT_DELAY = 10;

        private Factory1 _factory;
        private Adapter _adapter;
        private Output _output;
        private Output1 _output1;
        private SharpDX.Direct3D11.Device _device;
        private Texture2D _stagingTexture;
        private Texture2D _smallerTexture;
        private ShaderResourceView _smallerTextureView;
        private OutputDuplication _duplicatedOutput;
        private int _scalingFactorLog2;
        private int _width;
        private int _height;
        public int CaptureWidth { get; private set; }
        public int CaptureHeight { get; private set; }

        private FixedSizeConcurrentQueue<SharpDX.DXGI.Resource> _frameAcquisitionQueue;
        private int _frameAcquisitionSleepTime;
        private bool _continueFrameAcquisition;
        private SharpDXException _frameAcquisitionException;

        private long _lastScreenUpdate;
        private byte[] _capturedBytes;

        public DX11ScreenCapture(int adapterIndex = 0, int monitorIndex = 0, int scalingFactor = 2, int frameAcquisitionFrequency = 30)
        {
            int mipLevels;
            if ( scalingFactor == 1 )
                mipLevels = 1;
            else if ( scalingFactor > 0 && scalingFactor % 2 == 0 )
            {
                /// Mip level for a scaling factor other than one is computed as follows:
                /// 2^n = 2 + n - 1 where LHS is the scaling factor and RHS is the MipLevels value.
                _scalingFactorLog2 = Convert.ToInt32(Math.Log(scalingFactor, 2));
                mipLevels = 2 + _scalingFactorLog2 - 1;
            }
            else
                throw new Exception("Invalid scaling factor. Allowed valued are 1, 2, 4, etc.");

            // Create DXGI Factory1
            _factory = new Factory1();
            _adapter = _factory.GetAdapter1(adapterIndex);

            // Create device from Adapter
            _device = new SharpDX.Direct3D11.Device(_adapter);

            // Get DXGI.Output
            _output = _adapter.GetOutput(monitorIndex);
            _output1 = _output.QueryInterface<Output1>();

            // Width/Height of desktop to capture
            _width = _output.Description.DesktopBounds.Right;
            _height = _output.Description.DesktopBounds.Bottom;

            CaptureWidth = _width / scalingFactor;
            CaptureHeight = _height / scalingFactor;

            // Create Staging texture CPU-accessible
            var stagingTextureDesc = new Texture2DDescription
            {
                CpuAccessFlags = CpuAccessFlags.Read,
                BindFlags = BindFlags.None,
                Format = Format.B8G8R8A8_UNorm,
                Width = CaptureWidth,
                Height = CaptureHeight,
                OptionFlags = ResourceOptionFlags.None,
                MipLevels = 1,
                ArraySize = 1,
                SampleDescription = { Count = 1, Quality = 0 },
                Usage = ResourceUsage.Staging
            };
            _stagingTexture = new Texture2D(_device, stagingTextureDesc);

            // Create smaller texture to downscale the captured image
            var smallerTextureDesc = new Texture2DDescription
            {
                CpuAccessFlags = CpuAccessFlags.None,
                BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
                Format = Format.B8G8R8A8_UNorm,
                Width = _width,
                Height = _height,
                OptionFlags = ResourceOptionFlags.GenerateMipMaps,
                MipLevels = mipLevels,
                ArraySize = 1,
                SampleDescription = { Count = 1, Quality = 0 },
                Usage = ResourceUsage.Default
            };
            _smallerTexture = new Texture2D(_device, smallerTextureDesc);
            _smallerTextureView = new ShaderResourceView(_device, _smallerTexture);

            // Duplicate the output
            _duplicatedOutput = _output1.DuplicateOutput(_device);

            // Initialize a queue onto which acquired frames will be pushed
            _frameAcquisitionQueue = new FixedSizeConcurrentQueue<SharpDX.DXGI.Resource>(1);
            _frameAcquisitionSleepTime = 1 / frameAcquisitionFrequency;
        }

        public void StartFrameAcquisition()
        {
            _continueFrameAcquisition = true;

            var thread = new Thread(AcquireFrames);
            thread.Start();
        }

        public void StopFrameAcquisition()
        {
            _continueFrameAcquisition = false;
            Thread.Sleep(_frameAcquisitionSleepTime + ACQUIRE_FRAME_TIMEOUT + 10); // Wait for thread to complete
            _frameAcquisitionQueue.Enqueue(null); // Force dispose object in the queue
        }

        private void AcquireFrames()
        {
            while ( _continueFrameAcquisition )
            {
                SharpDX.DXGI.Resource screenResource = null;
                OutputDuplicateFrameInformation duplicateFrameInformation;

                // Try to get duplicated frame within given time
                //TODO try catch
                try
                {
                    _duplicatedOutput.AcquireNextFrame(ACQUIRE_FRAME_TIMEOUT, out duplicateFrameInformation, out screenResource);
                    _frameAcquisitionException = null;
                }
                catch ( SharpDXException ex )
                {
                    _frameAcquisitionException = ex;
                }
                finally
                {
                    _duplicatedOutput.ReleaseFrame();
                }
                _frameAcquisitionQueue.Enqueue(screenResource);

                Thread.Sleep(_frameAcquisitionSleepTime);
            }
        }

        public byte[] GetFrame()
        {
            // TODO Check for acquire exception
            // Handle screenResouce null cause of queue empty

            SharpDX.DXGI.Resource screenResource;

            Thread.Sleep(_frameAcquisitionSleepTime); //TODO remove
            bool frameAvailable = _frameAcquisitionQueue.TryDequeue(out screenResource);

            if ( !frameAvailable )
                return new byte[0];

            // Check if scaling is used
            if ( CaptureWidth != _width )
            {
                // Copy resource to Texture2D resource for generating mipmaps
                using ( var screenTexture2D = screenResource.QueryInterface<Texture2D>() )
                    _device.ImmediateContext.CopySubresourceRegion(screenTexture2D, 0, null, _smallerTexture, 0);

                // Generates the mipmap of the screen
                _device.ImmediateContext.GenerateMips(_smallerTextureView);

                // Copy the mipmap of smallerTexture (size/ scalingFactor) to the staging texture: 1 for /2, 2 for /4...etc
                // Staging texture is meant to be CPU accessible
                _device.ImmediateContext.CopySubresourceRegion(_smallerTexture, _scalingFactorLog2, null, _stagingTexture, 0);
            }
            else
            {
                // Copy resource into memory that can be accessed by the CPU
                using ( var screenTexture2D = screenResource.QueryInterface<Texture2D>() )
                    _device.ImmediateContext.CopyResource(screenTexture2D, _stagingTexture);
            }

            // Get the desktop capture texture
            var mapSource = _device.ImmediateContext.MapSubresource(_stagingTexture, 0, MapMode.Read, SharpDX.Direct3D11.MapFlags.None);
            _capturedBytes = ToRGBArray(mapSource);
            return _capturedBytes;
        }

        /// <summary>
        /// Reads from the memory locations pointed to by the DataBox and saves it into a byte array
        /// ignoring the alpha component of each pixel.
        /// </summary>
        /// <param name="mapSource"></param>
        /// <returns></returns>
        private byte[] ToRGBArray(DataBox mapSource)
        {
            var sourcePtr = mapSource.DataPointer;
            byte[] bytes = new byte[CaptureWidth * 3 * CaptureHeight];
            int byteIndex = 0;
            for ( int y = 0; y < CaptureHeight; y++ )
            {
                Int32[] rowData = new Int32[CaptureWidth];
                Marshal.Copy(sourcePtr, rowData, 0, CaptureWidth);

                foreach ( Int32 pixelData in rowData )
                {
                    byte[] values = BitConverter.GetBytes(pixelData);
                    if ( BitConverter.IsLittleEndian )
                    {
                        // Byte order : bgra
                        bytes[byteIndex++] = values[2];
                        bytes[byteIndex++] = values[1];
                        bytes[byteIndex++] = values[0];
                    }
                    else
                    {
                        // Byte order : argb
                        bytes[byteIndex++] = values[1];
                        bytes[byteIndex++] = values[2];
                        bytes[byteIndex++] = values[3];
                    }
                }

                sourcePtr = IntPtr.Add(sourcePtr, mapSource.RowPitch);
            }
            return bytes;
        }

        public void Dispose()
        {
            if ( _continueFrameAcquisition )
                StopFrameAcquisition();

            _duplicatedOutput?.Dispose();
            _output1?.Dispose();
            _output?.Dispose();
            _stagingTexture?.Dispose();
            _smallerTexture?.Dispose();
            _smallerTextureView?.Dispose();
            _device?.Dispose();
            _adapter?.Dispose();
            _factory?.Dispose();
            _capturedBytes = null;
        }
    }
}
