using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Common;

namespace WpfApplication3.Model
{
    
    public class ApplicationModel
    {
        #region Members
        private string _imageSource;
        private string _application;
        #endregion

        #region Properties
        public string ImageSource 
        {
            get { return _imageSource; } 
        }

        public string Application
        {
            get { return _application; }
        }
        #endregion

        #region Constructors
        public ApplicationModel(string application, string imageSource)
        {
            _imageSource = imageSource;
            _application = application;
        }
        #endregion
    }
}
