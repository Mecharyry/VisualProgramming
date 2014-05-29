using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;
using WpfApplication3.Model;
using System.Collections.Generic;
using WpfApplication3.Common;
using VisualProgrammingUnitTesting.Common;
using System.Xml.Serialization;

namespace VisualProgrammingUnitTesting.Model_Unit_Tests
{
    [TestClass]
    public class BaseCodeModelTests
    {
        #region BaseCodeModel_Unit Test
        public static string _controlName = "extendsControl";
        private static string _imageSource = "imageSource.jpg";
        private static Constants.ApplicationSet _application = Constants.ApplicationSet.Access;
        private static object _code = "some code";
        private static bool _nestable = true;
        private static BaseCodeModel _parent = new ExcelConnectionModel();
        private static List<VariableModel> _variables = new List<VariableModel>() 
            { new VariableModel("variable01", Constants.VariableType.Connection) };

        [TestMethod]
        public void Properties_UnitTest()
        {
            Assert.IsTrue(typeof(BaseCodeModel).IsAbstract, "ControlModel Class should be abstract.");

            // Extend the controlModel class and verify that all members are as expected.
            DesignerViewModel viewModel = new DesignerViewModel(new DesignerModel() { DesignerName = "Root"}, null);
            ExtendsControlModel control = new ExtendsControlModel();

            // Verify that the control contains the expected properties.
            Assert.AreEqual(_parent, control.Parent, "The parent property differs from expected.");
            Assert.AreEqual(_nestable, control.Nestable, "The nestable property differs from expected.");
            Assert.AreEqual(_controlName, control.ControlName, "The control name differs from expected.");
            Assert.AreEqual(_imageSource, control.ImageSource, "The image source differs from expected.");
            Assert.AreEqual(_application, control.Application, "The application differs from expected.");
            Assert.AreEqual(_code, control.Code, "The control's code differs from expected.");

            // Verify read and write access for each property.
            Assert.IsFalse(GlobalAsserts.CanWrite((BaseCodeModel x) => x.Application), "The control model's application property should only be assignable in class.");
            Assert.IsFalse(GlobalAsserts.CanWrite((BaseCodeModel x) => x.Nestable), "The control model's nestable property should only be assignable in class.");
            Assert.IsTrue(GlobalAsserts.CanWrite((BaseCodeModel x) => x.ControlName), "The control model's control name property should only be assignable in class.");
            Assert.IsFalse(GlobalAsserts.CanWrite((BaseCodeModel x) => x.ImageSource), "The control model's image source property should only be assignable in class.");
            Assert.IsFalse(GlobalAsserts.CanWrite((BaseCodeModel x) => x.Code), "The control model's code property should only be assignable in class.");
            Assert.IsTrue(GlobalAsserts.CanWrite((BaseCodeModel x) => x.Parent), "The control model's parent property should be globally assignable.");


            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.Application), "The control model's application property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.Nestable), "The control model's nestable property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.ControlName), "The control model's control name property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.ImageSource), "The control model's image source property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.Code), "The control model's code property should be retrievable.");
            Assert.IsTrue(GlobalAsserts.CanRead((BaseCodeModel x) => x.Parent), "The control model's parent property should be retrievable.");
        }

        [XmlRoot]
        public class ExtendsControlModel : BaseCodeModel
        {
            public ExtendsControlModel()
                : base(_application, _controlName, _imageSource, _nestable)
            {
                Parent = _parent;
            }

            [XmlIgnore]
            public override object Code
            {
                get
                {
                    return _code;
                }
            }
        }
        #endregion
    }
}
