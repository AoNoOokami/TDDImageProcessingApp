using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDDImageProcessingApp.Properties;

namespace TDDImageProcessingApp
{
    public class FileManipulation : IFileManipulation
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
            catch (IOException ioex)
            {
                throw new Exception(ioex.Message);
            }
            //return Resources.monkey; 
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
