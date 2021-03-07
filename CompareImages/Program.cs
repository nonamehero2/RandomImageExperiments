using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CompareImages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Image Image01 = Image.FromFile("image (1).jpg");
            Image Image02 = Image.FromFile("image (2).jpg");
            Image Image03 = Image.FromFile("image (3).jpg");
            Image Image04 = Image.FromFile("image (4).jpg");
            //Image Image03 = Image.FromFile("image Comb.jpg");
            Rectangle screenSize = SystemInformation.VirtualScreen;

            Bitmap bitmap01 = new Bitmap(Image01, 1920, 1080);
            Bitmap bitmap02 = new Bitmap(Image02, 1920, 1080);
            Bitmap bitmap11 = new Bitmap(Image03, 1920, 1080);
            Bitmap bitmap12 = new Bitmap(Image04, 1920, 1080);
            Bitmap bitmap03 = new Bitmap(1920 * 2, 1080 * 2);


            Color pixelColor01 = new Color();
            //Color pixelColor02 = new Color();
            //Color pixelColor03 = new Color();

            for (int x = 0; x < bitmap01.Width; x++)
            {
                for (int y = 0; y < bitmap01.Height; y++)
                {
                    pixelColor01 = bitmap01.GetPixel(x, y);
                    bitmap03.SetPixel(x, y, pixelColor01);
                }
            }
            bitmap01.Dispose();


            for (int x = 0; x < bitmap02.Width; x++)
            {
                for (int y = 0; y < bitmap02.Height; y++)
                {
                    pixelColor01 = bitmap02.GetPixel(x, y);
                    bitmap03.SetPixel(1920 + x, 1080 + y, pixelColor01);
                }
            }

            for (int x = 0; x < 1920; x++)
            {
                for (int y = 0; y < 1080; y++)
                {
                    pixelColor01 = bitmap11.GetPixel(x, y);
                    bitmap03.SetPixel(1920 + x, y, pixelColor01);
                }
            }

            for (int x = 0; x < 1920; x++)
            {
                for (int y = 0; y < 1080; y++)
                {
                    pixelColor01 = bitmap12.GetPixel(x, y);
                    bitmap03.SetPixel(x, 1080 + y, pixelColor01);
                }
            }







            //int[] sum = { 0, 0, 0 };
            ////0 is R, 1 is B, 2 is G
            //if (bitmap01.Height == bitmap02.Height && bitmap01.Width == bitmap02.Width)
            //{
            //    Console.WriteLine(bitmap01.Height);
            //    Console.WriteLine(bitmap01.Width);
            //    for (int x = 0; x < bitmap01.Width; x++)
            //    {
            //        for (int y = 0; y < bitmap01.Height; y++)
            //        {
            //            pixelColor01 = bitmap01.GetPixel(x, y);
            //            pixelColor02 = bitmap02.GetPixel(x, y);

            //            int red, blue, green;
            //            red = (pixelColor01.R + pixelColor02.R) / 2;
            //            blue = (pixelColor01.B + pixelColor02.B) / 2;
            //            green = (pixelColor01.G + pixelColor02.G) / 2;

            //            if (red < 0)
            //            {
            //                red = red + 255;
            //            }
            //            if (blue < 0)
            //            {
            //                blue = blue + 255;
            //            }
            //            if (green < 0)
            //            {
            //                green = green + 255;
            //            }

            //            sum[0] = (sum[0] + red);
            //            sum[1] = (sum[1] + blue);
            //            sum[2] = (sum[2] + green);

            //            pixelColor03 = Color.FromArgb(red, green, blue);
            //            bitmap03.SetPixel(x, y, pixelColor03);
            //        }
            //    }
            //    for (int i = 0; i < 3; i++)
            //    {
            //        sum[i] = sum[i] / (bitmap01.Width * bitmap01.Height);
            //    }
            //}

            bitmap03.Save("imageComb.jpg");

        }
    }
}
