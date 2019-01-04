using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDImageProcessingAppTest
{
    public class Utils
    {
        public bool CompareImageWithPixel(Bitmap existingResult, Bitmap resultBitmap)
        {
            bool result = true;
            string firstPixel;
            string secondPixel;

            if (existingResult.Width == resultBitmap.Width
                && existingResult.Height == resultBitmap.Height)
            {
                for (int i = 0; i < existingResult.Width; i++)
                {
                    for (int j = 0; j < existingResult.Height; j++)
                    {
                        firstPixel = resultBitmap.GetPixel(i, j).ToString();
                        secondPixel = existingResult.GetPixel(i, j).ToString();
                        if (firstPixel != secondPixel)
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
