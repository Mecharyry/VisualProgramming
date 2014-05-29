using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using System.Windows.Input;
using Microsoft.Office.Interop.Excel;

namespace VisualProgrammingUnitTesting.Common_Unit_Tests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void GetMemberName_NoParams_UnitTest()
        {
            string expectedMemberName = "ActiveWorkbook";

            string actualMemberName = Helper.GetMemberName((Application x) => x.ActiveWorkbook);

            Assert.AreEqual(expectedMemberName, actualMemberName, "The member name retrieved differs from expected.");
        }

        [TestMethod]
        public void GetMethodName_Params_UnitTest()
        {
            string expectedMethodName = "SaveWorkspace";

            string actualMethodName = Helper.GetMethod((Application x) => x.SaveWorkspace(Type.Missing));

            Assert.AreEqual(expectedMethodName, actualMethodName, "The method name retrieved differs from expected.");
        }
    }
}
