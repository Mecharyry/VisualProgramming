
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Common_Tests
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Verify that the properties have the correct default values.
            Assert.IsNotNull(ExtendsSingleton.Instance, "The instance property of the singleton class should be initialised when extending the class.");

            // Verify the properties get and set access.
            Assert.IsFalse(GlobalAsserts.CanWrite((ExtendsSingleton x) => ExtendsSingleton.Instance), "The Instance property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ExtendsSingleton x) => ExtendsSingleton.Instance), "The Instance property should be retrievable.");
        }
    }

    public class ExtendsSingleton : Singleton<ExtendsSingleton>
    {

    }
}
