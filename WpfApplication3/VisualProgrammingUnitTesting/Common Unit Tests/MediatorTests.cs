using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using System.Collections.Generic;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Common_Tests
{
    [TestClass]
    public class MediatorTests
    {
        private static Boolean triggered = false;

        [TestMethod]
        public void Properties_UnitTest()
        {
            // Verify that the mediator extends the singleton class.
            Mediator mediator = new Mediator();

            Singleton<Mediator> singleton = mediator as Singleton<Mediator>;
            if (singleton == null)
            {
                Assert.Fail("The mediator design pattern must enforce the use of a singleton.");
            }

            // Verify that the properties contain the correct default values.
            Assert.IsNotNull(Mediator.Instance.MessageCallbackList.Count, "The message callback list should initially not be null.");

            // Verify that the message callback list returns a read-only dictionary.
            Assert.IsTrue(Mediator.Instance.MessageCallbackList.IsReadOnly, "The message callback list should be read-only, outside of the class.");

            // Verify get and set access on properties.
            Assert.IsFalse(GlobalAsserts.CanWrite((Mediator x) => x.MessageCallbackList), "The MessageCallbackList property should not be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((Mediator x) => x.MessageCallbackList), "The MessageCallbackList property should be retrievable.");
        }

        [TestMethod]
        public void Register_UnitTest()
        {
            // Verify that the message callback list does not contain any elements.
            Assert.AreEqual(0, Mediator.Instance.MessageCallbackList.Count, "The message callback list should not contain any elements.");

            // Register a method to a view message and verify that it has been added to the message callback list.
            Mediator.Instance.Register(
                (Object o) =>
                    {
                        DummyMethod();
                    }, Mediator.ViewModelMessages.CanvasSizeChanged);

            Assert.AreEqual(1, Mediator.Instance.MessageCallbackList.Count, "The message callback list should now contain an additional element.");
            Assert.IsTrue(Mediator.Instance.MessageCallbackList.ContainsKey(Mediator.ViewModelMessages.CanvasSizeChanged), "The message callback list does not contain the expected key.");
        }

        [TestMethod]
        public void Notify_UnitTest()
        {
            // Register a method to a view message.
            Mediator.Instance.Register(
                (Object o) =>
                {
                    DummyMethod();
                }, Mediator.ViewModelMessages.CanvasSizeChanged);

            Mediator.Instance.Notify(Mediator.ViewModelMessages.CanvasSizeChanged, null);

            // Verify that the dummy method has been triggered.
            Assert.IsTrue(triggered, "The dummy method was not triggered by the mediator notify method.");
        }

        public void DummyMethod()
        {
            triggered = true;
        }
    }
}
