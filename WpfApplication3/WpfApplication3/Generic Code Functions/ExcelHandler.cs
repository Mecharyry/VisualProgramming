using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using msExcel = Microsoft.Office.Interop.Excel;

namespace WpfApplication3.Generic_Code_Functions
{
    public static class ExcelHandler
    {
        public static CodeMethodReferenceExpression ActiveWorkbook(string currentApplication)
        {
            return new CodeMethodReferenceExpression()
            {
                TargetObject = new CodeVariableReferenceExpression(currentApplication),
                MethodName = Helper.GetMemberName((msExcel.Application c) => c.ActiveWorkbook)
            };
        }

        public static CodeMethodReferenceExpression WorksheetsCount(string currentWorkbook)
        {
            return new CodeMethodReferenceExpression()
             {
                 TargetObject = new CodeVariableReferenceExpression(currentWorkbook),
                 MethodName = Helper.GetMemberName((msExcel.Workbook x) => x.Worksheets) + "." + Helper.GetMemberName((msExcel.Workbook x) => x.Worksheets.Count)
             };
        }

        public static CodeVariableDeclarationStatement CurrentWorksheet(string currentWorkbook, string iterator)
        {
            return new CodeVariableDeclarationStatement()
            {
                Type = new CodeTypeReference(typeof(msExcel.Worksheet)),
                Name = iterator + "Worksheet",
                InitExpression = new CodeCastExpression(typeof(msExcel.Worksheet), 
                    new CodeMethodReferenceExpression()
                {
                    TargetObject = new CodeVariableReferenceExpression(currentWorkbook),
                    MethodName = Helper.GetMemberName((msExcel.Workbook x) => x.Worksheets) + "[" + iterator + "]"
                })
            };
        }

        public static CodeMethodInvokeExpression SelectWorksheet(CodeVariableDeclarationStatement currentWorksheet)
        {
            return new CodeMethodInvokeExpression()
            {
                Method = new CodeMethodReferenceExpression()
                {
                    TargetObject = new CodeVariableReferenceExpression(currentWorksheet.Name),
                    MethodName = Helper.GetMethod((msExcel.Worksheet x) => x.Select(Type.Missing))   
                }
            };
        }
    }
}
