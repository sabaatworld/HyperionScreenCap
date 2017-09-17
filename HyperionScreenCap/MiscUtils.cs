using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace HyperionScreenCap
{
    static class MiscUtils
    {

        /// <summary>
        /// Converts an RGB byte array to a PNG image. Can be used for debugging if capture was successful.
        /// </summary>
        /// <param name="rgbData">An array of r-g-b components for each pixel in the image.</param>
        /// <param name="imageWidth">The width of the image.</param>
        /// <param name="imageHeight">The height of the image.</param>
        /// <param name="filename">Name of the imgae file written to disk.</param>
        public static void SaveRGBArrayToImageFile(byte[] rgbData, int imageWidth, int imageHeight, string filename = "rgb_debug.png")
        {
            Bitmap pic = new Bitmap(imageWidth, imageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int i = 0;
            for ( int y = 0; y < imageHeight; y++ )
            {
                for ( int x = 0; x < imageWidth; x++ )
                {
                    Color color = Color.FromArgb(rgbData[i++], rgbData[i++], rgbData[i++]);
                    pic.SetPixel(x, y, color);
                }
            }

            pic.Save(filename);
            pic.Dispose();
        }

    }
}
