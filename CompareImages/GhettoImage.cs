using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CompareImages
{
    public class Test
    {
        public Test(Bitmap image1, Bitmap image2)
        {
            bitmap01 = image1;
            bitmap02 = image2;
        }

        public void writeBitmap(string imagePath)
        {
            // Average Images
            Bitmap bitmap03 = new Bitmap(1920, 1080);

            // Copy image 1 to array
            BitmapData data1 = bitmap01.LockBits(
                new Rectangle(0, 0, bitmap01.Width, bitmap01.Height),
                 ImageLockMode.ReadOnly,
                 bitmap01.PixelFormat);

            IntPtr data1ptr = data1.Scan0;

            int data1bytes = Math.Abs(data1.Stride) * data1.Height;
            byte[] data1rgbValues = new byte[data1bytes];

            System.Runtime.InteropServices.Marshal.Copy(data1ptr, data1rgbValues, 0, data1bytes);

            // Do stuff
            int[] sum = { 0, 0, 0 };
            //0 is R, 1 is B, 2 is G

            Console.WriteLine("Test Bitmap Start");
            for (int x = 0; x < data1rgbValues.Length; x++)
            {
                if (x % 4 != 3)
                {
                    int total = 0;
                    int averageDiv = 0;

                    total += data1rgbValues[x];
                    averageDiv++;

                    if (x % data1.Width != 0)
                    {
                        total += data1rgbValues[x - 4];
                        averageDiv++;
                    }

                    if (x % data1.Width - (data1.Width - 1) != 0)
                    {
                        total += data1rgbValues[x + 4];
                        averageDiv++;
                    }

                    data1rgbValues[x] = (byte)(total / averageDiv);
                }
            }

            // Copy image 2 to array
            BitmapData data3 = bitmap03.LockBits(
                new Rectangle(0, 0, bitmap03.Width, bitmap03.Height),
                 ImageLockMode.WriteOnly,
                 bitmap03.PixelFormat);

            IntPtr data3ptr = data3.Scan0;

            int data3bytes = Math.Abs(data3.Stride) * data3.Height;
            byte[] data3rgbValues = new byte[data1bytes];

            System.Runtime.InteropServices.Marshal.Copy(data1rgbValues, 0, data3ptr, data1rgbValues.Length);

            bitmap01.UnlockBits(data1);
            bitmap03.UnlockBits(data3);

            Console.WriteLine("Test Bitmap Writing");
            bitmap03.Save(imagePath);
        }

        Bitmap bitmap01;

        Bitmap bitmap02;
    }
}