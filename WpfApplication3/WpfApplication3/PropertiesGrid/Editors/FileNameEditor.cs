using Microsoft.Win32;
using System;
using System.Activities.Presentation.PropertyEditing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WpfApplication3.PropertiesGrid.Resources;

namespace WpfApplication3.PropertiesGrid.Editors
{
    class FileNameEditor : DialogPropertyValueEditor
    {
        private EditorResources resources = new EditorResources();

        public FileNameEditor()
        {
            this.InlineEditorTemplate = resources["FileBrowserEditorTemplate"] as DataTemplate;
        }

        // Open the dialog to pick image, when the dropdown button is pressed 
        public override void ShowDialog(PropertyValue propertyValue, IInputElement commandSource)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.CheckFileExists = true;
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Excel Files (*.xlsx)|*.xlsx;";
            dialog.Multiselect = false;
            dialog.Title = "Select Excel Workbook";
            dialog.FileName = propertyValue.StringValue;

            if (dialog.ShowDialog().Equals(true))
            {
                try
                {
                    //var source = commandSource as Control;
                    propertyValue.StringValue = dialog.FileName;
                }
                catch { }
            }
        }
    }
}
