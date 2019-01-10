using System.Drawing;

namespace TDDImageProcessingApp
{
    public interface IBitmapUtil
    {
        // interface to resize the original image to fit into the image preview
        Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght);
        Bitmap SetBitmap(Bitmap img);
    }
}
