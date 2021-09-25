using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;

namespace Rodriguez
{
    class Rodriguez
    {
        static void mergeImages(string pathToImages, string topStack, string bottomStack, string newFilename, int xOffset, int yOffset)
        {
            Image bottomStackImg = Image.FromFile(Path.GetFullPath(bottomStack));
            Image topStackImage = Image.FromFile(Path.GetFullPath(topStack));

            var bitmapTopStack = new Bitmap(bottomStackImg.Width, bottomStackImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmapTopStack = Image.FromFile(Path.GetFullPath(topStack)) as Bitmap;
            bitmapTopStack.MakeTransparent(bitmapTopStack.GetPixel(0, 0));

            Image original = bottomStackImg;
            Graphics gra = Graphics.FromImage(original);

            gra.DrawImage(bitmapTopStack, xOffset, yOffset, bottomStackImg.Width, bottomStackImg.Height);

            original.Save(pathToImages + newFilename, ImageFormat.Jpeg);
            System.GC.Collect(); //Collect garbage; stop using all of my memory!
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Settings:");
                foreach (Object obj in args)
                {
                    Console.WriteLine("[S] - {0}", obj);
                }
            }
            else
            {
                Console.WriteLine("[E] - Arguments Required.");
                return;
            }

            Console.WriteLine("" +
                "┌──────────────────────────────────────────────┐\n" +
                "│                   Rodriguez                  │\n" +
                "│           Satellite Image Corrector          │\n" +
                "│                    V 0.0.2                   │\n" +
                "├──────────────────────────────────────────────┤\n" +
                "│   @MouseBatteries GitHub: MouseBatteries     │\n" +
                "└──────────────────────────────────────────────┘\n");

            string filepath = args[0];
            string filepathOut = args[1];
            string[] files = Directory.GetFiles(filepath, @"*.jpg");
            int i = 0;

            ArrayList imageArray = new ArrayList();

            foreach(String file in files) { imageArray.Add(file); }

            Console.WriteLine("Found {0} images...", imageArray.Count.ToString());
            Console.WriteLine("[ENTER] - To Continue.");
            Console.ReadLine();

            var previous = imageArray[0].ToString();
            foreach(String file in imageArray)
            {
                mergeImages(filepath, previous, file, $@"/{filepathOut}{i}-correct.jpg", 0, 0);
                previous = file;
                i += 1;

                Console.WriteLine($"[LOG] - [Created] - {i}-correct.jpg in {filepathOut}");
            }
        }
    }
}