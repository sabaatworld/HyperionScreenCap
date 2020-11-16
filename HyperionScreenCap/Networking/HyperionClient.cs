using System;
using System.IO;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using proto;
using System.Threading;
using HyperionScreenCap.Config;
using log4net;

namespace HyperionScreenCap.Networking
{
    abstract class HyperionClient : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(HyperionClient));

        public bool Initialized { get; private set; }

        protected string _host;
        protected int _port;
        protected int _priority;
        protected int _messageDuration;

        private bool _initLock;
        private TcpClient _socket;
        protected Stream _stream;

        public HyperionClient(string host, int port, int priority, int messageDuration)
        {
            _host = host;
            _port = port;
            _priority = priority;
            _messageDuration = messageDuration;
        }

        public void Connect()
        {
            if ( _initLock || IsConnected() )
            {
                LOG.Info($"{this} already connected. Skipping request.");
                return;
            }
            _initLock = true;
            LOG.Info($"{this} Init lock set");

            _socket = new TcpClient
            {
                SendTimeout = AppConstants.PROTO_CLIENT_SOCKET_TIMEOUT,
                ReceiveTimeout = AppConstants.PROTO_CLIENT_SOCKET_TIMEOUT
            };

            try
            {
                _socket.Connect(_host, _port);
                _stream = _socket.GetStream();
            }
            finally
            {
                _initLock = false;
                LOG.Info($"{this} Init lock unset");
            }
            Initialized = true;
        }

        public bool IsConnected()
        {
            if ( _socket == null )
            {
                return false;
            }

            return _socket.Connected;
        }

        public void Dispose()
        {
            LOG.Info($"Disconnecting {this}");
            TryClearPriority(); // TODO : this can cause thread blocking issues
            _stream?.Dispose();
            _socket?.Close();
            _socket = null;
            Initialized = false;
            LOG.Info($"{this} disconnected");
        }

        public void SendImageData(byte[] pixeldata, int width, int height)
        {
            if (IsConnected()) { SendImageDataMessage(pixeldata, width, height); };
        }

        private void TryClearPriority()
        {
            try
            {
                LOG.Info($"Clearing Hyperion priority for {this}");
                if (IsConnected()) { SendClearPriorityMessage(); }
                Thread.Sleep(25);
                if (IsConnected()) { SendClearPriorityMessage(); }
                LOG.Info($"Hyperion priority cleared for {this}");
            }
            catch ( Exception ex )
            {
                LOG.Error($"Failed to clear Hyperion priority for {this}", ex);
            }
        }

        protected void sendMessageSize(int size)
        {
            var header = new byte[4];
            header[0] = (byte)((size >> 24) & 0xFF);
            header[1] = (byte)((size >> 16) & 0xFF);
            header[2] = (byte)((size >> 8) & 0xFF);
            header[3] = (byte)(size & 0xFF);
            _stream.Write(header, 0, header.Length);
        }

        protected abstract void SendImageDataMessage(byte[] pixeldata, int width, int height);

        protected abstract void SendClearPriorityMessage();

        public abstract override String ToString();
    }
}
