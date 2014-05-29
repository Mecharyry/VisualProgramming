using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.ViewModel;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.Database;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Common;
using System.Collections.Generic;

namespace VisualProgrammingUnitTesting.Database_Unit_Tests
{
    [TestClass]
    public class ControlsDatabaseModel
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            List<ControlViewModel> expectedControls = new List<ControlViewModel>()
            {
                { new ControlViewModel(new ExcelConnectionModel()) }
            };

            // Create an instance of the controls database.
            ControlsDB controlsDB = new ControlsDB();

            // Verify that the properties have the correct default values.
            Assert.IsNotNull(controlsDB.Controls, "The controls list should be initialised by the class' constructor.");

            // Verify that all properties have the correct read and write access.
            Assert.IsFalse(GlobalAsserts.CanWrite((ControlsDB x) => x.Controls), "The model's controls list property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ControlsDB x) => x.Controls), "The model's controls list property should be retrievable.");

            // Verify that the default control set returns a blank controls list.
            Assert.AreEqual(0, controlsDB.Controls.Count, "The default control set should return a blank list for the controls property.");

            // Notify a change in the control set via the mediator.
            Mediator.Instance.Notify(Mediator.ViewModelMessages.ControlsChanged, Constants.ApplicationSet.Excel);

            // Verify that the controls list now returns a list containing only controls whose application type is excel.
            Assert.IsTrue(controlsDB.Controls.Count > 0, "The controls list should return a list containing excel applications.");

            for (int i = 0; i < controlsDB.Controls.Count; i++)
            {
                if (controlsDB.Controls[i].CurrentCodeModel.Application != Constants.ApplicationSet.Excel)
                {
                    Assert.Fail("The controls application should only return control view models whose application type is excel.");
                }
            }
        }
    }
}
