using System.Drawing;

namespace TDDImageProcessingApp
{
    public interface IImageFilters
    {
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap BlackWhite(Bitmap Bmp);
    }
}
