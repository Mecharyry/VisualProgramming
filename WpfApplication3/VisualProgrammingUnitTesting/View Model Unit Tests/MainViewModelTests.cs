using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.Model;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the main view model.
            MainViewModel model = new MainViewModel();

            // Verify that the properties all contain the correct default value.
            Assert.IsNotNull(model.CurrentMainModel, "The current main model should initially be set by the constructor.");

            // Verify the read and write access of the properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((MainViewModel x) => x.CurrentMainModel), "The current main model property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((MainViewModel x) => x.CurrentMainModel), "The current main model property should be retrievable.");
        }

        [TestMethod]
        public void AddTab_UnitTest()
        {
            ExcelConnectionModel excelConnection = new ExcelConnectionModel(); 

            // Create an instance of the main view model.
            MainViewModel model = new MainViewModel();

            // Verify that the designers list currently contains only the root designer.
            Assert.AreEqual(1, model.CurrentMainModel.Designers.Count, "The designers list should contain only the root designer.");

            // Execute the AddTab(BaseCodeModel) function.
            model.AddTab(new ControlViewModel(excelConnection));

            // Verify that the designers list now the excel connection item.
            Assert.AreEqual(2, model.CurrentMainModel.Designers.Count, "The designers list should now contain an additional element.");
            Assert.AreEqual(excelConnection, model.CurrentMainModel.Designers[1].Parent, "The designers[1] element does not contain the expected item.");
        }

        [TestMethod]
        public void RemoveTab_UnitTest()
        {
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            // Create an instance of the main view model.
            MainViewModel model = new MainViewModel();
            model.CurrentMainModel.Designers.Add(new DesignerViewModel(new DesignerModel() { DesignerName = "ToRemove"}, control));

            // Verify that the designers list now contains 2 elements.
            Assert.AreEqual(2, model.CurrentMainModel.Designers.Count, "The designers list should now contain an additional element.");

            // Execute the remove tab method and verify that the tab has been removed.
            model.RemoveTab(control);
            Assert.AreEqual(1, model.CurrentMainModel.Designers.Count, "The designers list should now only contain the root designer.");
            Assert.AreNotEqual(control, model.CurrentMainModel.Designers[0], "The designers list contains an unexpected element.");
        }

        [TestMethod]
        public void GenerateCommand_UnitTest()
        {
            // Create an instance of the main view model.
            MainViewModel model = new MainViewModel();

            // Creates a clone of the model, which it then sends to the generator class.
        }
    }
}
