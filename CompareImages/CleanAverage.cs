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
    public class CleanAverage
    {
        public CleanAverage(Bitmap image1, Bitmap image2)
        {
            bitmap01 = image1;
            bitmap02 = image2;
        }

        public void writeBitmap(string imagePath)
        {
            // Average Images
            Bitmap bitmap03 = new Bitmap(1920, 1080);

            Color pixelColor01 = new Color();
            Color pixelColor02 = new Color();
            Color pixelColor03 = new Color();

            int[] sum = { 0, 0, 0 };
            //0 is R, 1 is B, 2 is G
            if (bitmap01.Height == bitmap02.Height && bitmap01.Width == bitmap02.Width)
            {
                Console.WriteLine("CleanAverage Bitmap Start");
                Console.WriteLine(bitmap01.Height);
                Console.WriteLine(bitmap01.Width);
                for (int x = 0; x < bitmap01.Width; x++)
                {
                    for (int y = 0; y < bitmap01.Height; y++)
                    {
                        pixelColor01 = bitmap01.GetPixel(x, y);
                        pixelColor02 = bitmap02.GetPixel(x, y);

                        int red, blue, green;
                        red = (pixelColor01.R + pixelColor02.R) / 2;
                        blue = (pixelColor01.B + pixelColor02.B) / 2;
                        green = (pixelColor01.G + pixelColor02.G) / 2;

                        if (red < 0)
                        {
                            red = red + 255;
                        }
                        if (blue < 0)
                        {
                            blue = blue + 255;
                        }
                        if (green < 0)
                        {
                            green = green + 255;
                        }

                        sum[0] = (sum[0] + red);
                        sum[1] = (sum[1] + blue);
                        sum[2] = (sum[2] + green);

                        pixelColor03 = Color.FromArgb(red, green, blue);
                        bitmap03.SetPixel(x, y, pixelColor03);
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    sum[i] = sum[i] / (bitmap01.Width * bitmap01.Height);
                }
            }

            Console.WriteLine("CleanAverage Bitmap Writing");
            bitmap03.Save(imagePath);
        }

        Bitmap bitmap01;

        Bitmap bitmap02;
    }
}