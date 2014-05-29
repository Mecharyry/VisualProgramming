using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Generic_Code_Functions;
using WpfApplication3.PropertiesGrid.Editors;
using msExcel = Microsoft.Office.Interop.Excel;

namespace WpfApplication3.Model.Code_Control
{
    [XmlRoot]
    public class ExcelConnectionModel : BaseCodeModel
    {
        #region Members
        private string _excelPath;
        private static int _noConnections = 0;

        private string _application;
        private string _workbook;
        #endregion

        #region Properties
        [XmlElement, EditorAttribute(typeof(FileNameEditor), typeof(UITypeEditor)), 
        Browsable(true)]
        public string ExcelPath 
        {
            get { return _excelPath; }
            set { _excelPath = value; }
        }

        [XmlIgnore, Browsable(false)]
        public int NoConnections 
        {
            get { return _noConnections; } 
        }

        [XmlElement, Browsable(false)]
        public string CodeApplication 
        {
            get { return _application; }
            set { _application = value; }
        }

        [XmlElement, Browsable(false)]
        public string CodeWorkbook 
        {
            get { return _workbook; }
            set { _workbook = value; }
        }

        [XmlIgnore, Browsable(false)]
        public override object Code
        {
            get
            {
                CodeStatementCollection statements = new CodeStatementCollection();

                // Application excelApplication = ConnectToExcel(excelPath);
                CodeVariableDeclarationStatement excelApplication = new CodeVariableDeclarationStatement()
                {
                    Name = CodeApplication,
                    Type = new CodeTypeReference(typeof(msExcel.Application)),

                    InitExpression = new CodeMethodInvokeExpression(
                        new CodeThisReferenceExpression(), "Connection",
                            new CodeExpression[] { new CodePrimitiveExpression(ExcelPath) })
                };

                // Workbook workbook = excelApplication.ActiveWorkbook;
                CodeVariableDeclarationStatement workbook = new CodeVariableDeclarationStatement()
                {
                    Name = CodeWorkbook,
                    Type = new CodeTypeReference(typeof(msExcel.Workbook)),
                    InitExpression = ExcelHandler.ActiveWorkbook(excelApplication.Name)
                };

                statements.Add(excelApplication);
                statements.Add(workbook);

                return statements as object;
            }
        }
        #endregion

        #region Constructor
        public ExcelConnectionModel() // Used for serialisation.
            : base(Constants.ApplicationSet.Excel, "Excel_Connection",
            Constants.ExcelConnectionImage, false)
        {
            if (IsDisplayOnly == false)
            {   // Drag and drop, edit control name to be unique.
                ControlName = ControlName + _noConnections++;
                _application = ControlName + "Application";
                _workbook = ControlName + "Workbook";
            }
        }
        #endregion
    }
}
