/// This was compiled from this tutorial http://wpftutorial.net/ValueConverters.html.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApplication3.Database;
using WpfApplication3.Model.Code_Control;
using WpfApplication3.ViewModel;

namespace WpfApplication3.PropertiesGrid.Converters
{
    public class ComboBoxToStringConverter : IValueConverter
    {
        List<ExcelConnectionModel> connections = new List<ExcelConnectionModel>();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {   // Conversion from string to string.
            if(value == null)
            {
                return null;
            }
            ExcelConnectionModel connection = value as ExcelConnectionModel;
            connection = VariablesDB.Connections.FirstOrDefault(x => x.Id == connection.Id);


            return connection.ControlName;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {   // Conversion from comboBox to string.
            // Look up the string from the connections list.
            if (value == null)
            {
                return null;
            }
            return VariablesDB.Connections.FirstOrDefault(x => x.ControlName == value.ToString());
        }
    }

    public class ObjectToStringConverter : IValueConverter
    {
        private List<ExcelConnectionModel> _connections;

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {   // Conversion from string to string.
            if (value != null && 
                value.GetType() == typeof(List<ExcelConnectionModel>))
            {
                _connections = value as List<ExcelConnectionModel>;
                List<string> connectionNames = new List<string>();

                for (int i = 0; i < _connections.Count; i++)
                {
                    connectionNames.Add(_connections[i].ControlName);
                }
                return connectionNames;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {   // Conversion from comboBox to string.
            throw new NotImplementedException("Convert Back for ObjectToStringConverter has not been implemented.");
        }
    }
}
