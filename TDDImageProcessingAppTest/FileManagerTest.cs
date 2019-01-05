using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TDDImageProcessingApp;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class FileManagerTest
    {
        private IFileManager fileManager = Substitute.For<IFileManager>();
        private BusinessLogic businessLogic;
        public string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;


        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void LoadImage_WrongImageReference_ReturnIOException()
        {
            // arrange
            fileManager
                .When(x => x.LoadImage("test"))
                .Do(x => { throw new IOException(); });
            businessLogic = new BusinessLogic(fileManager);
            
            // act
            var result = businessLogic.LoadImage("test");

            Assert.ThrowsException<IOException>(() => result);
        }

        [TestMethod]
        public void LoadImage_OpenFile_ReturnIsNotNull()
        {
            // arrange
            // couldn't use Nsubstitute  => fileManager.LoadImage("filepath").Returns(new Bitmap(100, 100));
            fileManager = new FileManager();
            businessLogic = new BusinessLogic(fileManager);
            // replace the base directory with the "Ressources" directory to load an image
            baseDirectory = baseDirectory.Replace("bin\\Debug", "Resources\\cherry.png");
            
            // act
            var result = businessLogic.LoadImage(baseDirectory);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadImage_OpenFile_TypeIsBitmap()
        {
            // arrange
            fileManager = new FileManager();
            businessLogic = new BusinessLogic(fileManager);
            string resourcesDirectory = null;
            // replace the base directory with the 'resources' directory to load an image
            resourcesDirectory = baseDirectory.Replace("bin\\Debug", "Resources\\cherry.png");

            // act
            var result = businessLogic.LoadImage(resourcesDirectory);

            Assert.IsInstanceOfType(result, typeof(Bitmap));
        }

        [TestMethod]
        public void LoadImage_FilePathIsWrong_ReturnIsNull()
        {
            // arrange
            businessLogic = new BusinessLogic(fileManager);
            // act
            var result = businessLogic.LoadImage("");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SaveImage_ImageSaved()
        {
            // arrange
            string resourcesDirectory = null;
            Bitmap resultBitmap = Properties.Resources.cherry; 
            fileManager = new FileManager();
            businessLogic = new BusinessLogic(fileManager);


            // replace the base directory with the 'Resources' directory to save an image
            resourcesDirectory = baseDirectory.Replace("bin\\Debug", "Resources\\test.png");
            
            // act
            businessLogic.SaveImage(resourcesDirectory, resultBitmap, ImageFormat.Png);
        }

        // stream writer exceptions: https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter.-ctor?view=netframework-4.7.2
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SaveImage_PropertiesIsNull_ReturnNullReferenceException()
        {
            // arrange
            fileManager = new FileManager();
            businessLogic = new BusinessLogic(fileManager);

            // act
            businessLogic.SaveImage("test", null, ImageFormat.Png);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveImage_FilePathIsEmpty_ReturnNullReferenceException()
        {
            // arrange
            fileManager = new FileManager();
            businessLogic = new BusinessLogic(fileManager);
            Bitmap resultBitmap = new Bitmap(100,100);

            // act
            businessLogic.SaveImage("", null, ImageFormat.Png);
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
                ;
            businessLogic = new BusinessLogic(fileManager);

            // act
            businessLogic.SaveImage("filename", resultBitmap, ImageFormat.Png);
        }
    }
}
