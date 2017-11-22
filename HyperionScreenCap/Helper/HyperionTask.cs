using HyperionScreenCap.Capture;
using HyperionScreenCap.Config;
using HyperionScreenCap.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HyperionScreenCap.Helper
{
    class HyperionTask // TODO: Remove notifications from here
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(HyperionTask));

        private HyperionTaskConfiguration _configuration;
        private NotificationUtils _notificationUtils;

        private IScreenCapture _screenCapture;
        private List<ProtoClient> _protoClients;
        public bool CaptureEnabled { get; private set; }
        private Thread _captureThread;

        public HyperionTask(HyperionTaskConfiguration configuration, NotificationUtils notificationUtils)
        {
            this._configuration = configuration;
            this._notificationUtils = notificationUtils;
            this._protoClients = new List<ProtoClient>();
        }

        private void InitScreenCapture()
        {
            if ( _screenCapture != null && !_screenCapture.IsDisposed() )
            {
                // Screen capture already initialized. Ignoring request.
                return;
            }
            try
            {
                LOG.Info($"{this}: Initializing screen capture");
                switch ( _configuration.CaptureMethod )
                {
                    case CaptureMethod.DX9:
                        _screenCapture = new DX9ScreenCapture(_configuration.Dx9MonitorIndex, _configuration.Dx9CaptureWidth, _configuration.Dx9CaptureHeight,
                            _configuration.Dx9CaptureInterval);
                        break;

                    case CaptureMethod.DX11:
                        _screenCapture = new DX11ScreenCapture(_configuration.Dx11AdapterIndex, _configuration.Dx11MonitorIndex, _configuration.Dx11ImageScalingFactor,
                            _configuration.Dx11MaxFps, _configuration.Dx11FrameCaptureTimeout);
                        break;

                    default:
                        throw new NotImplementedException($"The capture method {_configuration.CaptureMethod} is not supported yet");
                }
                LOG.Info($"{this}: Screen capture initialized");
            }
            catch ( Exception ex )
            {
                throw new Exception("Failed to initialize screen capture: " + ex.Message, ex);
            }
        }

        private String GetProtoInitFailedMsg(ProtoClient protoClient)
        {
            return $"Failed to connect to Hyperion server using {protoClient}";
        }

        private void InitProtoClients()
        {
            foreach ( HyperionServer server in _configuration.HyperionServers )
            {
                _protoClients.Add(new ProtoClient(server.Host, server.Port, server.Priority, server.MessageDuration));
            }
        }

        private void DisposeProtoClients()
        {
            foreach ( ProtoClient protoClient in _protoClients )
            {
                protoClient?.Dispose();
            }
        }

        private void ConnectProtoClients()
        {
            foreach ( ProtoClient protoClient in _protoClients )
            {
                if ( protoClient.IsConnected() )
                {
                    // Proto client already initialized. Ignoring request.
                    return;
                }
                try
                {
                    LOG.Info($"{this}: Connecting {protoClient}");
                    protoClient?.Dispose();
                    // TODO: check for memory leak in protoClient
                    protoClient.Connect();
                    // Double checking since sometimes exceptions are not thrown even if connection fails
                    if ( protoClient.IsConnected() )
                    {
                        LOG.Info($"{this}: {protoClient} connected");
                        _notificationUtils.Info($"Connected to Hyperion server using {protoClient}!");
                    }
                    else
                        throw new Exception(GetProtoInitFailedMsg(protoClient));
                }
                catch ( Exception ex )
                {
                    throw new Exception(GetProtoInitFailedMsg(protoClient), ex);
                }
            }
        }

        private void TransmitNextFrame()
        {
            foreach ( ProtoClient protoClient in _protoClients )
            {
                try
                {
                    byte[] imageData = _screenCapture.Capture();
                    protoClient.SendImageToServer(imageData, _screenCapture.CaptureWidth, _screenCapture.CaptureHeight);

                    // Uncomment the following to enable debugging
                    // MiscUtils.SaveRGBArrayToImageFile(imageData, _screenCapture.CaptureWidth, _screenCapture.CaptureHeight, AppConstants.DEBUG_IMAGE_FILE_NAME);
                }
                catch ( Exception ex )
                {
                    throw new Exception("Error occured while sending image to server: " + ex.Message, ex);
                }
            }
        }

        private void StartCapture()
        {
            InitProtoClients();
            int captureAttempt = 1;
            while ( CaptureEnabled )
            {
                try // This block will help retry capture before giving up
                {
                    InitScreenCapture();
                    ConnectProtoClients();
                    TransmitNextFrame();
                    _screenCapture.DelayNextCapture();
                    captureAttempt = 1; // Reset attempt count
                }
                catch ( Exception ex )
                {
                    LOG.Error($"{this}: Exception in screen capture attempt: {captureAttempt}", ex);
                    if ( captureAttempt > AppConstants.REINIT_CAPTURE_AFTER_ATTEMPTS )
                    {
                        // After a few attempt, try disposing screen capture object as well
                        _screenCapture?.Dispose();
                        LOG.Info($"{this}: Will re-initialize screen capture on retry");
                    }
                    if ( ++captureAttempt == AppConstants.MAX_CAPTURE_ATTEMPTS )
                    {
                        LOG.Error($"{this}: Max screen capture attempts reached. Giving up.");
                        _notificationUtils.Error(ex.Message);
                        CaptureEnabled = false;
                    }
                    else
                    {
                        LOG.Info($"{this}: Waiting before next screen capture attempt");
                        Thread.Sleep(AppConstants.CAPTURE_FAILED_COOLDOWN_MILLIS);
                    }
                }
            }
        }

        private void TryStartCapture()
        {
            CaptureEnabled = true;
            try // Properly dispose everything object when turning off capture
            {
                StartCapture();
            }
            finally
            {
                _screenCapture?.Dispose();
                DisposeProtoClients();
            }
            LOG.Info($"{this}: Screen Capture finished");
        }

        public void EnableCapture()
        {
            LOG.Info($"{this}: Enabling screen capture");
            _captureThread = new Thread(TryStartCapture) { IsBackground = true };
            _captureThread.Start();
        }

        public void DisableCapture()
        {
            LOG.Info($"{this}: Disabling screen capture");
            CaptureEnabled = false;
        }

        public override String ToString()
        {
            return $"HyperionTask[ConfigurationId: {_configuration.Id}]";
        }
    }
}
