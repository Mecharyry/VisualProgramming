using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using WpfApplication3.Common;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class ApplicationModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            string _expectedApplicationName = "ApplicationName01";
            string _expectedImageSource = Constants.AccessApplicationImage;

            // Create an instance of an application model.
            ApplicationModel model = new ApplicationModel(_expectedApplicationName, _expectedImageSource);

            // Verify that all properties are as expected.
            Assert.AreEqual(_expectedApplicationName, model.Application, "The model's property application name is not as expected.");
            Assert.AreEqual(_expectedImageSource, model.ImageSource, "The model's property image source is not as expected.");

            // Verify access level of all properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((ApplicationModel x) => x.Application), "The model's application property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ApplicationModel x) => x.Application), "The model's application property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((ApplicationModel x) => x.ImageSource), "The model's image source property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ApplicationModel x) => x.ImageSource), "The model's image source property should be retrievable.");
        }
    }
}
