using System;
using System.IO;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using proto;
using System.Threading;
using HyperionScreenCap.Config;

namespace HyperionScreenCap
{
    internal static class ProtoClient
    {
        public static bool Initialized { get; private set; }

        private static TcpClient _socket;
        private static Stream _stream;
        private static int _hyperionPriority;
        private static bool _initLock;

        public static void Init(string hyperionIp, int hyperionProtoPort = 19445, int priority = 10)
        {
            if ( _initLock || IsConnected() ) {
                return;
            }

            _initLock = true;
            _hyperionPriority = priority;
            _socket = new TcpClient
            {
                SendTimeout = AppConstants.PROTO_CLIENT_SOCKET_TIMEOUT,
                ReceiveTimeout = AppConstants.PROTO_CLIENT_SOCKET_TIMEOUT
            };

            try
            {
                _socket.Connect(hyperionIp, hyperionProtoPort);
                _stream = _socket.GetStream();
            }
            finally
            {
                _initLock = false;
            }
            Initialized = true;
        }

        public static bool IsConnected()
        {
            if (_socket == null)
            {
                return false;
            }

            return _socket.Connected;
        }

        public static void Disconnect()
        {
            _stream?.Dispose();
            _socket?.Close();
            _socket = null;
            Initialized = false;
        }

        public static void SendImageToServer(byte[] pixeldata, int width, int height)
        {
            var imageRequest = ImageRequest.CreateBuilder()
                .SetImagedata(ByteString.CopyFrom(pixeldata))
                .SetImageheight(height)
                .SetImagewidth(width)
                .SetPriority(_hyperionPriority)
                .SetDuration(Settings.HyperionMessageDuration)
                .Build();

            var request = HyperionRequest.CreateBuilder()
                .SetCommand(HyperionRequest.Types.Command.IMAGE)
                .SetExtension(ImageRequest.ImageRequest_, imageRequest)
                .Build();

            SendRequest(request);
        }

        public static void TryClearPriority(int priority)
        {
            try
            {
                ClearPriority(priority);
                Thread.Sleep(50);
                ClearPriority(priority);
            } catch (Exception ex)
            {
                Notifications.Error($"Failed to clear priority. {ex.Message}");
            }
        }

        public static void ClearPriority(int priority)
        {
            if ( !IsConnected() )
            {
                return;
            }

            var clearRequest = ClearRequest.CreateBuilder()
                .SetPriority(priority)
                .Build();

            var request = HyperionRequest.CreateBuilder()
                .SetCommand(HyperionRequest.Types.Command.CLEAR)
                .SetExtension(ClearRequest.ClearRequest_, clearRequest)
                .Build();

            SendRequest(request);
        }

        private static void SendRequest(IMessageLite request)
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

        private static HyperionReply ReceiveReply()
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
    }
}