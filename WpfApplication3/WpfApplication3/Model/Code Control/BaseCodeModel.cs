using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication3.Common;
using WpfApplication3.Database;
using WpfApplication3.Interfaces;

namespace WpfApplication3.Model.Code_Control
{
    [XmlRoot, XmlInclude(typeof(BaseForModel)), XmlInclude(typeof(ExcelConnectionModel)),
    XmlInclude(typeof(ExcelForLoopModel))]
    public abstract class BaseCodeModel : ICustomTypeDescriptor, IUniqueId
    {
        #region Members
        private BaseCodeModel _parent;
        private Constants.ApplicationSet _application;
        private string _controlName;
        private string _imageSource;
        private Boolean _nestable;
        private List<string> _category = new List<string>();
        private Boolean _displayOnly = false;
        private string _id;
        #endregion

        #region Properties
        [XmlElement, Browsable(false)]
        public BaseCodeModel Parent 
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [XmlElement, Browsable(false)]
        public Constants.ApplicationSet Application 
        {
            get { return _application; }
            set { _application = value; }
        }

        [XmlElement, Browsable(true), ReadOnly(true)]
        public string ControlName 
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        [XmlElement, Browsable(false)]
        public string ImageSource 
        {
            get { return _imageSource; }
            set { _imageSource = value; }
        }

        [XmlElement, Browsable(false)]
        public Boolean Nestable 
        {
            get { return _nestable; }
            set { _nestable = value; }
        }

        [XmlElement, Browsable(false)]
        public Boolean IsDisplayOnly 
        {
            get { return _displayOnly; }
            set { _displayOnly = value; }
        }

        [XmlElement, Browsable(false)]
        public List<string> Category
        {
            get { return _category; }
            set
            {
                _category = value;
                Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection, null);
                RefreshPropertyCollections();
                Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection, this);
            }
        }

        [XmlIgnore, Browsable(false)]
        public abstract object Code
        {
            get;
        }
        #endregion

        #region Constructors
        public BaseCodeModel() { } // Used for serialisation.

        public BaseCodeModel(Constants.ApplicationSet application, string controlName,
            string imageSource, Boolean nestable)
        {
            _application = application;
            _controlName = controlName;
            _imageSource = imageSource;
            _nestable = nestable;
            _displayOnly = !Constants.ControlsLoaded;
        }
        #endregion

        #region Methods
        public void ParentControlRemoved(BaseCodeModel control)
        {
            if (Parent == control)
            {
                Parent = null;
            }
            RefreshPropertyCollections();
        }

        public virtual void RefreshPropertyCollections()
        {
            VariablesDB.Connections.Clear();

            BaseCodeModel currentParent = Parent;

            while (currentParent != null)
            {
                // Determine the type of control.
                if (currentParent.GetType() == typeof(ExcelConnectionModel))
                {
                    // Retrieve the control and add to the connections list.
                    ExcelConnectionModel model = currentParent as ExcelConnectionModel;
                    if (!VariablesDB.Connections.Contains(model))
                    {
                        VariablesDB.Connections.Add(model);
                    }
                }
                else if (currentParent.GetType() == typeof(ExcelForLoopModel))
                {
                    // Retrieve the control and add to the forLoop list.
                    ExcelForLoopModel model = currentParent as ExcelForLoopModel;
                    if (!VariablesDB.ForLoops.Contains(model))
                    {
                        VariablesDB.ForLoops.Add(model);
                    }
                }
                currentParent = currentParent.Parent;
            }
        }
        #endregion

        #region ICustomTypeDescriptor Members
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return null;
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return null;
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return this.GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            var props = new PropertyDescriptorCollection(null);

            foreach (PropertyDescriptor prop in
                TypeDescriptor.GetProperties(this, true))
            {
                if (_category.Contains(prop.Category) ||
                    prop.Category == "Misc")
                {
                    props.Add(prop);
                }
            }

            return props;
        }
        #endregion

        #region IUniqueId Members
        [XmlElement, Browsable(false)]
        public string Id
        {
            get
            {
                if(string.IsNullOrEmpty(_id))
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
    }
}
