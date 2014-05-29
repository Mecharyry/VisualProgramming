using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class MainModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the main model.
            MainModel model = new MainModel();

            // Verify that all properties contain the correct default values.
            Assert.IsNotNull(model.Designers, "The designers list should initially be set within the constructor and hence not null.");

            // Verify that the properites have the correct read and write access associated to them.
            Assert.IsTrue(GlobalAsserts.CanWrite((MainModel x) => x.Designers), "The designers list property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((MainModel x) => x.Designers), "The designers list property should be retrievable.");
        }
    }
}
