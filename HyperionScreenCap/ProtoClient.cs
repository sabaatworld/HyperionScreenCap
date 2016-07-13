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

        public static void SendImage(byte[] pixeldataRaw)
        {
            var stream = new MemoryStream(pixeldataRaw);
            var reader = new BinaryReader(stream);

            stream.Position = 0; // ensure that what start at the beginning of the stream. 
            reader.ReadBytes(14); // skip bitmap file info header
            reader.ReadBytes(4 + 4 + 4 + 2 + 2 + 4 + 4 + 4 + 4 + 4 + 4);

            var rgbL = (int) (stream.Length - stream.Position);
            var rgb = rgbL/(64*64);

            var pixelData = reader.ReadBytes((int) (stream.Length - stream.Position));

            var h1PixelData = new byte[64*rgb];
            var h2PixelData = new byte[64*rgb];

            // We need to flip the image horizontally.
            // Because after reading the bytes into the bytearray with BinaryReader the image is upside down (bmp characteristic).
            int i;
            for (i = 0; i < ((64/2) - 1); i++)
            {
                Array.Copy(pixelData, i*64*rgb, h1PixelData, 0, 64*rgb);
                Array.Copy(pixelData, (64 - i - 1)*64*rgb, h2PixelData, 0, 64*rgb);
                Array.Copy(h1PixelData, 0, pixelData, (64 - i - 1)*64*rgb, 64*rgb);
                Array.Copy(h2PixelData, 0, pixelData, i*64*rgb, 64*rgb);
            }

            try
            {
                // Hyperion expects the bytestring to be the size of 3*width*height.
                // So 3 bytes per pixel, as in RGB.
                // Given pixeldata however is 4 bytes per pixel, as in RGBA.
                // So we need to remove the last byte per pixel.
                var newpixeldata = new byte[64*64*3];
                var x = 0;
                var i2 = 0;
                while (i2 <= (newpixeldata.GetLength(0) - 2))
                {
                    newpixeldata[i2] = pixelData[i2 + x + 2];
                    newpixeldata[i2 + 1] = pixelData[i2 + x + 1];
                    newpixeldata[i2 + 2] = pixelData[i2 + x];
                    i2 += 3;
                    x++;
                }

                SendImageToServer(newpixeldata);
            }
            catch (Exception ex)
            {
                Notifications.Error($"Failed to prepare image for Hyperion server.{ex.Message}");
            }
        }

        private static void SendImageToServer(byte[] pixeldata)
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

                // Enable reply message if needed (debugging only)
                //HyperionReply reply = ReceiveReply();
                //Logger("Reply: " + reply.ToString());
            }
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
        }
    }
}