using System.Drawing;
using System.Drawing.Imaging;

namespace TDDImageProcessingApp
{
    public interface IFileManager
    {
        Bitmap LoadImage(string filename);
        void SaveImage(string filename, Bitmap resultBitmap, ImageFormat imgFormat); 
    }
}
