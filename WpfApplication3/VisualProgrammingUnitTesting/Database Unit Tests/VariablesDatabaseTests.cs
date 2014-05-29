using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Database;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Database_Unit_Tests
{
    [TestClass]
    public class VariablesDatabaseTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of variables database.
            VariablesDB variablesDB = new VariablesDB();

            // Verify that the properties contain the correct default values.
            Assert.IsNotNull(variablesDB.GlobalVariables, "The variables list should initially not be null.");
            Assert.IsNull(variablesDB.VariableName, "The variable name should initially be set to null.");
            Assert.IsNotNull(VariablesDB.Connections, "The connections list should initially not be null.");

            // Verify the read and write access of the properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((VariablesDB x) => x.GlobalVariables), "The variables list property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariablesDB x) => x.GlobalVariables), "The variables list property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((VariablesDB x) => x.VariableName), "The variable name property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariablesDB x) => x.VariableName), "The variable name property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((VariablesDB x) => VariablesDB.Connections), "The connections list property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariablesDB x) => VariablesDB.Connections), "The connections list property should be retrievable.");
        }
    }
}
