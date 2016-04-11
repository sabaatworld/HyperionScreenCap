using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using proto;
using System.IO;
using System.Net.Sockets;

namespace HyperionScreenCap
{
    class ProtoClient
    {

        private static TcpClient Socket = new TcpClient();
        private static Stream Stream;
        private static int hyperionPriority;
        public bool hyperionProtoErrorOccured;

        public void Init(string hyperionIP = "10.1.2.83", int hyperionProtoPort = 19445, int priority = 10)
        {
            if (Socket.Connected == false)
            {
                Logger("Connecting to Hyperion...");
                hyperionPriority = priority;
                Socket = new TcpClient();
                Socket.SendTimeout = 5000;
                Socket.ReceiveTimeout = 5000;
                Socket.Connect(hyperionIP, hyperionProtoPort);
                Stream = Socket.GetStream();

                Logger("Connected to Hyperion using protobufer!");
            }
        }

        public void Disconnect()
        {
            if (Socket != null)
            {
                Socket.Close();
            }
        }

        public bool isConnected()
        {
            try
            {
                if (Socket == null)
                {
                    return false;
                }
                if(Socket.Connected)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                Logger("Error occured during isConnected: " + e.Message);
            }

            return false;
        }

        public void ClearPriority(int priority)
        {
            try
            {
                if (!isConnected())
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
            catch (Exception e)
            {
                Logger("Error occured during clear priority: " + e.Message);
                hyperionProtoErrorOccured = true;
            }
        }
        public void WriteImage(byte[] pixeldataRaw)
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

                SendImage(newpixeldata, null);
            }
            catch (Exception e)
            {
                Logger("Error occured during write image: " + e.Message);
                hyperionProtoErrorOccured = true;
            }
        }

        private void SendImage(byte[] pixeldata, byte[] bmiInfoHeader)
        {
            try
            {
                ImageRequest imageRequest = ImageRequest.CreateBuilder()
                  .SetImagedata(Google.ProtocolBuffers.ByteString.CopyFrom(pixeldata))
                  .SetImageheight(64)
                  .SetImagewidth(64)
                  .SetPriority(hyperionPriority)
                  .SetDuration(-1)
                  .Build();

                HyperionRequest request = HyperionRequest.CreateBuilder()
                  .SetCommand(HyperionRequest.Types.Command.IMAGE)
                  .SetExtension(ImageRequest.ImageRequest_, imageRequest)
                  .Build();

                SendRequest(request);
            }
            catch (Exception e)
            {
                Logger("Error during send image to hyperion: " + e.Message);
                hyperionProtoErrorOccured = true;
            }
        }


        public void SendColor(int red, int green, int blue)
        {
            if (!Socket.Connected)
            {
                return;
            }

            ColorRequest colorRequest = ColorRequest.CreateBuilder()
              .SetRgbColor((red * 256 * 256) + (green * 256) + blue)
              .SetPriority(hyperionPriority)
              .SetDuration(-1)
              .Build();

            HyperionRequest request = HyperionRequest.CreateBuilder()
              .SetCommand(HyperionRequest.Types.Command.COLOR)
              .SetExtension(ColorRequest.ColorRequest_, colorRequest)
              .Build();

            SendRequest(request);
        }

        private void SendRequest(HyperionRequest request)
        {
            try
            {

                if (Socket.Connected)
                {
                    int size = request.SerializedSize;
                    Byte[] header = new byte[4];
                    header[0] = (byte)((size >> 24) & 0xFF);
                    header[1] = (byte)((size >> 16) & 0xFF);
                    header[2] = (byte)((size >> 8) & 0xFF);
                    header[3] = (byte)((size) & 0xFF);

                    int headerSize = header.Count();
                    Stream.Write(header, 0, headerSize);
                    request.WriteTo(Stream);
                    Stream.Flush();

                    // Enable reply message if needed (debugging only)
                    //HyperionReply reply = ReceiveReply();
                    //Logger("Reply: " + reply.ToString());
                }
            }
            catch (Exception e)
            {
                Logger("Error during send request to hyperion: " + e.Message);
                hyperionProtoErrorOccured = true;
            }
        }

        private HyperionReply ReceiveReply()
        {
            try
            {
                Stream input = Socket.GetStream();
                byte[] header = new byte[4];
                input.Read(header, 0, 4);
                int size = (header[0] << 24) | (header[1] << 16) | (header[2] << 8) | (header[3]);
                byte[] data = new byte[size];
                input.Read(data, 0, size);
                HyperionReply reply = HyperionReply.ParseFrom(data);

                return reply;
            }
            catch (Exception e)
            {
                Logger("Error during reeceive hyperion reply: " + e.Message);
                hyperionProtoErrorOccured = true;
                return null;
            }
        }

        private void Logger(string message)
        {
            // TO DO: 
            //Optional: connect to notification system
        }
    }
}
