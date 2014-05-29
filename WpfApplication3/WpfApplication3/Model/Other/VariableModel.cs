using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;

namespace WpfApplication3.Model
{
    
    public class VariableModel
    {
        #region Members
        private string _variableName;
        private Constants.VariableType _variableType;
        #endregion

        #region Properties
        public string VariableName 
        {
            get { return _variableName; }
        }

        public Constants.VariableType VariableType 
        {
            get { return _variableType; }
        }

        public VariableModel(string variableName, Constants.VariableType type)
        {
            _variableName = variableName;
            _variableType = type;
        }

        public object Code 
        {
            get 
            {
                return new CodeVariableDeclarationStatement(new CodeTypeReference(typeof(string)), VariableName);
            }
        }
        #endregion
    }
}
