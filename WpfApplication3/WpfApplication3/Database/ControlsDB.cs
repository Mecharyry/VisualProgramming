using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace WpfApplication3.Database
{
    public class ControlsDB: INotifyPropertyChanged
    {
        #region Members
        private readonly List<ControlViewModel> _controls = new List<ControlViewModel>();
        private Constants.ApplicationSet _controlSet;
        #endregion

        #region Properties
        public List<ControlViewModel> Controls 
        {
            get
            {
                return _controls.ToList().FindAll(x => x.CurrentCodeModel.Application == ControlSet);
            }
        }

        private Constants.ApplicationSet ControlSet 
        {
            get { return _controlSet; }
            set 
            { 
                _controlSet = value;
                NotifyPropertyChanged("Controls");
            }
        }
        #endregion

        #region Constructor
        public ControlsDB()
        {
            ControlViewModel inst01 = new ControlViewModel(new ExcelConnectionModel());
            ControlViewModel inst02 = new ControlViewModel(new ExcelForLoopModel());

            _controls.Add(inst01);
            _controls.Add(inst02);

            Constants.ControlsLoaded = true;

            Mediator.Instance.Register(
            (Object o) =>
            {
                ControlSet = (Constants.ApplicationSet)Enum.Parse(typeof(Constants.ApplicationSet), o.ToString(), true);
            }, Mediator.ViewModelMessages.ControlsChanged);
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
