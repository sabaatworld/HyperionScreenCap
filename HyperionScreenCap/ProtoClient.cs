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

        public void Init(string hyperionIp = "10.1.2.83", int hyperionProtoPort = 19445, int priority = 10)
        {
            if (_socket.Connected) return;
            Logger("Connecting to Hyperion...");
            _hyperionPriority = priority;
            _socket = new TcpClient
            {
                SendTimeout = 5000,
                ReceiveTimeout = 5000
            };
            _socket.Connect(hyperionIp, hyperionProtoPort);
            _stream = _socket.GetStream();

            Logger("Connected to Hyperion using protobufer!");
        }

        public bool IsConnected()
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
            catch (Exception e)
            {
                Logger("Error occured during isConnected: " + e.Message);
            }

            return false;
        }

        public void SendImage(byte[] pixeldata)
        {
            try
            {
                var imageRequest = ImageRequest.CreateBuilder()
                    .SetImagedata(ByteString.CopyFrom(pixeldata))
                    .SetImageheight(Form1.HyperionHeight)
                    .SetImagewidth(Form1.HyperionWidth)
                    .SetPriority(_hyperionPriority)
                    .SetDuration(Form1.HyperionMessageDuration)
                    .Build();

                var request = HyperionRequest.CreateBuilder()
                    .SetCommand(HyperionRequest.Types.Command.IMAGE)
                    .SetExtension(ImageRequest.ImageRequest_, imageRequest)
                    .Build();

                SendRequest(request);
            }
            catch (Exception e)
            {
                Logger("Error during send image to hyperion: " + e.Message);
            }
        }


        private void SendRequest(HyperionRequest request)
        {
            try
            {
                if (_socket.Connected)
                {
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

                    // Enable reply message if needed (debugging only)
                    //HyperionReply reply = ReceiveReply();
                    //Logger("Reply: " + reply.ToString());
                }
            }
            catch (Exception e)
            {
                Logger("Error during send request to hyperion: " + e.Message);
            }
        }

        private void Logger(string message)
        {
            Notifications.Info(message);
        }
    }
}