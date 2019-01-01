using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDImageProcessingApp;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class EdgeFilterTest
    {
        private readonly EdgeFilters edgeFilters = new EdgeFilters();

        [TestMethod]
        public void TestMethod1()
        {
        }

        /* @author : Alicia
         * Filter tested : Sobel3x3Filter in EdgeFilters class without Grayscale.
         * Byte per byte image comparison: we have a reference image to compare with filtered image */
        [TestMethod]
        public void Sobel3x3FilterTest()
        {
            // Custom image used for test
            Bitmap TestImg = Properties.Resources.cherry;
            // Method result for comparison
            Bitmap Result;
            // Reference image for comparison
            Bitmap Reference = Properties.Resources.cherry_sobel;

            Result = edgeFilters.Sobel3x3Filter(TestImg, false);

            Assert.IsTrue(CompareImageWithPixel(Reference, Result));
        }

        /*
         *  @author: daniel
         **/
        [TestMethod]
        public void Laplacian3x3Filter_CompareImageWithExistingResultFromOtherSoftware_ReturnsBitmapFiltered()
        {
            // Arrange
            var sourceBitmap = new Bitmap(Properties.Resources.square);
            var existingResult = new Bitmap(Properties.Resources.square_laplacian);
            var resultBitmap = edgeFilters.Laplacian3x3Filter(sourceBitmap);
            // Act
            var result = CompareImageWithPixel(existingResult, resultBitmap);
            // Assert
            Assert.IsTrue(result);
        }

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
