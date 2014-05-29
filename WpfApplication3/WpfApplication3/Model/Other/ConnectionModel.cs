using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Interfaces;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace WpfApplication3.Model
{
    [DataContract, KnownType(typeof(BaseCodeModel)), KnownType(typeof(StartModel))]
    public class ConnectionModel : INotifyPropertyChanged
    {
        #region Members
        private GuiObjectModel _start;
        private GuiObjectModel _end;
        #endregion

        #region Properties
        [XmlIgnore]
        public double X { get; set; }

        [XmlIgnore]
        public double Y { get; set; }

        [XmlElement]
        public GuiObjectModel Start
        {
            get { return _start; }
            set
            {
                _start = value;
                NotifyPropertyChanged("Start");
            }
        }

        [XmlElement]
        public GuiObjectModel End
        {
            get { return _end; }
            set
            {
                _end = value;
                NotifyPropertyChanged("End");
                Type type = _end.GetType();
                if (_end.GetType() == typeof(ControlViewModel))
                {
                    ControlViewModel end = _end as ControlViewModel;

                    if (_start.GetType() == typeof(StartModel))
                    {   // Assume root designer.
                        StartModel start = _start as StartModel;
                    }
                    else
                    {   // Must be a control model.
                        ControlViewModel start = _start as ControlViewModel;

                        if (start != null)
                        {
                            end.CurrentCodeModel.Parent = start.CurrentCodeModel;
                        }
                    }
                }
            }
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
