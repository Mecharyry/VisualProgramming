using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Interfaces;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace WpfApplication3.Model
{
    [Serializable]
    public class DesignerModel : IUniqueId, INotifyPropertyChanged
    {
        #region Members
        private string _id;
        private string _designerName;
        #endregion

        #region Properties
        [XmlElement]
        public string DesignerName 
        {
            get { return _designerName; }
            set { _designerName = value; }
        }
        #endregion

        #region Constructor
        public DesignerModel() 
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
