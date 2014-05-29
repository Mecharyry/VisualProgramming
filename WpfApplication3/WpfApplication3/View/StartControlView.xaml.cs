using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3.Common;
using WpfApplication3.Model;
using WpfApplication3.ViewModel;

namespace WpfApplication3.View
{
    /// <summary>
    /// Interaction logic for StartControl.xaml
    /// </summary>
    public partial class StartControlView : UserControl
    {
        public StartControlView()
        {
            InitializeComponent();
        }

        private void StartLine_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Reset the properties grid.
            Mediator.Instance.Notify(Mediator.ViewModelMessages.PropertiesSelection,
                null);

            // Retrieve the listbox display from the view.
            ListBox parent = Helper.FindAnchestor<ListBox>(sender as DependencyObject);
            if (parent == null)
            {
                return;
            }

            parent.Cursor = Cursors.Hand;

            // Retrieve the datacontext for the listbox. 
            DesignerViewModel designer = parent.DataContext as DesignerViewModel;
            if (designer == null)
            {
                return;
            }

            // Retrieve the caller data context.
            FrameworkElement element = sender as FrameworkElement;
            if (element == null)
            {
                return;
            }

            // Retrieve the control.
            StartModel control = element.DataContext as StartModel;
            if (control == null)
            {
                return;
            }

            designer.StartConnection(control);

            e.Handled = true;
        }

        private void EndLink_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Retrieve the listbox display from the view.
            ListBox parent = Helper.FindAnchestor<ListBox>(sender as DependencyObject);
            if (parent == null)
            {
                return;
            }

            parent.Cursor = Cursors.Arrow;

            // Retrieve the datacontext for the listbox. 
            DesignerViewModel designer = parent.DataContext as DesignerViewModel;
            if (designer == null)
            {
                return;
            }

            // Retrieve the caller data context.
            FrameworkElement element = sender as FrameworkElement;
            if (element == null)
            {
                return;
            }

            // Retrieve the control.
            StartModel control = element.DataContext as StartModel;
            if (control == null)
            {
                return;
            }

            designer.EndConnection(control);
        }
    }
}
