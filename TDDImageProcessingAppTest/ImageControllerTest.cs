using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TDDImageProcessingApp;
using TDDImageProcessingAppTest.Properties;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class ImageControllerTest
    {
        private BusinessLogic businessLogic;
        private Utils utils;

        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void ApplyImageFilter_SelectedItemIsNull()
        {
            businessLogic = new BusinessLogic();
            businessLogic.SelectedSource = Resources.cherry;

            var result = businessLogic.ApplyImageFilter(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_SelectedItemIsNull()
        {
            businessLogic = new BusinessLogic();
            businessLogic.SelectedSource = Resources.cherry;

            var result = businessLogic.EdgeDetection(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_Sobel()
        {
            businessLogic = new BusinessLogic();
            utils = new Utils();
            businessLogic.SelectedSource = Resources.cherry;
            var referenceBitmap = Resources.cherry_sobel;

            var resultBitmap = businessLogic.EdgeDetection("Sobel 3x3");
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }
    }
}
