using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication3.Code_Generator;
using WpfApplication3.Common;
using System.CodeDom.Compiler;
using VisualProgrammingUnitTesting.Common;
using Microsoft.CSharp;
using System.CodeDom;
using System.IO;

namespace VisualProgrammingUnitTesting.Code_Generator_Unit_Tests
{
    [TestClass]
    public class CodeGeneratorTests
    {
        [TestMethod]
        public void Properties_UnitTest()
        {
            // Verify that the generator manager extends singleton.
            GeneratorManager manager = new GeneratorManager();
            Singleton<GeneratorManager> singleton = manager as Singleton<GeneratorManager>;

            if (singleton == null)
            {
                Assert.Fail("The GeneratorManager class should extend from the singleton pattern.");
            }

            // Verify that all properties have the correct default values.
            Assert.AreEqual(typeof(CSharpCodeProvider), GeneratorManager.Instance.Provider.GetType(),
                "The provider property should automatically default to a CSharp provider.");

            Assert.IsNotNull(GeneratorManager.Instance.CCU, "The code compile unit property should automatically be initialised.");
            Assert.IsNull(GeneratorManager.Instance.TopLevelParent, "The top level parent property should default to null.");
            Assert.AreEqual(string.Empty, GeneratorManager.Instance.EntryPoint, "The entry point property should default to string.empty.");
            Assert.AreEqual("Sample", GeneratorManager.Instance.SourceFile, "The source file property should default to Sample.");
            Assert.AreEqual("Sample.exe", GeneratorManager.Instance.Exe, "The exe property should default to Sample.exe");
            Assert.IsNotNull(GeneratorManager.Assemblies, "The assemblies property should start initialised with all the desired assemblies present.");
            Assert.AreEqual(3, GeneratorManager.Assemblies.Count, "The assemblies property does not contain the expected number of assemblies.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.Provider), "The Provider property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.Provider), "The Provider property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.CCU), "The CCU property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.CCU), "The CCU property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.TopLevelParent), "The TopLevelParent property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.TopLevelParent), "The TopLevelParent property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.EntryPoint), "The EntryPoint property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.EntryPoint), "The EntryPoint property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.SourceFile), "The SourceFile property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.SourceFile), "The SourceFile property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => x.Exe), "The Exe property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => x.Exe), "The Exe property should be retrievable.");

            Assert.IsTrue(GlobalAsserts.CanWrite((GeneratorManager x) => GeneratorManager.Assemblies), "The Assemblies property should be writable.");
            Assert.IsTrue(GlobalAsserts.CanRead((GeneratorManager x) => GeneratorManager.Assemblies), "The Assemblies property should be retrievable.");
        }

        [TestMethod]
        public void GenerateCode_UnitTest()
        {
            // Create a namespace.
            CodeNamespace codeNamespace = new CodeNamespace("namespace01");
            GeneratorManager.Instance.CCU.Namespaces.Add(codeNamespace);

            // Add a class.
            CodeTypeDeclaration codeClass = new CodeTypeDeclaration("class01");
            codeNamespace.Types.Add(codeClass);

            // Create entry point.
            CodeEntryPointMethod entryPoint = new CodeEntryPointMethod();
            codeClass.Members.Add(entryPoint);

            // Execute the generate code funtion.
            GeneratorManager.Instance.GenerateCode();

            // Verify that a CSharp source file has been placed in the output directory.
            string path = Environment.CurrentDirectory;
            string [] files = Directory.GetFiles(path, GeneratorManager.Instance.SourceFile);

            Assert.AreNotEqual(0, files.Length, "The csharp source file could not be found in the output directory.");

            string expectedFile = @"namespace namespace01 {            public class class01 {                public static void Main() {        }    }}";
            string actualFile = string.Empty;

            StreamReader file = new StreamReader(files[0]);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("//"))
                {
                    actualFile = actualFile + line;
                }
            }
            file.Close();

            Assert.AreEqual(expectedFile, actualFile, "The expected file and the actual file produced differ.");
        }

        [TestMethod]
        public void CompileCode_Success_UnitTest()
        {
            // Create a namespace.
            CodeNamespace codeNamespace = new CodeNamespace("namespace01");
            GeneratorManager.Instance.CCU.Namespaces.Add(codeNamespace);

            // Add a class.
            CodeTypeDeclaration codeClass = new CodeTypeDeclaration("class01");
            codeNamespace.Types.Add(codeClass);

            // Create entry point.
            CodeEntryPointMethod entryPoint = new CodeEntryPointMethod();
            codeClass.Members.Add(entryPoint);

            // Execute the generate and compile code funtion.
            GeneratorManager.Instance.GenerateCode();
            CompilerResults results = GeneratorManager.Instance.CompileCode();

            // Verify that the compilation resulted in no errors.
            Assert.AreEqual(0, results.Errors.Count, "The file produced should have compiled successfully.");
        }

        [TestMethod]
        public void CompileCode_Fail_UnitTest()
        {
            // Create a namespace.
            CodeNamespace codeNamespace = new CodeNamespace("namespace01");
            GeneratorManager.Instance.CCU.Namespaces.Add(codeNamespace);

            // Add a class.
            CodeTypeDeclaration codeClass = new CodeTypeDeclaration("class01");
            codeNamespace.Types.Add(codeClass);

            // Execute the generate and compile code funtion.
            GeneratorManager.Instance.GenerateCode();
            CompilerResults results = GeneratorManager.Instance.CompileCode();

            // Verify that the compilation resulted in errors.
            Assert.AreEqual(1, results.Errors.Count, @"The file produced should not have compiled successfully
; missing entry point method.");
        }

        [TestMethod]
        public void BasicClassStructure_UnitTest()
        {
            GeneratorManager.Instance.CreateBasicClassStructure();
            GeneratorManager.Instance.GenerateCode();
            CompilerResults results = GeneratorManager.Instance.CompileCode();

            // Verify that the compilation resulted in no errors.
            Assert.AreEqual(0, results.Errors.Count, "The file produced should have compiled successfully.");

            // Verify that a CSharp source file has been placed in the output directory.
            string path = Environment.CurrentDirectory;
            string[] files = Directory.GetFiles(path, GeneratorManager.Instance.SourceFile);

            string expectedFileOutput = @"namespace codeNamespace {using Microsoft.Office.Interop.Excel;using System;using Microsoft.CSharp;public class class01 {public static void Main() {class01 something = new class01();something.Steps();}private Microsoft.Office.Interop.Excel.Application Connection(string excelPath) {Microsoft.Office.Interop.Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(excelPath);Microsoft.Office.Interop.Excel.Window excelWindow = excelApplication.ActiveWindow;excelApplication.Visible = true;return excelApplication;}private void Steps() {}}}";
            string actualFileOutput = string.Empty;

            StreamReader file = new StreamReader(files[0]);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Contains("//"))
                {
                    actualFileOutput = actualFileOutput + line.Trim();
                }
            }
            file.Close();

            Assert.AreEqual(expectedFileOutput.Trim(), actualFileOutput, "The expected file and the actual file produced differ.");
        }
    }
}
