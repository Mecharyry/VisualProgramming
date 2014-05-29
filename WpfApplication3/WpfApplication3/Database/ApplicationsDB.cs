using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using WpfApplication3.Model;

namespace WpfApplication3.Database
{
    public class ApplicationsDB
    {
        #region Members
        private readonly List<ApplicationModel> _applications;
        private ApplicationModel _currentApplication;
        #endregion

        #region Properties
        public List<ApplicationModel> Applications
        {
            get { return _applications; }
        }

        public ApplicationModel CurrentApplication
        {
            get { return _currentApplication; }
            set
            {
                _currentApplication = value;
                Mediator.Instance.Notify(Mediator.ViewModelMessages.ControlsChanged, value.Application);
            }
        }
        #endregion

        #region Constructor
        public ApplicationsDB()
        {
            _applications = new List<ApplicationModel>();

            ApplicationModel inst01 = new ApplicationModel(Constants.ApplicationSet.Excel.ToString(), Constants.ExcelApplicationImage);
            ApplicationModel inst02 = new ApplicationModel(Constants.ApplicationSet.Word.ToString(), Constants.WordApplicationImage);
            ApplicationModel inst03 = new ApplicationModel(Constants.ApplicationSet.Access.ToString(), Constants.AccessApplicationImage);

            _applications.Add(inst01);
            _applications.Add(inst02);
            _applications.Add(inst03);
        }
        #endregion
    }
}
