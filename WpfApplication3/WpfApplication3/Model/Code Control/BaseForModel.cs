using System;
using System.Activities.Presentation.PropertyEditing;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.PropertiesGrid.Editors;

namespace WpfApplication3.Model.Code_Control
{
    [XmlRoot, XmlInclude(typeof(ExcelForLoopModel))]
    public class BaseForModel : BaseCodeModel
    {
        #region Members
        private static int _id = 0;
        private string _iteratorName;
        private int _endValue = 0;
        private int _startValue = 0;
        private CodeBinaryOperatorType _conditionOperator = CodeBinaryOperatorType.LessThan;
        private CodeBinaryOperatorType _incrementOperator = CodeBinaryOperatorType.Add;
        private int _incrementAmount = 1;
        #endregion

        #region Properties
        [Category("User Defined")]
        public string IteratorName
        {
            get { return _iteratorName; }
            set { _iteratorName = value; }
        }

        [Category("User Defined")]
        public int StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }

        [Category("User Defined")]
        public int EndValue
        {
            get { return _endValue; }
            set { _endValue = value; }
        }

        [Category("User Defined")]
        public CodeBinaryOperatorType ConditionOperator
        {
            get { return _conditionOperator; }
            set { _conditionOperator = value; }
        }

        [Category("User Defined")]
        public CodeBinaryOperatorType IncrementOperator
        {
            get { return _incrementOperator; }
            set { _incrementOperator = value; }
        }

        [Category("User Defined")]
        public int IncrementAmount
        {
            get { return _incrementAmount; }
        }

        [Browsable(false)]
        public override object Code 
        {
            get
            {
                //CodeIterationStatement forLoop = new CodeIterationStatement(
                //    // Intial variable and corresponding value.
                //    new CodeVariableDeclarationStatement(typeof(int), _iteratorName, new CodePrimitiveExpression(1)),
                //    // Condition statement.
                //    new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(_iteratorName),
                //    conditionOperators[_conditionOperator], new CodePrimitiveExpression(_endValue)),
                //    // Increment statement.
                //    new CodeAssignStatement(new CodeVariableReferenceExpression(_iteratorName), new CodeBinaryOperatorExpression(
                //    new CodeVariableReferenceExpression(_iteratorName), incrementOperators[_incrementOperator], new CodePrimitiveExpression(1))));
                return new object();
            }
        }
        #endregion

        #region Constructor
        public BaseForModel() // Used for serialisation.
            : this(Constants.ApplicationSet.System, 
            Constants.ExcelConnectionImage)
        {}

        public BaseForModel(Constants.ApplicationSet application, 
            string imageSource)
            : base(application, "For Loop", imageSource, true)
        {
            if (IsDisplayOnly == false)
            {   // Drag and drop, edit control name to be unique.
                ControlName = ControlName.Replace(" ", "") + _id++;
            }
        }
        #endregion
    }
}
