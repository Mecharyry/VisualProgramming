using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class ApplicationsViewModel
    {
        #region Members
        private ApplicationsDB _currentApplicationsDB;
        #endregion

        #region Properties
        public ApplicationsDB CurrentApplicationsDB 
        {
            get { return _currentApplicationsDB; }
            set { _currentApplicationsDB = value; }
        }
        #endregion

        public ApplicationsViewModel()
        {
            _currentApplicationsDB = new ApplicationsDB();
        }
    }
}
