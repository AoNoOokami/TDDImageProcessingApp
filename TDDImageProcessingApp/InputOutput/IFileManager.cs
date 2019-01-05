using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public interface IFileManager
    {
        Bitmap LoadImage(string filename);
        void SaveImage(string filename, Bitmap resultBitmap, ImageFormat imgFormat); 
    }
}
