using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication3.ViewModel;

namespace WpfApplication3
{
	/// <summary>
	/// Interaction logic for ModelLog.xaml
    /// </summary>
    public partial class ModelLogView : Window
    {
        public ModelLogView()
        {
            this.InitializeComponent();
        }

        public ModelLogView(ModelLogViewModel dataContext)
        {
            this.InitializeComponent();
            this.DataContext = dataContext;
        }

        private void CloseWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Application currApp = Application.Current;
            Window mainWindow = currApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }
	}
}