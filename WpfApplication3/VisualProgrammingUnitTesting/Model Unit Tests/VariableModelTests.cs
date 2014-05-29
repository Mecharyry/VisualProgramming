using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using WpfApplication3.Common;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class VariableModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            string expectedName = "variable01";
            Constants.VariableType expectedType = Constants.VariableType.Connection;

            // Create an instance of variable model.
            VariableModel model = new VariableModel(expectedName, expectedType);

            // Verify that the properties have the expected values.
            Assert.AreEqual(expectedName, model.VariableName, "The variable name property differs from expected.");
            Assert.AreEqual(expectedType, model.VariableType, "The variable type property differs from expected.");
            Assert.IsNotNull(model.Code, "The code property should return some CodeDom object.");

            // Verify the read and write access of the properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((VariableModel x) => x.VariableName), "The VariableName property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariableModel x) => x.VariableName), "The VariableName property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((VariableModel x) => x.VariableType), "The VariableType property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariableModel x) => x.VariableType), "The VariableType property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((VariableModel x) => x.Code), "The Code property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariableModel x) => x.Code), "The Code property should be retrievable.");
        }
    }
}
