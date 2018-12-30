using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TDDImageProcessingApp;

namespace TDDImageProcessingAppTest
{
    [TestClass]
    public class InputOutputTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void LoadImage_NullReferenceException()
        {
            var fileManipulation = Substitute.For<IFileManipulation>();
            BusinessLogic businessLogic = new BusinessLogic(fileManipulation);
            // todo to continue here.. understand the concept to replace

        }
    }
}
