using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.Interfaces;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class DesignerViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of designer view model. Calling base constructor calls the other.
            DesignerViewModel model = new DesignerViewModel();

            // Verify that all properties have the correct default values.
            Assert.IsNotNull(model.CurrentDesigner, "The current designer property should be initialised in the constuctor.");
            Assert.AreEqual("Root", model.CurrentDesigner.DesignerName, "The default designer name should always be Root.");

            // Verify that the properties have the expected read and write access.
            Assert.IsFalse(GlobalAsserts.CanWrite((DesignerViewModel x) => x.CurrentDesigner), "The current designer property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((DesignerViewModel x) => x.CurrentDesigner), "The current designer property should be retrievable.");
        }

        [TestMethod]
        public void CreateConnection_UnitTest()
        {
            GuiObjectModel expectedGuiObject = new GuiObjectModel() { X = 120, Y = 2 };

            // Create an instance of designer view model.
            DesignerViewModel model = new DesignerViewModel();

            // Call the create connection method using the expectedGuiObject.
            model.StartConnection(expectedGuiObject);

            // Sets the current control to be what is passed as a parameter.
            //Assert.AreEqual(expectedGuiObject, model.CurrentControl, "The current control differs from expected.");

            // Verify that the current designer model now has an additional connection.
            Assert.AreEqual(expectedGuiObject, model.Connections[0].Start, "The current designer connections list does not contain the expected gui object model.");

            // Verify that the current connection has also been updated to the variable.
            Assert.AreEqual(expectedGuiObject, model.CurrentConnection.Start, "The current connection differs from expected.");
        }

        [TestMethod]
        public void CreateConnection_DuplicateSource_UnitTest()
        {
            GuiObjectModel expectedGuiObject = new GuiObjectModel() { X = 120, Y = 2 };

            // Create an instance of designer view model.
            DesignerViewModel model = new DesignerViewModel();

            // Call the create connection method using the expectedGuiObject.
            model.StartConnection(expectedGuiObject);

            // Verify that the current designer model now consists of one connection.
            Assert.AreEqual(1, model.Connections.Count, "The connections list does not contain the expected number of elements.");

            // Verify that the current designer model now has the correct additional connection.
            Assert.AreEqual(expectedGuiObject, model.Connections[0].Start, "The current designer connections list does not contain the expected gui object model.");

            // Call the create connection method again and verify that the connections list has not changed.
            model.StartConnection(expectedGuiObject);

            // Verify that the current designer model now consists of one connection.
            Assert.AreEqual(1, model.Connections.Count, "The connections list should not contain any additional elements when a duplicate source control is passed.");
        }

        [TestMethod]
        public void EndConnection_UnitTest()
        {
            GuiObjectModel startGuiObject = new GuiObjectModel() { X = 1, Y = 2 };
            GuiObjectModel endGuiObject = new GuiObjectModel() { X = 10, Y = 12 };
            ConnectionModel connection = new ConnectionModel()
            {
                Start = startGuiObject
            };

            // Create an instance of designer view model.
            DesignerViewModel model = new DesignerViewModel();
            model.CurrentConnection = connection;

            // Call the create connection method using the expectedGuiObject.
            model.EndConnection(endGuiObject);

            // Verify that the current connection has updated to the expectedGuiObject.
            Assert.AreEqual(startGuiObject, model.CurrentConnection.Start, "The current connection should automatically update to the parameter of the EndConnection method.");

            // Verify that the current connection now contains expectedGuiObject as its end property.
            Assert.AreEqual(endGuiObject, model.CurrentConnection.End, "The current connection property's end property does not contain the parameter of the EndConnection method.");
        }

        [TestMethod]
        public void RemoveAllControls_UnitTest()
        {   // Calling this function automatically tests the RemoveControl function.

            // Create an instance of designer view model.
            DesignerViewModel model = new DesignerViewModel();

            ControlViewModel control01 = new ControlViewModel(new ExcelConnectionModel());
            ControlViewModel control02 = new ControlViewModel(new ExcelConnectionModel());
            ControlViewModel control03 = new ControlViewModel(new ExcelConnectionModel());

            model.Controls.Add(control01);
            model.Controls.Add(control02);
            model.Controls.Add(control03);

            model.Connections.Add(new ConnectionModel() { Start = control01, End = control02 });
            model.Connections.Add(new ConnectionModel() { Start = control02, End = control01 });

            Assert.AreEqual(3, model.Controls.Count, "The number of items in the controls list differs from expected.");
            Assert.AreEqual(2, model.Connections.Count, "The number of items in the connections list differs from expected.");

            // Call the remove all controls method.
            //model.RemoveAllControls();

            Assert.AreEqual(0, model.Connections.Count, "The connections list should now contain no connections.");
            Assert.AreEqual(0, model.Controls.Count, "The controls list should now contain no controls.");
        }

        [TestMethod]
        public void IDropable_UnitTest()
        {
            // Create an instance of designer view model.
            DesignerViewModel model = new DesignerViewModel();

            // Verify that the DesignerViewModel class implements the interface.
            IDropable dropable = model as IDropable;

            if (dropable == null)
            {
                Assert.Fail("The DesignerViewModel should implement the IDropable interface.");
            }

            // Verify that the drag type it is expecting is a ControlViewModel.
            Assert.AreEqual(typeof(ControlViewModel), dropable.DataType, "The dropable data type differs from expected.");

            // Verify that the Drop(Object) method is not implemented.
            try
            {
                dropable.Drop(new Object());
                Assert.Fail("The Drop(object) method should not be implemented in the DesignerViewModel class.");
            }
            catch (NotImplementedException) { }

            try
            {
                dropable.Drop(new Object(), 10, 20);
            }
            catch (NotImplementedException) { Assert.Fail("The Drop(object, double, double) method should be implemented in the DesignerViewModel class."); }

            // Verify that the controls list does not contain any controls.
            //Assert.AreEqual(0, model.CurrentDesigner.Controls.Count, "The controls model should not contain any controls at present.");

            // Verify that the Drop(object, double, double) operates as expected.
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());
            model.Drop(control, 10, 20);

            // Verify that the control has been added to the list.
            Assert.AreEqual(1, model.Controls.Count, "The controls model should now contain an additional control.");
            Assert.AreEqual(typeof(ControlViewModel), model.Controls[0].GetType(), "The added control's type differs from expected.");

            // Modify control that has been added and verify that it does not edit the control variable.
            ExcelConnectionModel actualModel = model.Controls[0].CurrentCodeModel as ExcelConnectionModel;
            actualModel.ExcelPath = "somePath.xlsx";

            ExcelConnectionModel controlExcel = control.CurrentCodeModel as ExcelConnectionModel;
            Assert.AreNotEqual(actualModel.ExcelPath, controlExcel.ExcelPath, "The excel path of the dropped control should not affect that of the control parameter.");

        }
    }
}
