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
    public class CombineImages
    {
        public CombineImages(Bitmap image1, Bitmap image2, Bitmap image3, Bitmap image4)
        {
            bitmap01 = image1;
            bitmap02 = image2;
            bitmap03 = image3;
            bitmap04 = image4;
        }

        public void writeBitmap(string imagePath)
        {
            // Average Images
            Console.WriteLine("CombineImages Bitmap Start");
            Bitmap outmap = new Bitmap(1920 * 2, 1080 * 2);

            Color pixelColor01 = new Color();

            for (int x = 0; x < bitmap01.Width; x++)
            {
                for (int y = 0; y < bitmap01.Height; y++)
                {
                    pixelColor01 = bitmap01.GetPixel(x, y);
                    outmap.SetPixel(x, y, pixelColor01);
                }
            }
            bitmap01.Dispose();


            for (int x = 0; x < bitmap02.Width; x++)
            {
                for (int y = 0; y < bitmap02.Height; y++)
                {
                    pixelColor01 = bitmap02.GetPixel(x, y);
                    outmap.SetPixel(1920 + x, 1080 + y, pixelColor01);
                }
            }

            for (int x = 0; x < 1920; x++)
            {
                for (int y = 0; y < 1080; y++)
                {
                    pixelColor01 = bitmap03.GetPixel(x, y);
                    outmap.SetPixel(1920 + x, y, pixelColor01);
                }
            }

            for (int x = 0; x < 1920; x++)
            {
                for (int y = 0; y < 1080; y++)
                {
                    pixelColor01 = bitmap04.GetPixel(x, y);
                    outmap.SetPixel(x, 1080 + y, pixelColor01);
                }
            }

            Console.WriteLine("CombineImages Bitmap Writing");
            outmap.Save(imagePath);
        }

        Bitmap bitmap01;

        Bitmap bitmap02;

        Bitmap bitmap03;

        Bitmap bitmap04;
    }
}