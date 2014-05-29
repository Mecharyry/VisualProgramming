using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using WpfApplication3.Model.Code_Control;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Interfaces;
using WpfApplication3.Common;
using System.Windows.Input;

namespace VisualProgrammingUnitTesting.View_Model_Tests
{
    [TestClass]
    public class ControlViewModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Create an instance of the control view model.
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            // Verify properties have the correct default values.
            Assert.IsNotNull(control.CurrentCodeModel, "The current code model property should initially be set by the constructor.");
            Assert.AreEqual(typeof(ExcelConnectionModel), control.CurrentCodeModel.GetType(), "The type of the current code model differs from expected.");

            // Verify property access levels.
            Assert.IsFalse(GlobalAsserts.CanWrite((ControlViewModel x) => x.CurrentCodeModel), "The current code model property should note be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ControlViewModel x) => x.CurrentCodeModel), "The current code model property should be retrievable.");
        }

        [TestMethod]
        public void IDragable_UnitTest()
        {
            // Create an instance of the control view model.
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            // Verify that it implements the IDragable interface.
            IDragable dragable = control as IDragable;

            if (dragable == null)
            {
                Assert.Fail("The Control View Model class should implement the IDragable interface.");
            }

            // Verify I dragable properties are implemented.
            Assert.AreEqual(typeof(ControlViewModel), dragable.DataType, "The Control View Model class should return its own type when implementing the IDragable interface.");
        }

        [TestMethod]
        public void ICommandRemoveControl_UnitTest()
        {
            Boolean setPropertiesTriggered = false;

            // Create an instance of the control view model.
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            // Verify that the class contains two ICommands and their respective methods.
            Mediator.Instance.Register(
            (Object o) =>
            {
                setPropertiesTriggered = true;
            }, Mediator.ViewModelMessages.PropertiesSelection);
            ICommand command = control.SetPropertiesCommand;
            command.Execute(new object());
            Assert.IsTrue(setPropertiesTriggered, "The set properties method was not triggered by its respective ICommand.");
        }

        [TestMethod]
        public void ICommandSetProperties_UnitTest()
        {
            Boolean removeControlTriggered = false;

            // Create an instance of the control view model.
            ControlViewModel control = new ControlViewModel(new ExcelConnectionModel());

            Mediator.Instance.Register(
            (Object o) =>
            {
                removeControlTriggered = true;
            }, Mediator.ViewModelMessages.RemoveControl);
            ICommand command = control.RemoveControlCommand;
            command.Execute(new object());
            Assert.IsTrue(removeControlTriggered, "The remove control method was not triggered by its respective ICommand.");
        }
    }
}
