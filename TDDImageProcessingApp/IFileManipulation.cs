using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    interface IFileManipulation
    {
        Bitmap LoadImage();
        void SaveImage(); 
    }
}
