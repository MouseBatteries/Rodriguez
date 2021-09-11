using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;

//TODO:
// - Better memory managmnet. Not everybody has 20gb of ram.
// - Fix issue where output folder is placed inside input folder
// - More commandline expressions (verbose, multi-batch processing, colour, dimensions, offset, etc)
// - Create folders if they don't already exist.
// - Build for linux.
// - Implement Middle-Forwards Correction
// - Implement multi-file hopping. (skipping to other files if the last or next is inadequate to repair data)
// - Implement selective correction.


namespace Rodriguez
{
    class Rodriguez
    {

        static void mergeImages(string pathToImages, string topStack, string bottomStack, string newFilename, int xOffset, int yOffset)
        {
            Image bottomStackImg = Image.FromFile(Path.GetFullPath(bottomStack)); 
            Image topStackImg = Image.FromFile(Path.GetFullPath(topStack));

            var bitmapapTopStack = new Bitmap(bottomStackImg.Width, bottomStackImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmapapTopStack = Image.FromFile(Path.GetFullPath(topStack)) as Bitmap;
            bitmapapTopStack.MakeTransparent(bitmapapTopStack.GetPixel(0,0));

            Image original = bottomStackImg;

            Graphics gra = Graphics.FromImage(original);


            gra.DrawImage(bitmapapTopStack, xOffset, yOffset, bottomStackImg.Width, bottomStackImg.Height);

            original.Save(pathToImages + newFilename, ImageFormat.Jpeg);
        }

        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                Console.WriteLine("Settings:");
                foreach(Object obj in args)
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
                "│                    V 0.0.1                   │\n" +
                "├──────────────────────────────────────────────┤\n" +
                "│   @MouseBatteries GitHub: MouseBatteries     │\n" +
                "└──────────────────────────────────────────────┘\n");


            //Load Directory of Files to Drop Correct

            //Arguments - Input Dir, Output Dir


            string filepath = args[0];
            string filepathOut = args[1];
            string[] files = Directory.GetFiles(filepath, @"*.jpg");
            int imageIndex = 0;
            int[] dropThreshold = {0, 255}; //Best setting so far = 0, 255
            int imageReference = 0;
            int i = 0;

            ArrayList imageArray = new ArrayList();

            //Get each file and load into imageArray
            foreach (String file in files){ imageArray.Add(file); }
            
            Console.WriteLine("Found {0} images...", imageArray.Count.ToString());
            Console.ReadLine();

            //Image directory, topstack, bottom stack, offsets.
            var previous = imageArray[0].ToString();
            foreach (String file in imageArray)
            {
                mergeImages(filepath, previous, file, $@"/{filepathOut}{i}-correct.jpg", 0, 0);
                previous = file;
                i += 1;

                Console.WriteLine($"{i}-correct.jpg");

            }

            
        }

      
    }
}
