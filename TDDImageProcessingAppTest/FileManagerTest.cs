using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TDDImageProcessingApp;
using TDDImageProcessingAppTest.Properties;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class FileManagerTest
    {
        private IFileManager fileManager = Substitute.For<IFileManager>();
        private ImageController imageController;
        private string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;


        [TestMethod]
        public void CopyToSquareCanvasTest()
        {
            // substitute the interface bitmapUtil
            IBitmapUtil bitmapUtil = Substitute.For<IBitmapUtil>();
            int canvasWidthLenght = 600;
            Bitmap mockBitmap = Resources.cherry;

            // replace the return with the interface
            bitmapUtil.CopyToSquareCanvas(mockBitmap, canvasWidthLenght).Returns(mockBitmap);
            // pass the substitutes to the controller 
            imageController = new ImageController(null, bitmapUtil, null, null);
            Bitmap result = imageController.CopyToSquareCanvas(mockBitmap, canvasWidthLenght);

            Assert.AreEqual(result, mockBitmap);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void LoadImage_WrongImageReference_ReturnIOException()
        {
            // arrange
            fileManager
                .When(x => x.LoadImage("test"))
                .Do(x => { throw new IOException(); });
            imageController = new ImageController(fileManager);
            
            // act
            var result = imageController.LoadImage("test");

            Assert.ThrowsException<IOException>(() => result);
        }

        [TestMethod]
        public void LoadImage_OpenFile_ReturnIsNotNull()
        {
            Bitmap mockBitmap = Resources.cherry;
            // substitute the interface fileManager
            fileManager.LoadImage("filepath").Returns(mockBitmap);
            imageController = new ImageController(fileManager);
            
            imageController.LoadImage("filepath");
            var result = imageController.OriginalBitmap;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadImage_OpenFileSameAsOriginalImage()
        {
            Bitmap mockBitmap = Resources.cherry;
            // substitute the interface fileManager
            fileManager.LoadImage("filepath").Returns(mockBitmap);

            imageController = new ImageController(fileManager);
            imageController.LoadImage("filepath");
            // get the loaded image
            Bitmap result = imageController.OriginalBitmap;

            Assert.AreEqual(mockBitmap, result);
        }

        [TestMethod]
        public void LoadImage_OpenFile_TypeIsBitmap()
        {
            Bitmap mockBitmap = Resources.cherry;
            fileManager.LoadImage("filepath").Returns(mockBitmap);
            imageController = new ImageController(fileManager);

            var result = imageController.LoadImage("filepath");

            Assert.IsInstanceOfType(result, typeof(Bitmap));
        }

        [TestMethod]
        public void LoadImage_FilePathIsWrong_ReturnIsNull()
        {
            fileManager.LoadImage(null);
            imageController = new ImageController(fileManager);
            
            var result = imageController.LoadImage(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SaveImage_ImageSaved()
        {
            bool isPassed = false;
            Bitmap resultBitmap = Resources.cherry; 
            fileManager
                .When(x => x.SaveImage("filename", resultBitmap, ImageFormat.Png))
                .Do(x => isPassed = true );
            imageController = new ImageController(fileManager);
            
            imageController.SaveImage("filename", resultBitmap, ImageFormat.Png);

            Assert.IsTrue(isPassed);
        }

        // stream writer exceptions: https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.-ctor?view=netframework-4.7.2
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SaveImage_PropertiesIsNull_ReturnNullReferenceException()
        {
            // arrange
            fileManager
                .When(x => x.SaveImage("filename", null, ImageFormat.Png))
                .Do(x => throw new NullReferenceException());
            imageController = new ImageController(fileManager);

            // act
            imageController.SaveImage("filename", null, ImageFormat.Png);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveImage_FilePathIsEmpty_ReturnNullReferenceException()
        {
            // arrange
            fileManager
                .When(x => x.SaveImage("", null, ImageFormat.Png))
                .Do(x => throw new ArgumentException());
            imageController = new ImageController(fileManager);

            // act
            imageController.SaveImage("", null, ImageFormat.Png);
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        public void ImageSave_NotAuthorized()
        {
            // arrange
            Bitmap resultBitmap = new Bitmap(100,100);
            fileManager
                .When(x => x.SaveImage("filename", resultBitmap, ImageFormat.Png))
                .Do(x => throw new SecurityException());
            imageController = new ImageController(fileManager);

            // act
            imageController.SaveImage("filename", resultBitmap, ImageFormat.Png);
        }
    }
}
