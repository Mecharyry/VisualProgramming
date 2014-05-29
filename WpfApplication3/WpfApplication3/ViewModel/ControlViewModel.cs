using System;
using System.Activities.Presentation.PropertyEditing;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Interfaces;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.PropertiesGrid.Editors;

namespace WpfApplication3.ViewModel
{
    [DataContract]
    public class ControlViewModel : GuiObjectModel, IDragable
    {
        #region Members
        private BaseCodeModel _currentCodeModel;
        private Boolean _inControlsList = false;
        #endregion

        #region Properties
        [XmlElement]
        public BaseCodeModel CurrentCodeModel
        {
            get { return _currentCodeModel; }
            set { _currentCodeModel = value; }
        }

        [XmlElement]
        public Boolean InControlsList 
        {
            get { return _inControlsList; }
            set { _inControlsList = value; }
        }
        #endregion

        #region Constructors
        public ControlViewModel() { } // Used for serialisation.

        public ControlViewModel(BaseCodeModel model)
        {
            _currentCodeModel = model;

            if (CurrentCodeModel.IsDisplayOnly == false)
            {   // Not part of control selection.
                Mediator.Instance.Register(
                (Object o) =>
                {
                    if (o.GetType() == typeof(ControlViewModel))
                    {
                        ControlViewModel temp = o as ControlViewModel;
                        CurrentCodeModel.ParentControlRemoved(temp.CurrentCodeModel);
                    }
                }, Mediator.ViewModelMessages.RemoveControl);
            }
        }
        #endregion

        #region IDragable Members
        public Type DataType
        {
            get { return typeof(ControlViewModel); }
        }
        #endregion

        #region Commands
        public void SetPropertiesCommandExecute()
        {
            CurrentCodeModel.RefreshPropertyCollections();

            // Edit properties grid to show selected control.
            Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection,
                CurrentCodeModel);
        }

        private ICommand _setPropertiesCommand;
        public ICommand SetPropertiesCommand
        {
            get
            {
                if (_setPropertiesCommand == null)
                {
                    _setPropertiesCommand = new Command(this.SetPropertiesCommandExecute);
                }
                return _setPropertiesCommand;
            }
        }

        public void RemoveControlCommandExecute()
        {
            // Reset the properties grid.
            Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection,
                null);

            Mediator.Instance.Notify(Mediator.ViewModelMessages.RemoveControl,
                this);
        }

        private ICommand _removeControlCommand;
        public ICommand RemoveControlCommand
        {
            get
            {
                if (_removeControlCommand == null)
                {
                    _removeControlCommand = new Command(this.RemoveControlCommandExecute);
                }
                return _removeControlCommand;
            }
        }
        #endregion
    }
}
