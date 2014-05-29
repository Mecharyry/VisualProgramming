using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class GuiObjectModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the GuiObjectModel.
            GuiObjectModel model = new GuiObjectModel();

            // Verify that the properties contain their respective default values.
            Assert.AreEqual(0.0, model.X, "The X coordinate property should initially be set to 0.0.");
            Assert.AreEqual(0.0, model.Y, "The Y coordinate property should initially be set to 0.0.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GuiObjectModel x) => x.X), "The X coordinate property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GuiObjectModel x) => x.X), "The X coordinate property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GuiObjectModel x) => x.Y), "The Y coordinate property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GuiObjectModel x) => x.Y), "The Y coordinate property should be retrievable.");
        }
    }
}
