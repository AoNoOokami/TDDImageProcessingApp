using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public interface IBitmapUtil
    {
        // interface to resize the original image to fit into the image preview
        Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght);
        Bitmap SetBitmap(Bitmap img);
    }
}
