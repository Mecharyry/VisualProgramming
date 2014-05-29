using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace WpfApplication3.Database
{
    public class VariablesDB: Singleton<VariablesDB>, INotifyPropertyChanged
    {
        #region Members
        private ObservableCollection<VariableModel> _globalVariables = new ObservableCollection<VariableModel>();
        private static List<ExcelConnectionModel> _connections = new List<ExcelConnectionModel>();
        private static List<ExcelForLoopModel> _forLoops = new List<ExcelForLoopModel>();
        private string _variableName;
        #endregion

        #region Properties
        public ObservableCollection<VariableModel> GlobalVariables
        {
            get { return _globalVariables; }
        }

        public string VariableName 
        {
            get { return _variableName; }
            set 
            { 
                _variableName = value;
                NotifyPropertyChanged("VariableName");
            }
        }

        public static List<ExcelConnectionModel> Connections 
        {
            get { return _connections; }
            set { _connections = value; }
        }

        public static List<ExcelForLoopModel> ForLoops
        {
            get { return _forLoops; }
            set { _forLoops = value; }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
