using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication3.Common;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;
using msExcel = Microsoft.Office.Interop.Excel;

namespace WpfApplication3.Code_Generator
{
    public class GeneratorManager : Singleton<GeneratorManager>
    {
        #region Members
        private CodeDomProvider _provider = CodeDomProvider.CreateProvider("cs");
        private CodeCompileUnit _ccu = new CodeCompileUnit();
        private CodeObject _topLevelParent;

        private String _entryPoint = String.Empty;
        private String _sourceFile = "Sample";
        private String _exe = "Sample.exe";
        private MainModel _mainModel;

        private static List<String> _assemblies = new List<string>()
        {
            "Microsoft.Office.Interop.Excel.dll",
            "System.dll",
            "Microsoft.CSharp.dll"
        };
        #endregion

        #region Class Properties
        public CodeDomProvider Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }

        public CodeCompileUnit CCU
        {
            get { return _ccu; }
            set { _ccu = value; }
        }

        public CodeObject TopLevelParent
        {
            get { return _topLevelParent; }
            private set { _topLevelParent = value; }
        }

        public String EntryPoint
        {
            get { return _entryPoint; }
            set { _entryPoint = value; }
        }

        public String SourceFile
        {
            get { return _sourceFile; }
            set { _sourceFile = value; }
        }

        public String Exe
        {
            get { return _exe; }
            set { _exe = value; }
        }

        public static List<String> Assemblies
        {
            get { return _assemblies; }
            private set { _assemblies = value; }
        }

        public MainModel Model
        {
            get { return _mainModel; }
            set { _mainModel = value; }
        }
        #endregion

        #region Constructors
        // Singleton, no constructors permitted.
        #endregion

        #region Generic Class Creator
        public void CreateBasicClassStructure()
        {
            // Create a namespace.
            CodeNamespace codeNamespace = CreateNamespace();
            CCU.Namespaces.Add(codeNamespace);

            // Add a class.
            CodeTypeDeclaration codeClass = new CodeTypeDeclaration("class01");
            codeNamespace.Types.Add(codeClass);

            // Create entry point.
            CodeEntryPointMethod entryPoint = new CodeEntryPointMethod();
            codeClass.Members.Add(entryPoint);

            // Add connection method.
            CodeMemberMethod member = CreateConnectionFunction();
            codeClass.Members.Add(member);

            // Add steps method.
            member = CreateStepsFunction();
            codeClass.Members.Add(member);

            // Add reference to class created.
            CodeVariableDeclarationStatement handler = new CodeVariableDeclarationStatement()
            {
                Name = "something",
                Type = new CodeTypeReference(codeClass.Name),

                InitExpression = new CodeObjectCreateExpression()
                {
                    CreateType = new CodeTypeReference(codeClass.Name)
                }
            };

            CodeMethodInvokeExpression invoker = new CodeMethodInvokeExpression(
                    new CodeVariableReferenceExpression(handler.Name), member.Name);

            entryPoint.Statements.Add(handler);
            entryPoint.Statements.Add(invoker);
            TopLevelParent = member;
            EntryPoint = codeNamespace.Name + "." + codeClass.Name;
        }

        public void GenerateModel(List<DesignerViewModel> designers, List<VariableModel> variables)
        {
            _ccu = new CodeCompileUnit();

            // Process the model.
            CreateBasicClassStructure();
            
            // Add variables to method.
            ProcessVariables(variables);

            ProcessModel(designers);

            Boolean outcome = GenerateCode();
            if (outcome == true)
            {
                CompilerResults results = CompileCode();
                ModelLogView view = new ModelLogView(new ModelLogViewModel(results, SourceFile));
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("An error occurred processing the model. Please ensure all properties are correctly filled.");
            }

            _ccu = null;
        }

        private void ProcessVariables(List<VariableModel> variables)
        {
            object parent = TopLevelParent;
            
            MemberInfo containsStatements = parent.GetType().GetProperty("Statements");
            if (containsStatements != null)
            {
                for (int i = 0; i < variables.Count; i++)
                {
                    object codeToAdd = variables[i].Code;
                    // Retrieve getter and invoke getter.
                    CodeStatementCollection info = parent.GetType().GetProperty("Statements").GetMethod.Invoke(parent, null) as CodeStatementCollection;

                    if (codeToAdd.GetType() == typeof(CodeVariableDeclarationStatement))
                    {
                        info.Add(codeToAdd as CodeVariableDeclarationStatement);
                    }
                }
            }
        }

        private void ProcessModel(List<DesignerViewModel> designers)
        {
            // Go through each of the designers.
            for (int designerIndex = 0; designerIndex < designers.Count; designerIndex++)
            {
                // Determine whether the designer contains any connections and whether one of those connections is the start.
                if (designers[designerIndex].Connections.Count == 0 ||
                    designers[designerIndex].Connections.FirstOrDefault(x => x.Start.GetType() == typeof(StartModel)) == null)
                {   // Remove designer.
                    designers.RemoveAt(designerIndex);
                    designerIndex--;
                }
                else
                {   // Start present continue processing.
                    // Grab a reference to the start connection.
                    ConnectionModel connection = designers[designerIndex].Connections.First(x => x.Start.GetType() == typeof(StartModel));
                    if (connection != null &&
                        connection.End != null)
                    {
                        AddCode(connection.End, designers[designerIndex].Parent);

                        for (int i = 0; i < designers[designerIndex].Connections.Count - 1; i++)
                        {
                            // Locate the control that contains 'connection'.
                            connection = designers[designerIndex].Connections.FirstOrDefault(x => x.Start.Id == connection.End.Id);
                            if (connection != null &&
                                connection.End != null)
                            {
                                AddCode(connection.End, designers[designerIndex].Parent);
                            }
                        }
                    }
                }
            }
        }

        private void AddCode(object control, object parent)
        {
            // Transform the end point into its associated object and retrieve code.
            if (control.GetType() == typeof(ControlViewModel))
            {
                ControlViewModel model = control as ControlViewModel;
                object codeToAdd = model.CurrentCodeModel.Code;

                if (parent == null)
                {   // Assume root, add to custom method.
                    parent = TopLevelParent;
                }
                else
                {    // Has already been added; retrieve.
                    ControlViewModel temp = parent as ControlViewModel;

                    if (temp.CurrentCodeModel.GetType() == typeof(ExcelForLoopModel))
                    {   // Locate the for loop.
                        parent = GetLoop(temp.CurrentCodeModel.ControlName);
                    }
                }

                MemberInfo containsStatements = parent.GetType().GetProperty("Statements");
                if (containsStatements != null)
                {   // Statements present.

                    // Retrieve getter and invoke getter.
                    CodeStatementCollection info = parent.GetType().GetProperty("Statements").GetMethod.Invoke(parent, null) as CodeStatementCollection;

                    // codeToAdd can be a codeStatement or CodeExpression or collection.
                    if (codeToAdd.GetType() == typeof(CodeStatementCollection))
                    {
                        CodeStatementCollection collection1 = codeToAdd as CodeStatementCollection;

                        for (int i = 0; i < collection1.Count; i++)
                        {
                            info.Add(collection1[i] as CodeStatement);
                        }
                    }
                    else if (codeToAdd.GetType() == typeof(CodeExpression) ||
                        codeToAdd.GetType().BaseType == typeof(CodeExpression))
                    {
                        info.Add(codeToAdd as CodeStatement);
                    }
                    else if (codeToAdd.GetType() == typeof(CodeStatement) ||
                        codeToAdd.GetType().BaseType == typeof(CodeStatement))
                    {
                        info.Add(codeToAdd as CodeStatement);
                    }
                }
            }
        }

        public CodeNamespace CreateNamespace()
        {
            CodeNamespace codeNamespace = new CodeNamespace("codeNamespace");

            for (int i = 0; i < Assemblies.Count; i++)
            {
                // Remove dll from the name.
                String usingName = Assemblies[i].Remove(Assemblies[i].IndexOf(".dll"));
                codeNamespace.Imports.Add(new CodeNamespaceImport(usingName));
            }

            return codeNamespace;
        }

        public CodeMemberMethod CreateStepsFunction()
        {
            // Create the connection method.
            CodeMemberMethod member = new CodeMemberMethod()
            {
                Name = "Steps",
            };

            return member;
        }

        public CodeMemberMethod CreateConnectionFunction()
        {
            // Create the connection method.
            CodeMemberMethod member = new CodeMemberMethod()
            {
                Name = "Connection",
                ReturnType = new CodeTypeReference(typeof(msExcel.Application))
            };

            #region Method Statements
            CodeParameterDeclarationExpression excelPath = new CodeParameterDeclarationExpression()
            {
                Name = "excelPath",
                Type = new CodeTypeReference(typeof(String))
            };
            member.Parameters.Add(excelPath);

            CodeVariableDeclarationStatement excelApplication = new CodeVariableDeclarationStatement()
            {
                Name = "excelApplication",
                Type = new CodeTypeReference(typeof(msExcel.Application)),

                InitExpression = new CodeObjectCreateExpression(
                    new CodeTypeReference(typeof(msExcel.Application)))
            };
            member.Statements.Add(excelApplication);

            CodeVariableDeclarationStatement excelWorkbook = new CodeVariableDeclarationStatement()
            {
                Name = "excelWorkbook",
                Type = new CodeTypeReference(typeof(msExcel.Workbook)),

                InitExpression = new CodeFieldReferenceExpression(
                    new CodeVariableReferenceExpression(excelApplication.Name),
                        "Workbooks.Open(" + excelPath.Name + ")")
            };
            member.Statements.Add(excelWorkbook);

            CodeVariableDeclarationStatement excelWindow = new CodeVariableDeclarationStatement()
            {
                Name = "excelWindow",
                Type = new CodeTypeReference(typeof(msExcel.Window)),

                InitExpression = new CodeFieldReferenceExpression(
                    new CodeVariableReferenceExpression(excelApplication.Name), "ActiveWindow")
            };
            member.Statements.Add(excelWindow);
            #endregion

            CodeAssignStatement assign = new CodeAssignStatement()
            {
                Left = new CodeMethodReferenceExpression()
                {
                    TargetObject = new CodeVariableReferenceExpression(excelApplication.Name),
                    MethodName = Helper.GetMemberName((msExcel.Application c) => c.Visible)
                },
                Right = new CodePrimitiveExpression(true)
            };
            member.Statements.Add(assign);

            // Add return statement.
            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement()
            {
                Expression = new CodeVariableReferenceExpression(excelApplication.Name)
            };
            member.Statements.Add(returnStatement);

            return member;
        }
        #endregion

        #region Code Generation and Compilation
        public Boolean GenerateCode()
        {
            // If source file already contains extension, do not add it.
            if (!SourceFile.Contains(Provider.FileExtension))
            {
                if (Provider.FileExtension[0] == '.')
                {
                    SourceFile = SourceFile + Provider.FileExtension;
                }
                else
                {
                    SourceFile = SourceFile + "." + Provider.FileExtension;
                }
            }

            string path = Environment.CurrentDirectory + "\\" + SourceFile;
            if (File.Exists(path))
            {
                File.Delete(path);
                File.Create(path).Close();
            }

            IndentedTextWriter tw = null;

            try
            {
                tw = new IndentedTextWriter(new StreamWriter(path, false), "   ");
                Provider.GenerateCodeFromCompileUnit(CCU, tw, new CodeGeneratorOptions());
                tw.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (tw != null)
                {
                    tw.Close();
                }
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public CompilerResults CompileCode()
        {
            CompilerParameters parameters = new CompilerParameters();

            parameters.GenerateExecutable = true;

            parameters.OutputAssembly = "Sample.exe";

            parameters.IncludeDebugInformation = true;

            for (int assemblyIndex = 0; assemblyIndex < Assemblies.Count; assemblyIndex++)
            {
                if (!parameters.ReferencedAssemblies.Contains(Assemblies[assemblyIndex]))
                {
                    parameters.ReferencedAssemblies.Add(Assemblies[assemblyIndex]);
                }
            }

            parameters.GenerateInMemory = false;

            parameters.WarningLevel = 3;

            parameters.TreatWarningsAsErrors = false;

            parameters.CompilerOptions = "/optimize";

            if (_provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                parameters.MainClass = EntryPoint;
            }

            CompilerResults results = _provider.CompileAssemblyFromFile(parameters, SourceFile);

            if (results.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}",
                    SourceFile, results.PathToAssembly);

                foreach (CompilerError error in results.Errors)
                {
                    Console.WriteLine("Error: {0}\nLine Number: {1}", error.ToString(), error.Line);
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    SourceFile, results.PathToAssembly);
                Console.WriteLine("{0} temporary files created during the compilation.", parameters.TempFiles.Count.ToString());
            }

            return results;
        }
        #endregion

        #region Helper Functions
        public CodeIterationStatement GetLoop(String iteratorName)
        {
            CodeNamespaceCollection namespaces = CCU.Namespaces;

            // Iterate through each namespace.
            for (int namespaceIndex = 0; namespaceIndex < namespaces.Count; namespaceIndex++)
            {
                CodeTypeDeclarationCollection types = namespaces[namespaceIndex].Types;

                // Iterate through each type(class) in each namespace.
                for (int typeIndex = 0; typeIndex < types.Count; typeIndex++)
                {
                    CodeTypeMemberCollection members = types[typeIndex].Members;

                    // Iterate through each member(method) in each type(class).
                    for (int memberIndex = 0; memberIndex < members.Count; memberIndex++)
                    {
                        CodeMemberMethod member = members[memberIndex] as CodeMemberMethod;
                        CodeStatementCollection statements = member.Statements;

                        CodeIterationStatement statement = IterateThroughLoopStatements(iteratorName, statements);

                        // If a matching statement is found, return it.
                        if (statement != null)
                        {
                            return statement;
                        }
                    }
                }
            }
            return null;
        }

        private CodeIterationStatement IterateThroughLoopStatements(String searchCriteria, CodeStatementCollection statements)
        {
            for (int statementIndex = 0; statementIndex < statements.Count; statementIndex++)
            {
                // If it is a code iteration statement.
                if (statements[statementIndex].GetType().Equals(typeof(CodeIterationStatement)))
                {
                    // Cast statement to codeIteration statement.
                    CodeIterationStatement statement = statements[statementIndex] as CodeIterationStatement;
                    // Retrieve the intialisation statement.
                    CodeVariableDeclarationStatement declaration = statement.InitStatement as CodeVariableDeclarationStatement;

                    // If the iterator name matches, return iteration statement.
                    if (declaration.Name.Equals(searchCriteria))
                    {
                        return statement;
                    }
                    else // Perform search down that iteration tree.
                    {
                        IterateThroughLoopStatements(searchCriteria, statement.Statements);
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
