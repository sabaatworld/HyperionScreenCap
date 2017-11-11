using System;
using System.IO;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using proto;
using System.Threading;
using HyperionScreenCap.Config;
using log4net;

namespace HyperionScreenCap
{
    class ProtoClient : IDisposable
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ProtoClient));

        public bool Initialized { get; private set; }

        private string _host;
        private int _port;
        private int _priority;

        private bool _initLock;
        private TcpClient _socket;
        private Stream _stream;

        public ProtoClient(string host, int port, int priority)
        {
            _host = host;
            _port = port;
            _priority = priority;
            Init();
        }

        private void Init()
        {
            if ( _initLock || IsConnected() )
            {
                LOG.Info($"{this} already initialized. Skipping request.");
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
            LOG.Info($"{this} initialized");
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

        public void SendImageToServer(byte[] pixeldata, int width, int height)
        {
            var imageRequest = ImageRequest.CreateBuilder()
                .SetImagedata(ByteString.CopyFrom(pixeldata))
                .SetImageheight(height)
                .SetImagewidth(width)
                .SetPriority(_priority)
                .SetDuration(SettingsManager.HyperionMessageDuration)
                .Build();

            var request = HyperionRequest.CreateBuilder()
                .SetCommand(HyperionRequest.Types.Command.IMAGE)
                .SetExtension(ImageRequest.ImageRequest_, imageRequest)
                .Build();

            SendRequest(request);
        }

        public void TryClearPriority()
        {
            try
            {
                LOG.Info($"Clearing Hyperion priority for {this}");
                ClearPriority();
                Thread.Sleep(25);
                ClearPriority();
                LOG.Info($"Hyperion priority cleared for {this}");
            }
            catch ( Exception ex )
            {
                LOG.Error($"Failed to clear Hyperion priority for {this}", ex);
            }
        }

        private void ClearPriority()
        {
            if ( !IsConnected() )
            {
                return;
            }

            var clearRequest = ClearRequest.CreateBuilder()
                .SetPriority(_priority)
                .Build();

            var request = HyperionRequest.CreateBuilder()
                .SetCommand(HyperionRequest.Types.Command.CLEAR)
                .SetExtension(ClearRequest.ClearRequest_, clearRequest)
                .Build();

            SendRequest(request);
        }

        private void SendRequest(IMessageLite request)
        {
            if ( !_socket.Connected ) return;
            var size = request.SerializedSize;
            var header = new byte[4];
            header[0] = (byte) ((size >> 24) & 0xFF);
            header[1] = (byte) ((size >> 16) & 0xFF);
            header[2] = (byte) ((size >> 8) & 0xFF);
            header[3] = (byte) (size & 0xFF);

            var headerSize = header.Length;
            _stream.Write(header, 0, headerSize);
            request.WriteTo(_stream);
            _stream.Flush();

            // Enable reply message if needed (debugging only).
            //var reply = ReceiveReply();
            //Console.WriteLine($@"Reply: {reply.ToString()}");
        }

        private HyperionReply ReceiveReply()
        {
            Stream input = _socket.GetStream();
            var header = new byte[4];
            input.Read(header, 0, 4);
            var size = (header[0] << 24) | (header[1] << 16) | (header[2] << 8) | (header[3]);
            var data = new byte[size];
            input.Read(data, 0, size);
            var reply = HyperionReply.ParseFrom(data);

            return reply;
        }

        public override String ToString()
        {
            return $"ProtoClient[{_host}:{_port} ({_priority})]";
        }
    }
}