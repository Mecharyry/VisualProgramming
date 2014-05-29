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

namespace WpfApplication3.Model
{
    [DataContract, KnownType(typeof(StartModel)), KnownType(typeof(BaseCodeModel))]
    public class GuiObjectModel : IUniqueId, INotifyPropertyChanged
    {
        #region Members
        private double _x;
        private double _y;
        private string _id;
        #endregion

        #region Properties
        [XmlElement, Browsable(false)]
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                NotifyPropertyChanged("X");
            }
        }

        [XmlElement, Browsable(false)]
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                NotifyPropertyChanged("Y");
            }
        }
        #endregion

        #region Constructors
        public GuiObjectModel() 
        {}
        #endregion

        #region IUniqueId Members
        [XmlElement]
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    _id = Guid.NewGuid().ToString("N");
                }

                return _id;
            }
            set
            {
                _id = value;
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
