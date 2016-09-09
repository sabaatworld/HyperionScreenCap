using System;
using System.IO;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using proto;

namespace HyperionScreenCap
{
    internal class ProtoClient
    {
        private static TcpClient _socket = new TcpClient();
        private static Stream _stream;
        private static int _hyperionPriority;
        private static bool _initLock;

        public static void Init(string hyperionIp, int hyperionProtoPort = 19445, int priority = 10)
        {
            try
            {
                if (_socket.Connected || _initLock) return;
                _initLock = true;
                _hyperionPriority = priority;
                _socket = new TcpClient
                {
                    SendTimeout = 5000,
                    ReceiveTimeout = 5000
                };
                _socket.Connect(hyperionIp, hyperionProtoPort);
                _stream = _socket.GetStream();
                _initLock = false;
            }
            catch (Exception ex)
            {
                Notifications.Error($"Failed to connect to Hyperion.{ex.Message}");
                _initLock = false;
            }
        }

        public static bool IsConnected()
        {
            try
            {
                if (_socket == null)
                {
                    return false;
                }
                if (_socket.Connected)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
            return false;
        }

        public static void Disconnect()
        {
            _socket?.Close();
        }

        public static void SendImageToServer(byte[] pixeldata)
        {
            try
            {
                var imageRequest = ImageRequest.CreateBuilder()
                    .SetImagedata(ByteString.CopyFrom(pixeldata))
                    .SetImageheight(Settings.HyperionHeight)
                    .SetImagewidth(Settings.HyperionWidth)
                    .SetPriority(_hyperionPriority)
                    .SetDuration(Settings.HyperionMessageDuration)
                    .Build();

                var request = HyperionRequest.CreateBuilder()
                    .SetCommand(HyperionRequest.Types.Command.IMAGE)
                    .SetExtension(ImageRequest.ImageRequest_, imageRequest)
                    .Build();

                SendRequest(request);
            }
            catch (Exception ex)
            {
                Notifications.Error($"Failed to send image to server.{ex.Message}");
            }
        }

        public static void ClearPriority(int priority)
        {
            try
            {
                if (!IsConnected())
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
            catch (Exception ex)
            {
                Notifications.Error($"Failed to clear priority.{ex.Message}");
            }
        }

        private static void SendRequest(IMessageLite request)
        {
            try
            {
                if (!_socket.Connected) return;
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
            catch (Exception ex)
            {
                Notifications.Error($"Failed to send request.{ex.Message}");
            }
        }
        private static HyperionReply ReceiveReply()
        {
            try
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
            catch (Exception e)
            {
                Notifications.Error("Error during reeceive hyperion reply: " + e.Message);
                return null;
            }
        }
    }
}