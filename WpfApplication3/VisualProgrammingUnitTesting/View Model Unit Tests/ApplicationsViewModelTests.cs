using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class ApplicationsViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the Applications View Model.
            ApplicationsViewModel applications = new ApplicationsViewModel();

            // Verify that all properties are as expected.
            Assert.IsNotNull(applications.CurrentApplicationsDB, "The current applications database should be initialised in the constructor.");

            // Verify the read and write access of the property.
            Assert.IsTrue(GlobalAsserts.CanWrite((ApplicationsViewModel x) => x.CurrentApplicationsDB), "The view model's current application database property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ApplicationsViewModel x) => x.CurrentApplicationsDB), "The view model's current application database property should be retrievable.");
        }
    }
}
