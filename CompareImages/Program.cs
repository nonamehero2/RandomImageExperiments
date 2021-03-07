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
            string imagePath = @"../../Images/";
            Console.WriteLine(Directory.GetCurrentDirectory());

            string image1Path = imagePath + "image (1).jpg";
            string image2Path = imagePath + "image (2).jpg";
            string image3Path = imagePath + "image (3).jpg";
            string image4Path = imagePath + "image (4).jpg";

            Image Image01 = Image.FromFile(image1Path);
            Bitmap bitmap01 = new Bitmap(Image01, 1920, 1080);

            Image Image02 = Image.FromFile(image2Path);
            Bitmap bitmap02 = new Bitmap(Image02, 1920, 1080);

            Image Image03 = Image.FromFile(image3Path);
            Bitmap bitmap03 = new Bitmap(Image03, 1920, 1080);

            Image Image04 = Image.FromFile(image4Path);
            Bitmap bitmap04 = new Bitmap(Image04, 1920, 1080);

            string date = "";
            // string date = DateTime.Now.ToString(@"MM-dd-yyyy_h-mm-ss");

            CleanAverage averager = new CleanAverage(bitmap01, bitmap04);
            averager.writeBitmap(String.Format("cleanAverage1{0}.bmp", date));

            CleanAverage averager2 = new CleanAverage(bitmap02, bitmap03);
            averager2.writeBitmap(String.Format("cleanAverage2{0}.bmp", date));

            PartialAverage paverager = new PartialAverage(bitmap01, bitmap04);
            paverager.writeBitmap(String.Format("partialAverage1{0}.bmp", date));

            PartialAverage paverager2 = new PartialAverage(bitmap02, bitmap03);
            paverager2.writeBitmap(String.Format("partialAverage2{0}.bmp", date));

            Modulus modulus = new Modulus(bitmap01, bitmap04);
            modulus.writeBitmap(String.Format("modulus1{0}.bmp", date));

            Modulus modulus2 = new Modulus(bitmap02, bitmap03);
            modulus2.writeBitmap(String.Format("modulus2{0}.bmp", date));

            AccidentalGradient gradient1 = new AccidentalGradient(bitmap01, bitmap04);
            gradient1.writeBitmap(String.Format("gradient1{0}.bmp", date));

            AccidentalGradient gradient2 = new AccidentalGradient(bitmap02, bitmap03);
            gradient2.writeBitmap(String.Format("gradient2{0}.bmp", date));


            Test test = new Test(bitmap01, bitmap04);
            test.writeBitmap(String.Format("test{0}.bmp", date));

            Test test2 = new Test(bitmap02, bitmap04);
            test2.writeBitmap(String.Format("test2{0}.bmp", date));

            CombineImages combiner = new CombineImages(bitmap01, bitmap02, bitmap03, bitmap04);
            combiner.writeBitmap(String.Format("combineImage{0}.bmp", date));

        }
    }
}
