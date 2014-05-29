using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    
    public class VariablesViewModel
    {
        #region Members
        private VariablesDB _currentVariablesDB;
        #endregion

        #region Properties
        public VariablesDB CurrentVariablesDB 
        {
            get { return _currentVariablesDB; }
        }
        #endregion

        #region Constructor
        public VariablesViewModel()
            : base()
        {
            _currentVariablesDB = VariablesDB.Instance;
        }
        #endregion

        #region Commands
        public void DeleteVariableCommandExecute(object selectedItem)
        {
            if (CurrentVariablesDB.GlobalVariables.Contains(selectedItem))
            {
                CurrentVariablesDB.GlobalVariables.Remove(selectedItem as VariableModel);
            }
        }

        private ICommand _deleteVariableCommand;
        public ICommand DeleteVariableCommand
        {
            get
            {
                if (_deleteVariableCommand == null)
                {
                    _deleteVariableCommand = new Command<object>(this.DeleteVariableCommandExecute);
                }
                return _deleteVariableCommand;
            }
        }

        public void AddVariableCommandExecute(object sender)
        {
            if (sender != null)
            {   // Transform to string and pass to AddVariable method.
                string variableName = sender as string;

                // Add variable to the database.
                if (CurrentVariablesDB.GlobalVariables.FirstOrDefault(x => x.VariableName == variableName) == null &&
                    variableName.Length > 0)
                {
                    CurrentVariablesDB.GlobalVariables.Add(new VariableModel(variableName, Constants.VariableType.Global));
                    CurrentVariablesDB.VariableName = string.Empty;
                }
            }
        }

        private ICommand _addVariableCommand;
        public ICommand AddVariableCommand
        {
            get
            {
                if (_addVariableCommand == null)
                {
                    _addVariableCommand = new Command<object>(this.AddVariableCommandExecute);
                }
                return _addVariableCommand;
            }
        }
        #endregion
    }
}
