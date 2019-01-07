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
        private ImageController imageController;
        private EdgeFilters edgeFilters;
        private ImageFilters imageFilters;
        private Utils utils;

        [TestMethod]
        public void ApplyImageFilter_SelectedItemIsNull()
        {
            imageFilters = new ImageFilters();
            imageController = new ImageController(null, null, null, imageFilters);
            var img = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var result = imageController.ApplyImageFilter(null, bitmapUtil);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_SelectedItemIsNull()
        {
            edgeFilters = new EdgeFilters();
            imageController = new ImageController(null, null, edgeFilters, null);
            var img = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var result = imageController.EdgeDetection(null, bitmapUtil);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EdgeDetection_Sobel()
        {
            edgeFilters = new EdgeFilters();
            imageController = new ImageController(null, null, edgeFilters, null);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry_sobel;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.EdgeDetection("Sobel 3x3", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EdgeDetection_Laplacian()
        {
            edgeFilters = new EdgeFilters();
            imageController = new ImageController(null, null, edgeFilters, null);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry_laplacian;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.EdgeDetection("Laplacian 3x3", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EdgeDetection_None()
        {
            edgeFilters = new EdgeFilters();
            imageController = new ImageController(null, null, edgeFilters, null);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.EdgeDetection("None", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EdgeDetection_ImageFilterResultIsNotNull()
        {
            edgeFilters = new EdgeFilters();
            imageController = new ImageController(null, null, edgeFilters, null);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);
            // imageFilterResult is not null
            imageController.ImageFilterResult = img;
            imageController.OriginalBitmap = img;

            var resultBitmap = imageController.EdgeDetection("None", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }



        [TestMethod]
        public void ApplyImageFilter_Rainbow()
        {
            imageFilters = new ImageFilters();
            imageController = new ImageController(null, null, null, imageFilters);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry_rainbow;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.ApplyImageFilter("Rainbow", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ApplyImageFilter_BlackAndWhite()
        {
            imageFilters = new ImageFilters();
            imageController = new ImageController(null, null, null, imageFilters);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry_bw;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.ApplyImageFilter("Black & white", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ApplyImageFilter_None()
        {
            imageFilters = new ImageFilters();
            imageController = new ImageController(null, null, null, imageFilters);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);

            var resultBitmap = imageController.ApplyImageFilter("None", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ApplyImageFilter_ImageFilterResultNotNull()
        {
            imageFilters = new ImageFilters();
            imageController = new ImageController(null, null, null, imageFilters);
            utils = new Utils();
            var img = Resources.cherry;
            var referenceBitmap = Resources.cherry;

            // Substitute for IBitmapUtil and instructions for SetBitmap return
            var bitmapUtil = Substitute.For<IBitmapUtil>();
            bitmapUtil.SetBitmap(Arg.Any<Bitmap>()).Returns(img);
            imageController.ImageFilterResult = img;
            imageController.OriginalBitmap = img;

            var resultBitmap = imageController.ApplyImageFilter("None", bitmapUtil);
            var result = utils.CompareImageWithPixel(referenceBitmap, resultBitmap);

            Assert.IsTrue(result);
        }
    }
}
