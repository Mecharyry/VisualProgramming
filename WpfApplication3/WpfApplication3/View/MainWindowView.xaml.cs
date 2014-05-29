using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel("Root");

            Mediator.Instance.Register(
            (Object o) =>
            {
                ContextChanged(o as MainViewModel);
            }, Mediator.ViewModelMessages.ContextChanged);
        }

        public void ContextChanged(MainViewModel model)
        {
            this.DataContext = model;
        }
    }
}
