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
using WpfApplication3.ViewModel;

namespace WpfApplication3.View
{
    /// <summary>
    /// Interaction logic for DesignerView.xaml
    /// </summary>
    public partial class DesignerView : UserControl
    {
        public DesignerView()
        {
            InitializeComponent();
        }

        private void ListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = sender as ListBox;
            if (parent == null)
            {
                return;
            }

            parent.Cursor = Cursors.Arrow;
        }

        private void CanvasSizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            if (canvas == null)
            {
                return;
            }

            Constants.DesignAreaWidth = canvas.ActualWidth;
            Constants.DesignAreaHeight = canvas.ActualHeight;

            Mediator.Instance.Notify(Mediator.ViewModelMessages.CanvasSizeChanged,
                null);
        }
    }
}
