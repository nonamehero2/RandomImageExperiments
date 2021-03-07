﻿using System;
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

            string date = DateTime.Now.ToString(@"MM-dd-yyyy_h-mm-ss");

            CleanAverage averager = new CleanAverage(bitmap01, bitmap02);
            averager.writeBitmap(String.Format("cleanAverage1{0}.bmp", date));

            CombineImages combiner = new CombineImages(bitmap01, bitmap02, bitmap03, bitmap04);
            combiner.writeBitmap(String.Format("combineImage{0}.bmp", date));

        }
    }
}
