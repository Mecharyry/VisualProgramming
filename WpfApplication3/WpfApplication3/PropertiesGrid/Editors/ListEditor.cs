using System;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using WpfApplication3.PropertiesGrid.Resources;

namespace WpfApplication3.PropertiesGrid.Editors
{
    class ListEditor : PropertyValueEditor
    {
        private EditorResources resources = new EditorResources();

        public ListEditor()
        {
            this.InlineEditorTemplate = resources["ForLoop"] as DataTemplate;
        }
    }
}
