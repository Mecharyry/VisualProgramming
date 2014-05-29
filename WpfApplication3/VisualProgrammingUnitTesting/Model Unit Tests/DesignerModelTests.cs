using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class DesignerModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            string designerName = "designerName01";
            GuiObjectModel guiObject = new GuiObjectModel() { X = 28, Y = 25 };
            GuiObjectModel guiObject1 = new GuiObjectModel() { X = 40, Y = 45 };
            ConnectionModel connection = new ConnectionModel() { Start = guiObject, End = guiObject };
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            // Create an instance of the designer model.
            DesignerModel model = new DesignerModel()
            {
                DesignerName = designerName
            };

            // Verify the model's properties contain the correct default values.
            Assert.AreEqual(designerName, model.DesignerName, "The designer name differs from expected.");

            // Verify the read and write access of all properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((DesignerModel x) => x.DesignerName), "The model's designer name property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((DesignerModel x) => x.DesignerName), "The model's designer name property should be retrievable.");
        }

        [TestMethod]
        public void Clone_UnitTest()
        {
            //string designerName = "OriginalName";
            //GuiObjectModel guiObject = new GuiObjectModel() { X = 28, Y = 25 };
            //GuiObjectModel guiObject1 = new GuiObjectModel() { X = 40, Y = 45 };
            //ConnectionModel connection = new ConnectionModel() { Start = guiObject, End = guiObject };
            //ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            //// Create an instance of the designer model.
            //DesignerModel model = new DesignerModel(designerName, new ExcelConnectionModel());

            //// Verify that the designer currently contains no connections or controls.
            //Assert.AreEqual(0, model.Controls.Count, "The controls collection should be initialised but contain no values.");
            //Assert.AreEqual(0, model.Connections.Count, "The connections collection should be initialised but contain no values.");

            //// Create a clone of the designer model.
            //DesignerModel clonedModel = model.Clone();

            //// Modify the original.
            //model.Connections.Add(connection);
            //model.Controls.Add(control);

            //// Verify that the original has been modified.
            //Assert.AreEqual(1, model.Controls.Count, "The controls collection has been modified and should contain one element.");
            //Assert.AreEqual(1, model.Connections.Count, "The connections collection has been modified and should contain one element.");

            //// Verify that the modifications have not affected the clone.
            //Assert.AreEqual(0, clonedModel.Connections.Count, "The cloned model's connections collection should not have been modified.");
            //Assert.AreEqual(0, clonedModel.Controls.Count, "The cloned model's controls collection should not have been modified."); 
        }
    }
}
