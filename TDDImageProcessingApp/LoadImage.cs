using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDImageProcessingApp.Properties;

namespace TDDImageProcessingApp
{
    class LoadImage : IloadImage
    {
        Bitmap IloadImage.LoadImage(Bitmap loadedImg)
        {
            return Resources.monkey; 
        }
    }
}
