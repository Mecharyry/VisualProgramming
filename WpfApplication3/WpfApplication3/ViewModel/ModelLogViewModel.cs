using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication3.Common;

namespace WpfApplication3.ViewModel
{
    public class ModelLogViewModel
    {
        #region Members
        private string _path;
        private bool _canOpen = true;
        private bool _canExecute = true;
        private CompilerResults _results;
        private List<string> _messages = new List<string>();
        #endregion

        #region Properties
        public string Path 
        {
            get { return _path; }
            set { _path = value; }
        }

        public bool CanOpen
        {
            get { return _canOpen; }
            set { _canOpen = value; }
        }

        public bool CanExecute 
        {
            get { return _canExecute; }
            set { _canExecute = value; }
        }

        public CompilerResults results
        {
            get { return _results; }
            set { _results = value; }
        }

        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }
        #endregion

        #region Constructor
        public ModelLogViewModel(CompilerResults results, string path)
        {
            _path = path;
            _results = results;

            if (results.Errors.Count > 0)
            {
                Messages.Add("Errors building " + path + " into " + results.PathToAssembly);

                foreach (CompilerError error in results.Errors)
                {
                    if (error.IsWarning == false)
                    {
                        CanExecute = false;
                        Messages.Add("Error: " + error.ToString() + "\nLine Numbers: " +
                            error.Line);
                    }
                }
            }
            else
            {
                Messages.Add("Source model " + path + " into " + results.PathToAssembly + " successfully.");
            }
        }
        #endregion

        #region Commands
        public void OpenCommandExecute()
        {
            if (Path != null && File.Exists(Path))
            {
                System.Diagnostics.Process.Start(Path);
            }
            else
            {
                Messages.Add("Could not open file.\nPath: " + Path);
            }
        }

        private ICommand _openCommand;
        public ICommand OpenCommand
        {
            get
            {
                if (_openCommand == null)
                {
                    _openCommand = new Command(this.OpenCommandExecute);
                }
                return _openCommand;
            }
        }

        public void ExecuteCommandExecute()
        {
            if (results != null && File.Exists(results.PathToAssembly))
            {
                System.Diagnostics.Process.Start(results.PathToAssembly);
            }
            else
            {
                Messages.Add("Could not open file.\nPath: " + results.PathToAssembly);
            }
        }

        private ICommand _executeCommand;
        public ICommand ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new Command(this.ExecuteCommandExecute);
                }
                return _executeCommand;
            }
        }
        #endregion
    }
}
