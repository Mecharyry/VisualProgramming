using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Interfaces;
using WpfApplication3.Model;
using WpfApplication3.Model.Code_Control;

namespace WpfApplication3.Model
{
    public class StartModel : GuiObjectModel
    {
        #region Members
        private string _controlName = "Start Control";
        private string _imageSource = Constants.StartControlImage;
        #endregion

        #region Properties
        [XmlElement]
        public string ImageSource 
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        [XmlElement]
        public string ControlName 
        {
            get { return _controlName; }
            set { _controlName = value; }
        }
        #endregion

        #region Constructors
        public StartModel()
        {
            Y = 90;
            X = Constants.DesignAreaWidth / 2;

            Mediator.Instance.Register(
            (Object o) =>
            {
                X = Constants.DesignAreaWidth/2;
            }, Mediator.ViewModelMessages.CanvasSizeChanged);
        }
        #endregion
    }
}
