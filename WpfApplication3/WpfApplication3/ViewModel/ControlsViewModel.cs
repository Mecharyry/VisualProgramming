using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Interfaces;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class ControlsViewModel
    {
        #region Members
        private ControlsDB _currentControlsDB;
        #endregion

        #region Properties
        public ControlsDB CurrentControlsDB 
        {
            get { return _currentControlsDB; }
        }
        #endregion

        public ControlsViewModel()
        {
            _currentControlsDB = new ControlsDB();
        }
    }
}
