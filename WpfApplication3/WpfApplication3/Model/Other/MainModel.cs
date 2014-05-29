using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.ViewModel;

namespace WpfApplication3.Model
{
    public class MainModel
    {
        #region Members
        private ObservableCollection<DesignerViewModel> _designers = new ObservableCollection<DesignerViewModel>();
        #endregion

        #region Properties
        public ObservableCollection<DesignerViewModel> Designers 
        {
            get { return _designers; }
            set 
            { 
                _designers = value;
            }
        }
        #endregion
    }
}
