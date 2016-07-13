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
        private static bool initLock;

        public void Init(string hyperionIp, int hyperionProtoPort = 19445, int priority = 10)
        {
            try
            {
                if (_socket.Connected || initLock) return;
                initLock = true;
                _hyperionPriority = priority;
                _socket = new TcpClient
                {
                    SendTimeout = 5000,
                    ReceiveTimeout = 5000
                };
                _socket.Connect(hyperionIp, hyperionProtoPort);
                _stream = _socket.GetStream();
                initLock = false;
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to connect to Hyperion." + ex.Message);
                initLock = false;
            }
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
            catch (Exception ex)
            {
                Notifications.Error(ex.Message);
            }
            return false;
        }

        public void Disconnect()
        {
            _socket?.Close();
        }

        public void SendImage(byte[] pixeldataRaw)
        {
            MemoryStream stream = new MemoryStream(pixeldataRaw);
            BinaryReader reader = new BinaryReader(stream);

            stream.Position = 0; // ensure that what start at the beginning of the stream. 
            reader.ReadBytes(14); // skip bitmap file info header
            byte[] bmiInfoHeader = reader.ReadBytes(4 + 4 + 4 + 2 + 2 + 4 + 4 + 4 + 4 + 4 + 4);

            int rgbL = (int)(stream.Length - stream.Position);
            int rgb = (int)(rgbL / (64 * 64));

            byte[] pixelData = reader.ReadBytes((int)(stream.Length - stream.Position));

            byte[] h1pixelData = new byte[64 * rgb];
            byte[] h2pixelData = new byte[64 * rgb];

            // We need to flip the image horizontally.
            // Because after reading the bytes into the bytearray with BinaryReader the image is upside down (bmp characteristic).
            int i;
            for (i = 0; i < ((64 / 2) - 1); i++)
            {
                Array.Copy(pixelData, i * 64 * rgb, h1pixelData, 0, 64 * rgb);
                Array.Copy(pixelData, (64 - i - 1) * 64 * rgb, h2pixelData, 0, 64 * rgb);
                Array.Copy(h1pixelData, 0, pixelData, (64 - i - 1) * 64 * rgb, 64 * rgb);
                Array.Copy(h2pixelData, 0, pixelData, i * 64 * rgb, 64 * rgb);
            }

            try
            {
                // Hyperion expects the bytestring to be the size of 3*width*height.
                // So 3 bytes per pixel, as in RGB.
                // Given pixeldata however is 4 bytes per pixel, as in RGBA.
                // So we need to remove the last byte per pixel.
                byte[] newpixeldata = new byte[64 * 64 * 3];
                int x = 0;
                int i2 = 0;
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
                Notifications.Error("Failed to prepare image for Hyperion server." + ex.Message);
            }
        }

        public void SendImageToServer(byte[] pixeldata)
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
                Notifications.Error("Failed to send image to server." + ex.Message);
            }
        }

        public void ClearPriority(int priority)
        {
            try
            {
                if (!IsConnected())
                {
                    return;
                }

                ClearRequest clearRequest = ClearRequest.CreateBuilder()
                  .SetPriority(priority)
                  .Build();

                HyperionRequest request = HyperionRequest.CreateBuilder()
                  .SetCommand(HyperionRequest.Types.Command.CLEAR)
                  .SetExtension(ClearRequest.ClearRequest_, clearRequest)
                  .Build();

                SendRequest(request);
            }
            catch (Exception ex)
            {
                Notifications.Error("Failed to clear priority." + ex.Message);
            }
        }

        private static void SendRequest(IMessageLite request)
        {
            try
            {
                if (!_socket.Connected) return;
                var size = request.SerializedSize;
                var header = new byte[4];
                header[0] = (byte)((size >> 24) & 0xFF);
                header[1] = (byte)((size >> 16) & 0xFF);
                header[2] = (byte)((size >> 8) & 0xFF);
                header[3] = (byte)(size & 0xFF);

                var headerSize = header.Length;
                _stream.Write(header, 0, headerSize);
                request.WriteTo(_stream);
                _stream.Flush();

                // Enable reply message if needed (debugging only)
                //HyperionReply reply = ReceiveReply();
                //Logger("Reply: " + reply.ToString());
            }
            catch (Exception)
            {
            }
        }
    }
}