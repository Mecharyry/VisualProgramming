using System;
using System.Activities.Presentation.PropertyEditing;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Generic_Code_Functions;
using WpfApplication3.PropertiesGrid.Editors;

namespace WpfApplication3.Model.Code_Control
{
    [XmlRoot]
    public class ExcelForLoopModel : BaseForModel
    {
        #region Collections
        public enum SearchType
        {
            Worksheet = 1,
            Row = 2,
            Column = 3
        }

        public enum SearchCondition
        {
            Name = 1,
            Index = 2,
            All = 3
        }
        #endregion

        #region Members
        private SearchType _searchType;
        private SearchCondition _searchCondition;
        private ExcelConnectionModel _connection;
        private string _containsName;
        private int _indexOf;
        #endregion

        #region Properties
        [XmlElement, Category(), DisplayName("Search for:")]
        public SearchType ForEach
        {
            get { return _searchType; }
            set 
            { 
                _searchType = value;
                Category = new List<string>()
                {
                    { _searchType.ToString() }
                };
            }
        }

        [XmlElement, Category("Worksheet"), DisplayName("Search by:")]
        public SearchCondition Condition 
        {
            get { return _searchCondition; }
            set 
            { 
                _searchCondition = value;
                Category = new List<string>()
                {
                    { _searchType.ToString() },
                    { _searchCondition.ToString() }
                };
            }
        }

        [XmlElement, Editor(typeof(ListEditor), typeof(PropertyValueEditor)),
        DisplayName("Connection:")]
        public ExcelConnectionModel Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                if (value != null)
                {
                    _connection = value;
                }
            }
        }

        [XmlElement, Category("Name"), DisplayName("Contains name:")]
        public string ContainsName
        {
            get { return _containsName; }
            set { _containsName = value; }
        }

        [XmlElement, Category("Index"), DisplayName("Index of:")]
        public int IndexOf
        {
            get
            {
                return _indexOf;
            }
            set
            {
                _indexOf = value;
            }
        }

        [XmlIgnore]
        public override object Code
        {
            get
            {
                CodeIterationStatement forLoop = new CodeIterationStatement();

                switch (ForEach)
                {
                    case SearchType.Worksheet:
                        switch (Condition)
                        {
                            case SearchCondition.All:
                                try
                                {
                                    forLoop = new CodeIterationStatement(
                                        // Intial variable and corresponding value.
                                       new CodeVariableDeclarationStatement(typeof(int), ControlName, new CodePrimitiveExpression(1)),
                                        // Condition statement.
                                       new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(ControlName),
                                       CodeBinaryOperatorType.LessThanOrEqual, ExcelHandler.WorksheetsCount(Connection.CodeWorkbook)),
                                        // Increment statement.
                                       new CodeAssignStatement(new CodeVariableReferenceExpression(ControlName), new CodeBinaryOperatorExpression(
                                       new CodeVariableReferenceExpression(ControlName), CodeBinaryOperatorType.Add, new CodePrimitiveExpression(1))));

                                    CodeVariableDeclarationStatement currentWorksheet = ExcelHandler.CurrentWorksheet(Connection.CodeWorkbook, ControlName);
                                    forLoop.Statements.Add(currentWorksheet);
                                    forLoop.Statements.Add(ExcelHandler.SelectWorksheet(currentWorksheet));
                                }
                                catch (Exception ex) { }
                                break;

                            case SearchCondition.Index:
                                break;

                            case SearchCondition.Name:
                                break;
                        }
                        break;
                }
                return forLoop;
            }
        }
        #endregion

        #region Constructor
        public ExcelForLoopModel() // Used for serialisation.
            : base(Constants.ApplicationSet.Excel, 
            Constants.ExcelApplicationImage)
        {
            ForEach = SearchType.Worksheet;
            Condition = SearchCondition.All;
        }
        #endregion

        #region Methods
        public override void RefreshPropertyCollections()
        {
            base.RefreshPropertyCollections();

            // Grab connections list.
            ExcelConnectionModel model = VariablesDB.Connections.FirstOrDefault(x => x == Connection);

            if (model != null)
            {
                // Remove the connection.
                Connection = null;
            }
        }
        #endregion
    }
}
