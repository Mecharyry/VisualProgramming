using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using System.Windows.Input;

namespace VisualProgrammingUnitTesting.Common_Tests
{
    [TestClass]
    public class CommandTests
    {
        private Boolean triggered = false;

        [TestMethod]
        public void ICommandT_UnitTest()
        {
            // Create an instance of Command.
            ICommand command = new Command<object>(this.DummyMethod);

            // Verify that CanExecute returns true.
            Assert.IsTrue(command.CanExecute(new object()), "The CanExecute method should always return true.");

            command.Execute(new object());
            Assert.IsTrue(triggered, "The method triggered by the ICommand did not execute.");
        }

        [TestMethod]
        public void ICommand_UnitTest()
        {
            // Create an instance of Command.
            ICommand command = new Command(this.DummyMethod);

            // Verify that CanExecute returns true.
            Assert.IsTrue(command.CanExecute(new object()), "The CanExecute method should always return true.");

            command.Execute(null);
            Assert.IsTrue(triggered, "The method triggered by the ICommand did not execute.");
        }

        public void DummyMethod()
        {
            triggered = true;
        }

        public void DummyMethod(object param)
        {
            triggered = true;
        }
    }
}
