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

        public Bitmap getBitmap(Bitmap image1)
        {
            this.bitmap01 = image1;

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
            BitmapData data3 = bitmap03.LockBits(
                new Rectangle(0, 0, bitmap03.Width, bitmap03.Height),
                 ImageLockMode.WriteOnly,
                 bitmap03.PixelFormat);

            IntPtr data3ptr = data3.Scan0;

            int data3bytes = Math.Abs(data3.Stride) * data3.Height;
            byte[] data3rgbValues = new byte[data3bytes];

            // Do stuff
            int[] sum = { 0, 0, 0 };
            //0 is R, 1 is B, 2 is G


            int imageWidthBytes = data1.Width * 4;
            int imageHeightBytes = data1.Height * 4;


            // Console.WriteLine("=============");
            // Console.WriteLine(data1.Width.ToString());
            // Console.WriteLine(imageWidthBytes.ToString());
            // Console.WriteLine(data1.Height.ToString());
            // Console.WriteLine(imageHeightBytes.ToString());

            Console.WriteLine("Test Bitmap Start");

            // for (int x = 0; x < 10; x++)
            for (int x = 0; x < data1rgbValues.Length; x++)
            {
                    // Console.WriteLine("  -----   ");
                int total = 0;
                int averageDiv = 0;

                // Console.WriteLine("Center");
                total += data1rgbValues[x];
                averageDiv++;

                if (x - imageWidthBytes > 0)
                {
                    // Console.WriteLine("Up"+ data1rgbValues[x - imageWidthBytes]);
                    total += data1rgbValues[x - imageWidthBytes];
                    averageDiv++;
                }

                if (x + imageWidthBytes < data1rgbValues.Length)
                {
                    // Console.WriteLine("Down" + data1rgbValues[x + imageWidthBytes]);
                    total += data1rgbValues[x + imageWidthBytes];
                    averageDiv++;
                }

                if (x - 4 > 0)
                {
                    // Console.WriteLine("Left" + data1rgbValues[x - 4]);
                    total += data1rgbValues[x - 4];
                    averageDiv++;
                }

                if (x - 4 - imageWidthBytes > 0)
                {
                    // Console.WriteLine("Left Up" + data1rgbValues[x - 4 - imageWidthBytes]);
                    total += data1rgbValues[x - 4 - imageWidthBytes];
                    averageDiv++;
                }

                if (x - 4 + imageWidthBytes < data1rgbValues.Length)
                {
                    // Console.WriteLine("Left Down" + data1rgbValues[x - 4 + imageWidthBytes]);
                    total += data1rgbValues[x - 4 + imageWidthBytes];
                    averageDiv++;
                }

                if (x + 4 < data1rgbValues.Length)
                {
                    // Console.WriteLine("Right" + data1rgbValues[x + 4]);
                    total += data1rgbValues[x + 4];
                    averageDiv++;
                }

                if (x + 4 - imageWidthBytes > 0)
                {
                    // Console.WriteLine("Right Up" +  data1rgbValues[x + 4 - imageWidthBytes]);
                    total += data1rgbValues[x + 4 - imageWidthBytes];
                    averageDiv++;
                }

                if (x + 4 + imageWidthBytes < data1rgbValues.Length)
                {
                    // Console.WriteLine("Right Down"+ data1rgbValues[x + 4 + imageWidthBytes]);
                    total += data1rgbValues[x + 4 + imageWidthBytes];
                    averageDiv++;
                }


                data3rgbValues[x] = (byte)(total / averageDiv);


                if (data1rgbValues[x] != data3rgbValues[x])
                {
                    // Console.WriteLine(data3rgbValues[x]);
                    // Console.WriteLine(data1rgbValues[x]);
                    // Console.WriteLine("  -----   ");

                }
                // Console.WriteLine(averageDiv.ToString());
            }

            System.Runtime.InteropServices.Marshal.Copy(data3rgbValues, 0, data3ptr, data3rgbValues.Length);

            bitmap01.UnlockBits(data1);
            bitmap03.UnlockBits(data3);

            Console.WriteLine("Test Bitmap Writing");
            // bitmap03.Save(imagePath);
            return bitmap03;
        }

        public void writeBitmap(string imagePath)
        {
            this.getBitmap(bitmap01).Save(imagePath);
        }

        Bitmap bitmap01;

        Bitmap bitmap02;
    }
}