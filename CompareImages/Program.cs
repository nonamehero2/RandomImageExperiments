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
            string imagePath = @"../../../Images/";
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

            Subtract subtract1 = new Subtract(bitmap01, bitmap02);
            subtract1.writeBitmap(String.Format("subtract1{0}.bmp", date));

            Subtract subtract2 = new Subtract(bitmap03, bitmap04);
            subtract2.writeBitmap(String.Format("subtract2{0}.bmp", date));

            Subtract subtract3 = new Subtract(bitmap01, bitmap04);
            subtract3.writeBitmap(String.Format("subtract3{0}.bmp", date));

            Subtract subtract4 = new Subtract(bitmap02, bitmap03);
            subtract4.writeBitmap(String.Format("subtract4{0}.bmp", date));

            SubtractModulus subtractModulus1 = new SubtractModulus(bitmap01, bitmap02);
            subtractModulus1.writeBitmap(String.Format("subtractModulus1{0}.bmp", date));

            SubtractModulus subtractModulus2 = new SubtractModulus(bitmap03, bitmap04);
            subtractModulus2.writeBitmap(String.Format("subtractModulus2{0}.bmp", date));

            SubtractModulus subtractModulus3 = new SubtractModulus(bitmap01, bitmap04);
            subtractModulus3.writeBitmap(String.Format("subtractModulus3{0}.bmp", date));

            SubtractModulus subtractModulus4 = new SubtractModulus(bitmap02, bitmap03);
            subtractModulus4.writeBitmap(String.Format("subtractModulus4{0}.bmp", date));

            SubtractAverage subtractAverage1 = new SubtractAverage(bitmap01, bitmap02);
            subtractAverage1.writeBitmap(String.Format("subtractAverage1{0}.bmp", date));

            SubtractAverage subtractAverage2 = new SubtractAverage(bitmap03, bitmap04);
            subtractAverage2.writeBitmap(String.Format("subtractAverage2{0}.bmp", date));

            SubtractAverage subtractAverage3 = new SubtractAverage(bitmap01, bitmap04);
            subtractAverage3.writeBitmap(String.Format("subtractAverage3{0}.bmp", date));

            SubtractAverage subtractAverage4 = new SubtractAverage(bitmap02, bitmap03);
            subtractAverage4.writeBitmap(String.Format("subtractAverage4{0}.bmp", date));

            Test test = new Test(bitmap01, bitmap04);
            test.writeBitmap(String.Format("test{0}.bmp", date));

            Test test2 = new Test(bitmap02, bitmap04);
            test2.writeBitmap(String.Format("test2{0}.bmp", date));

            Test test3 = new Test(bitmap03, bitmap04);
            test3.writeBitmap(String.Format("test3{0}.bmp", date));

            Test test4 = new Test(bitmap04, bitmap04);
            test4.writeBitmap(String.Format("test4{0}.bmp", date));

            CombineImages combiner = new CombineImages(bitmap01, bitmap02, bitmap03, bitmap04);
            combiner.writeBitmap(String.Format("combineImage{0}.bmp", date));


            string testImage1Path = "test.bmp";
            string testImage2Path = "test2.bmp";
            string testImage3Path = "test3.bmp";
            string testImage4Path = "test4.bmp";

            Image testImage01 = Image.FromFile(testImage1Path);
            Bitmap testbitmap01 = new Bitmap(testImage01, 1920, 1080);

            Image testImage02 = Image.FromFile(testImage2Path);
            Bitmap testbitmap02 = new Bitmap(testImage02, 1920, 1080);

            Image testImage03 = Image.FromFile(testImage3Path);
            Bitmap testbitmap03 = new Bitmap(testImage03, 1920, 1080);

            Image testImage04 = Image.FromFile(testImage4Path);
            Bitmap testbitmap04 = new Bitmap(testImage04, 1920, 1080);

            combiner = new CombineImages(testbitmap01, testbitmap02, testbitmap03, testbitmap04);
            combiner.writeBitmap(String.Format("testcombineImage{0}.bmp", date));

        }
    }
}
