
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Common;
using System.CodeDom;
using WpfApplication3.Model.Code_Control;
using VisualProgrammingUnitTesting.Common;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class BaseForLoopModelTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            Constants.ApplicationSet _application = Constants.ApplicationSet.Excel;
            string _imageSource = Constants.ExcelApplicationImage;
            Boolean _nestable = true;
            string _controlName = "For Loop";
            string _iterator = "i";
            int _endValue = 10;
            int _startValue = 1;
            CodeBinaryOperatorType _condition = CodeBinaryOperatorType.LessThan;
            CodeBinaryOperatorType _increment = CodeBinaryOperatorType.Add;

            // Create an instance of the for model class.
            BaseForModel model = new BaseForModel();

            // Verify that the properties have the expected default values.
            Assert.AreEqual(_application, model.Application, "The property application should be instantiated Excel.");
            Assert.AreEqual(_controlName, model.ControlName, "The property control name differs from expected.");
            Assert.AreEqual(_imageSource, model.ImageSource, "The property image source differs from expected.");
            Assert.AreEqual(_nestable, model.Nestable, "The property nestable differs from expected.");

            Assert.IsNull(model.IteratorName, "The property iterator name should initially be null.");
            Assert.IsNotNull(model.Code, "The code property should be instantiated with some CodeDom object.");
            Assert.AreEqual(CodeBinaryOperatorType.LessThan, model.ConditionOperator, "The property condition operator should initially be the less than binary operator.");
            Assert.AreEqual(CodeBinaryOperatorType.Add, model.IncrementOperator, "The property increment operator should initially be the add binary operator.");
            Assert.AreEqual(1, model.IncrementAmount, "The increment amount should initially be set to 1.");
            Assert.AreEqual(0, model.StartValue, "The start value should initially be set to 0.");
            Assert.AreEqual(0, model.EndValue, "The end value should initially be set to 0.");

            // Verify read and write access of properties.
            Assert.IsTrue(GlobalAsserts.CanWrite((BaseForModel x) => x.IteratorName), "The model's iterator name property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.IteratorName), "The model's iterator name property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((BaseForModel x) => x.StartValue), "The model's start value property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.StartValue), "The model's start value property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((BaseForModel x) => x.EndValue), "The model's end value property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.EndValue), "The model's end value property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((BaseForModel x) => x.ConditionOperator), "The model's condition operator property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.ConditionOperator), "The model's condition operator property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((BaseForModel x) => x.IncrementOperator), "The model's increment operator value property should be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.IncrementOperator), "The model's increment operator property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((BaseForModel x) => x.IncrementAmount), "The model's increment amount property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.IncrementAmount), "The model's increment amount property should be retrievable.");

            Assert.IsFalse(GlobalAsserts.CanWrite((BaseForModel x) => x.Code), "The model's code property should not be globally assignable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseForModel x) => x.Code), "The model's code property should be retrievable.");

            // Edit the object's values and verify update.
            model.IteratorName = _iterator;
            model.StartValue = _startValue;
            model.EndValue = _endValue;
            model.ConditionOperator = _condition;
            model.IncrementOperator = _increment;

            Assert.AreEqual(_iterator, model.IteratorName, "The model's iterator name property differs from expected.");
            Assert.AreEqual(_startValue, model.StartValue, "The model's start value property differs from expected.");
            Assert.AreEqual(_endValue, model.EndValue, "The model's end value property differs from expected.");
            Assert.AreEqual(_condition, model.ConditionOperator, "The model's condition operator property differs from expected.");
            Assert.AreEqual(_increment, model.IncrementOperator, "The model's increment operator property differs from expected.");
        }
    }
}
