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

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ApplyImageFilter_NoItemSelected()
        {
            //Create
            IBitmapUtil bitmapUtil = new BitmapUtil();
                //Substitute.For<IBitmapUtil>() ;
            IImageFilters imageFilters = new ImageFilters();
                //Substitute.For<IImageFilters>();
            IFileManager fileManager = Substitute.For<IFileManager>();
            IUserInterface userInterface = Substitute.For <IUserInterface> ();


            
            Bitmap originalImage = new Bitmap(100,100);
            businessLogic = new BusinessLogic(bitmapUtil, imageFilters);
            businessLogic.CopyToSquareCanvas(originalImage, 50);
            //businessLogic.PreviewBitmap = originalImage;


            //Set return value
            //var param = userInterface.GetSelectedItemCMBImageFilter().Returns("Rainbow");
            Bitmap result = businessLogic.ApplyImageFilter("Rainbow");

            //imageFilters.When(x => x.GetSelectedItem()).Do(x => throw new Exception());
           // var result = imageFilters.RainbowFilter(originalImage).Returns(x => Resources.cherry);
            Assert.IsNotNull(result);
            
            //Assert.ThrowsException<Exception>(() => imageFilters.GetSelectedItem());

/*

            // substitute the interfaces using NSubstitute
            var files = Substitute.For<IFiles>();
            var bitmap = Substitute.For<IBitmap>();
            var filters = Substitute.For<IFilters>();

            // set the sourcebitmap and mockbitmap
            Bitmap sourceBitmap = Properties.Resources.panda;
            Bitmap mockBitmap = Properties.Resources.pandanight;

            // fool the substitute to return to us a mockbitmap
            filters.NightFilter(sourceBitmap).Returns<Bitmap>(mockBitmap);

            // pass the substitutes to image controller
            ImageController imageController = new ImageController(files, bitmap, filters);

            // set testbitmap equals to what the imagecontroller nightfilter method returns
            Bitmap testBitmap = imageController.NightFilter(sourceBitmap);

            // assert if mockbitmap and testbitmap are the equal
            Assert.AreEqual(testBitmap, mockBitmap);*/

        }
    }
}
