using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public interface IImageFilters
    {
        Bitmap RainbowFilter(Bitmap bmp);
        Bitmap BlackWhite(Bitmap Bmp);

    }
}
