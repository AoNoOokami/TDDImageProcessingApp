using System.Drawing;

namespace TDDImageProcessingApp
{
    public interface IEdgeFilters
    {
        Bitmap Sobel3x3Filter(Bitmap sourceBitmap, bool grayscale);
        Bitmap Laplacian3x3Filter(Bitmap sourceBitmap, bool grayscale);
    }
}
