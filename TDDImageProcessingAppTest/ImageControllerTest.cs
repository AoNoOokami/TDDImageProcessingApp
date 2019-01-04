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
            var bitmapUtil = Substitute.For<IBitmapUtil>();

            var result = businessLogic.ApplyImageFilter(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_SelectedItemIsNull()
        {
            businessLogic = new BusinessLogic();
            businessLogic.SelectedSource = Resources.cherry;
            var bitmapUtil = Substitute.For<IBitmapUtil>();

            var result = businessLogic.EdgeDetection(null, bitmapUtil);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_Sobel()
        {
            businessLogic = new BusinessLogic();
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry_sobel;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = businessLogic.EdgeDetection("Sobel 3x3", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }
    }
}
