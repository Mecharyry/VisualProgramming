using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class ControlsViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the controls view model.
            ControlsViewModel model = new ControlsViewModel();

            // Verify the default values of the properties.
            Assert.IsNotNull(model.CurrentControlsDB, "The current controls database should be assigned by the constructor of this class.");

            // Verify that the property is readonly.
            Assert.IsFalse(GlobalAsserts.CanWrite((ControlsViewModel x) => x.CurrentControlsDB), "The current controls database property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ControlsViewModel x) => x.CurrentControlsDB), "The current controls database property should be retrievable.");
        }
    }
}
