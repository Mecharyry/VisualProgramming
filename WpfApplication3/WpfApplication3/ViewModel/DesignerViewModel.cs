using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Interfaces;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;

namespace WpfApplication3.ViewModel
{
    [XmlRoot]
    public class DesignerViewModel : IDropable
    {
        #region Members
        private ControlViewModel _parent;
        private DesignerModel _currentDesigner;
        private GuiObjectModel _currentControl;
        private ConnectionModel _currentConnection;
        private ObservableCollection<StartModel> _start = new ObservableCollection<StartModel>();
        private ObservableCollection<ControlViewModel> _controls = new ObservableCollection<ControlViewModel>();
        private ObservableCollection<ConnectionModel> _connections = new ObservableCollection<ConnectionModel>();
        #endregion

        #region Properties
        public string Id 
        {
            get { return _currentDesigner.Id; }
        }

        public string DesignerName 
        {
            get { return _currentDesigner.DesignerName; }
        }

        public ControlViewModel Parent 
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public DesignerModel CurrentDesigner
        {
            get { return _currentDesigner; }
            set { _currentDesigner = value; }
        }

        [XmlElement]
        public GuiObjectModel CurrentControl 
        {
            get { return _currentControl; }
            set { _currentControl = value; }
        }

        [XmlElement]
        public ConnectionModel CurrentConnection
        {
            get { return _currentConnection; }
            set { _currentConnection = value; }
        }

        [XmlElement]
        public ObservableCollection<StartModel> StartControl 
        {
            get { return _start; }
            set { _start = value; }
        }

        [XmlElement]
        public ObservableCollection<ControlViewModel> Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        [XmlElement]
        public ObservableCollection<ConnectionModel> Connections
        {
            get { return _connections; }
            set { _connections = value; }
        }
        #endregion

        #region Constructors
        public DesignerViewModel()
        {
            Mediator.Instance.Register(
            (Object o) =>
            {
                if (o.GetType() == typeof(ControlViewModel))
                {
                    ControlViewModel temp = o as ControlViewModel;
                    RemoveControl(temp);
                }
            }, Mediator.ViewModelMessages.RemoveControl);
        }

        public DesignerViewModel(DesignerModel model) : this()
        {
            _currentDesigner = model;
            _start.Add(new StartModel());
        }

        public DesignerViewModel(DesignerModel model, ControlViewModel parent)
            : this(model)
        {
            _parent = parent;
        }
        #endregion

        #region IDropbale Members
        public Type DataType
        {
            get { return typeof(ControlViewModel); }
        }

        public void Drop(object obj)
        {
            throw new NotImplementedException("Drop(object) is not implemented in this class");
        }

        public void Drop(object obj, double x, double y)
        {
            ControlViewModel item = obj as ControlViewModel;

            if (item != null)
            {
                BaseCodeModel baseModel = Activator.CreateInstance(item.CurrentCodeModel.GetType()) as BaseCodeModel;
                object[] args = new object[] { baseModel };

                ControlViewModel controlModel = Activator.CreateInstance(item.GetType(), args) as ControlViewModel;
                controlModel.X = x;
                controlModel.Y = y;
                if (this.Parent != null)
                {
                    controlModel.CurrentCodeModel.Parent = this.Parent.CurrentCodeModel;
                }
                Controls.Add(controlModel);

                if (item.CurrentCodeModel.Nestable == true)
                {   // Create a new tab using this control.
                    Mediator.Instance.Notify(Mediator.ViewModelMessages.AddTab,
                        controlModel);
                }
            }
        }
        #endregion

        #region Control Methods
        public void RemoveAllControls()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].RemoveControlCommandExecute();
            }
        }

        public void RemoveControl(ControlViewModel control)
        {
            // Remove all connections associated with this control.
            ControlViewModel model = Controls.FirstOrDefault(x => x.Id == control.Id);
            if (model == null)
            {
                return;
            }
            RemoveConnection(control);
            Controls.Remove(model);
        }
        #endregion

        #region Connection Methods
        public void StartConnection(GuiObjectModel sourceControl)
        {
            // Determine whether the connections collection already contains the control.
            ConnectionModel connection = Connections.FirstOrDefault(x => x.Start != null && x.Start.Id == sourceControl.Id);
            if (connection == null)
            {
                connection = new ConnectionModel();

                if (sourceControl != null)
                {
                    connection.Start = sourceControl;
                }
                Connections.Add(connection);
            }

            CurrentConnection = connection;
        }

        public void EndConnection(GuiObjectModel destinationControl)
        {
            if (destinationControl.GetType() == typeof(StartModel))
            {   // Start control is not a destination for other controls.
                return;
            }

            // Verify that it is not a circular reference. Parent references child, who references parent.
            // Grab the start (source) of the connection.
            GuiObjectModel source = CurrentConnection.Start;

            // Get the connection in which source is the end point.
            ConnectionModel parentConnection = Connections.FirstOrDefault(x => x.End != null && x.End.Id == source.Id);

            // Verify that destination is not the same as the parent of the control.
            if (parentConnection != null &&
                parentConnection.Start == destinationControl)
            {
                return;
            }

            // Verify that the end point is not already being used.
            object endFound = Connections.FirstOrDefault(x => x.End != null && x.End.Id == destinationControl.Id);

            if (endFound == null)
            {
                CurrentConnection.End = destinationControl;
            }
        }

        public void RemoveConnection(GuiObjectModel controlToRemove)
        {
            for (int i = 0; i < Connections.Count; i++)
            {
                ConnectionModel connection = Connections[i];

                if (connection.Start.Id == controlToRemove.Id ||
                    connection.End.Id == controlToRemove.Id)
                {
                    Connections.Remove(connection);
                    i = i - 1;
                }
            }
        }
        #endregion

    }
}
