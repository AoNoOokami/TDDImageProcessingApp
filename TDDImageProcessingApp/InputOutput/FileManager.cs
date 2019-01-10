using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TDDImageProcessingApp
{
    public class FileManager : IFileManager
    {
        // original image loaded by the user
        private Bitmap originalBitmap;

        public Bitmap LoadImage(string filename)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    originalBitmap = (Bitmap)Image.FromStream(streamReader.BaseStream);
                    streamReader.Close();
                    return originalBitmap;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SaveImage(string filename, Bitmap resultBitmap, ImageFormat imgFormat)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false);
            resultBitmap.Save(streamWriter.BaseStream, imgFormat);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
