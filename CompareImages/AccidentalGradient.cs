using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CompareImages
{
    public class AccidentalGradient
    {
        public AccidentalGradient(Bitmap image1, Bitmap image2)
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

            // Copy image 2 to array
            BitmapData data2 = bitmap02.LockBits(
                new Rectangle(0, 0, bitmap02.Width, bitmap02.Height),
                 ImageLockMode.ReadOnly,
                 bitmap02.PixelFormat);

            IntPtr data2ptr = data2.Scan0;

            int data2bytes = Math.Abs(data2.Stride) * data2.Height;
            byte[] data2rgbValues = new byte[data2bytes];

            System.Runtime.InteropServices.Marshal.Copy(data2ptr, data2rgbValues, 0, data2bytes);


            // Do stuff
            int[] sum = { 0, 0, 0 };
            //0 is R, 1 is B, 2 is G
            if (bitmap01.Height == bitmap02.Height && bitmap01.Width == bitmap02.Width)
            {
                Console.WriteLine("AccidentalGradient Bitmap Start");
                for (int x = 0; x < bitmap01.Width; x++)
                {
                    for (int y = 0; y < bitmap01.Height; y++)
                    {
                        data1rgbValues[x * y] = Convert.ToByte((Convert.ToInt16(data1rgbValues[x * y]) + Convert.ToInt16(data2rgbValues[x * y])) / 2);
                    }
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
            bitmap02.UnlockBits(data2);
            bitmap03.UnlockBits(data3);

            Console.WriteLine("AccidentalGradient Bitmap Writing");
            bitmap03.Save(imagePath);
        }

        Bitmap bitmap01;

        Bitmap bitmap02;
    }
}