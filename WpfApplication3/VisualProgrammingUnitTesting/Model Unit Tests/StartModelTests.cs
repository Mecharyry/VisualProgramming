using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using WpfApplication3.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class StartModelTests
    {
        [TestMethod]
        public void StartModelUnitTest()
        {
            string _controlName = "Start Control";
            string _imageSouce = Constants.StartControlImage;

            //StartControl start = new StartControl();
            //Assert.AreEqual(_controlName, start.ControlName, "The start control's control name property differs from expected.");
            //Assert.AreEqual(_imageSouce, start.ImageSource, "The start control's image source property differs from expected.");
        }
    }
}
