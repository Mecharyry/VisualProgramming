using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class ConnectionModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            GuiObjectModel startPoint = new GuiObjectModel() { X = 50, Y = 55 };
            GuiObjectModel endPoint = new GuiObjectModel() { X = 22, Y = 35 };

            ConnectionModel connection = new ConnectionModel();

            // Coordinates should default as point(0,0).
            Assert.IsNull(connection.Start, "The connection start property should default to null.");
            Assert.IsNull(connection.End, "The connection end property should default to null.");
            Assert.IsNotNull(connection.X, "The X coordinate property should default to not null.");
            Assert.IsNotNull(connection.Y, "The Y coordinate property should default to not null.");

            // Check that the start and end points can be edited.
            connection.Start = startPoint;
            connection.End = endPoint;

            Assert.AreEqual(startPoint, connection.Start, "The connection start property did not update correctly.");
            Assert.AreEqual(endPoint, connection.End, "The connection end property did not update correctly.");

            Assert.IsTrue(GlobalAsserts.CanRead((ConnectionModel x) => x.Start), "The connection start property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((ConnectionModel x) => x.End), "The connection end property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.Start), "The connection start property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.End), "The connection end property should be writable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.X), "The X coordinate property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.X), "The X coordinate property should be writable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.Y), "The Y coordinate property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanWrite((ConnectionModel x) => x.Y), "The Y coordinate property should be writable.");
        }

        [TestMethod]
        public void Clone_UnitTest()
        {
            //int xUpdate = 223;
            //int yUpdate = 512;
            //GuiObjectModel startUpdate = new GuiObjectModel() { X = 67, Y = 89 };
            //GuiObjectModel endUpdate = new GuiObjectModel() { X = 72, Y = 99 };

            //// Create a new connection model to clone.
            //ConnectionModel connection = new ConnectionModel()
            //{
            //    X = 1,
            //    Y = 2,
            //    Start = new GuiObjectModel() { X = 22, Y = 35 },
            //    End = new GuiObjectModel() { X = 50, Y = 55 }
            //};

            //ConnectionModel connectionClone = connection.Clone();

            //// Verify that both the clone and the original contain the same data.
            //Assert.AreEqual(connection.X, connectionClone.X, "The cloned connection's X property differs from expected.");
            //Assert.AreEqual(connection.Y, connectionClone.Y, "The cloned connection's Y property differs from expected.");
            //Assert.AreEqual(connection.Start, connectionClone.Start, "The cloned connection's Start property differs from expected.");
            //Assert.AreEqual(connection.End, connectionClone.End, "The cloned connection's End property differs from expected.");

            //// Update the cloned connection.
            //connectionClone.X = xUpdate;
            //connectionClone.Y = yUpdate;
            //connectionClone.Start = startUpdate;
            //connectionClone.End = endUpdate;

            //// Verify that the clone has been updated successfully.
            //Assert.AreEqual(xUpdate, connectionClone.X, "The cloned connection's X property did not update correctly.");
            //Assert.AreEqual(yUpdate, connectionClone.Y, "The cloned connection's Y property did not update correctly.");
            //Assert.AreEqual(startUpdate, connectionClone.Start, "The cloned connection's Start property did not update correctly.");
            //Assert.AreEqual(endUpdate, connectionClone.End, "The cloned connection's End property did not update correctly.");

            //// Verify that the original connection has not been updated.
            //Assert.AreNotEqual(connection.X, xUpdate, "The original connection's X property should be unaffected by the modifications made to its clone.");
            //Assert.AreNotEqual(connection.Y, yUpdate, "The original connection's Y property should be unaffected by the modifications made to its clone.");
            //Assert.AreNotEqual(connection.Start, startUpdate, "The original connection's Start property should be unaffected by the modifications made to its clone.");
            //Assert.AreNotEqual(connection.End, endUpdate, "The original connection's End property should be unaffected by the modifications made to its clone.");
        }
    }
}
