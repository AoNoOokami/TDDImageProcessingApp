using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDImageProcessingApp;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class EdgeFilterTest
    {
        private readonly EdgeFilters edgeFilters = new EdgeFilters();
        private readonly Utils utils = new Utils();

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

            Assert.IsTrue(utils.CompareImageWithPixel(Reference, Result));
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
            var result = utils.CompareImageWithPixel(existingResult, resultBitmap);
            // Assert
            Assert.IsTrue(result);
        }
    }
}
