﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public interface IEdgeFilters
    {
        Bitmap Sobel3x3Filter(Bitmap sourceBitmap, bool grayscale);
        Bitmap Laplacian3x3Filter(Bitmap sourceBitmap, bool grayscale);
    }
}
