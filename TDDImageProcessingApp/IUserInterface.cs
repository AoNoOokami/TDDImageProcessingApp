﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingApp
{
    public interface IUserInterface
    {
        string GetSelectedItemCMBEdgeDetection();
        string GetSelectedItemCMBImageFilter();
    }
}