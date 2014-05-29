using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Model;
using System.Windows.Input;
using WpfApplication3.Common;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class VariablesViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the Variables View Model.
            VariablesViewModel model = new VariablesViewModel();

            // Verify that all properties contain the correct default values.
            Assert.IsNotNull(model.CurrentVariablesDB, "The CurrentVariablesDB property should be initialised by the constructor.");

            // Verify that all properties contain the correct read and write access.
            Assert.IsFalse(GlobalAsserts.CanWrite((VariablesViewModel x) => x.CurrentVariablesDB), "The CurrentVariablesDB property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((VariablesViewModel x) => x.CurrentVariablesDB), "The CurrentVariablesDB property should be retrievable.");
        }

        [TestMethod]
        public void DeleteVariableCommand_UnitTest()
        {
            VariableModel variable = new VariableModel("variable01", Constants.VariableType.Connection);

            // Create an instance of the Variables View Model.
            VariablesViewModel model = new VariablesViewModel();

            // Add a variable to the variables list.
            model.CurrentVariablesDB.GlobalVariables.Add(variable);

            // Verify that the variables list has an additional element.
            Assert.AreEqual(1, model.CurrentVariablesDB.GlobalVariables.Count, "The variables list should contain an additional element.");

            // Execute the delete variable command and verify that the element has been removed.
            ICommand command = model.DeleteVariableCommand;
            command.Execute(variable);
            Assert.AreEqual(0, model.CurrentVariablesDB.GlobalVariables.Count, "The variables list should not contain any elements.");
        }

        [TestMethod]
        public void AddVariableCommand_UnitTest()
        {
            string expectedName = "variable01";
            Constants.VariableType expectedType = Constants.VariableType.Global;

            // Create an instance of the Variables View Model.
            VariablesViewModel model = new VariablesViewModel();

            // Execute the add variable command and verify that the variables list contains an additional item.
            ICommand command = model.AddVariableCommand;
            command.Execute(expectedName);
            Assert.AreEqual(1, model.CurrentVariablesDB.GlobalVariables.Count, "The variables list should contain an additional element.");
            Assert.AreEqual(expectedName, model.CurrentVariablesDB.GlobalVariables[0].VariableName, "The variable name of Variables[0] element differs from expected.");
            Assert.AreEqual(expectedType, model.CurrentVariablesDB.GlobalVariables[0].VariableType, "The variable type of Variables[0] element differs from expected.");

            // Verify that the variable name property has been reset.
            Assert.AreEqual(string.Empty, model.CurrentVariablesDB.VariableName, "The variable name should reset once the add variable command has executed.");
        }
    }
}
