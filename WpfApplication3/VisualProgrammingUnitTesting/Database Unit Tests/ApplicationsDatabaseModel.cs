using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Database;
using System.Reflection;
using VisualProgrammingUnitTesting.Common;
using WpfApplication3.Model;
using System.Collections.Generic;
using WpfApplication3.Common;

namespace VisualProgrammingUnitTesting.Database_Unit_Tests
{
    [TestClass]
    public class ApplicationsDatabaseModel
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            ApplicationModel currentApplication = new ApplicationModel("CurrentApp", "ImageSource.jpg");
            List<ApplicationModel> expectedApplications = new List<ApplicationModel>()
            {
                {new ApplicationModel(Constants.ApplicationSet.Excel.ToString(), Constants.ExcelApplicationImage)},
                {new ApplicationModel(Constants.ApplicationSet.Word.ToString(), Constants.WordApplicationImage)},
                {new ApplicationModel(Constants.ApplicationSet.Access.ToString(), Constants.AccessApplicationImage)}
            };

            // Create an instance of the Applications Database.
            ApplicationsDB applicationsDB = new ApplicationsDB();

            // Verify that all properties have the correct default values.
            Assert.AreEqual(expectedApplications.Count, applicationsDB.Applications.Count, "The applications list does not contain the correct number of items.");
            Assert.IsNull(applicationsDB.CurrentApplication, "The current application should initially be set to null.");

            // Verify that the application list contains the expected items.
            for (int i = 0; i < expectedApplications.Count; i++)
            {
                ApplicationModel actual = applicationsDB.Applications.Find(x => x.Application == expectedApplications[i].Application);

                if (actual == null)
                {
                    Assert.Fail("The applications list does not contain the expected item. Expected: {0}", expectedApplications[i].Application);
                }

                if (!actual.ImageSource.Equals(expectedApplications[i].ImageSource))
                {
                    Assert.Fail("The retrieved application does not contain the expected image source. Expected: {0}", expectedApplications[i].Application);
                }
            }

            // Verify property get and set access.
            Assert.IsFalse(GlobalAsserts.CanWrite((ApplicationsDB x) => x.Applications), "The model's applications list property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ApplicationsDB x) => x.Applications), "The model's applications list property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((ApplicationsDB x) => x.CurrentApplication), "The model's current application property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ApplicationsDB x) => x.CurrentApplication), "The model's current application property should be retrievable.");

            // Edit the current application property and verify.
            applicationsDB.CurrentApplication = currentApplication;
            Assert.AreEqual(currentApplication, applicationsDB.CurrentApplication, "The model's current application property differs from expected.");
        }
    }
}
