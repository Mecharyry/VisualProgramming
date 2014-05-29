using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using WpfApplication3.Model.Code_Control;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class ExcelConnectionTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            string _controlName = "Excel Connection";
            Constants.ApplicationSet _application = Constants.ApplicationSet.Excel;
            string _imageSource = Constants.ExcelConnectionImage;
            Boolean _nestable = false;
            string _excelPath = "excel.xlsx";

            // Create an instance of the excel connection model.
            ExcelConnectionModel model = new ExcelConnectionModel();

            // Verify the properties are as expected.
            Assert.IsNull(model.Parent, "The property parent should initially be set to null.");
            Assert.AreEqual(_application, model.Application, "The property application should be instantiated Excel.");
            Assert.AreEqual(_controlName, model.ControlName, "The property control name differs from expected.");
            Assert.AreEqual(_imageSource, model.ImageSource, "The property image source differs from expected.");
            Assert.AreEqual(_nestable, model.Nestable, "The property nestable differs from expected.");
            Assert.IsNull(model.ExcelPath, "The initial value for the property excel path should be null.");
            Assert.IsNotNull(model.Code, "The property code should be instantiated to some CodeDom object.");
            Assert.AreEqual(0, model.NoConnections, "The property NoConnections should have the initial value of 0.");

            // Assign a new value to model's excel path.
            model.ExcelPath = _excelPath;
            Assert.AreEqual(_excelPath, model.ExcelPath, "The value of the property excel path differs from expected.");

            Assert.IsTrue(GlobalAsserts.CanWrite((ExcelConnectionModel x) => x.ExcelPath), "The model's excel path property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ExcelConnectionModel x) => x.ExcelPath), "The model's excel path property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((ExcelConnectionModel x) => x.NoConnections), "The model's NoConnections property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ExcelConnectionModel x) => x.NoConnections), "The model's NoConnections property should be retrievable.");
        }
    }
}
