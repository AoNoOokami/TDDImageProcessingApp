using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TDDImageProcessingApp;

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
            var imageFilters = Substitute.For<IImageFilters>();
            var userInterface = Substitute.For <IUserInterface> ();
            businessLogic = new BusinessLogic(imageFilters);

            //Set return value
            var param = userInterface.GetSelectedItemCMBImageFilter().Returns("Rainbow");
            var result = businessLogic.ApplyImageFilter(param);
            //imageFilters.When(x => x.GetSelectedItem()).Do(x => throw new Exception());

            Assert.IsNotNull(result);
            //Assert.ThrowsException<Exception>(() => imageFilters.GetSelectedItem());
        }
    }
}
