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

namespace ProcessNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ProcessGrid.ItemsSource = ProcessHandler.LoadProcesses();
            ProcessGrid.AutoGenerateColumns = true;
        }

        private void ProcessGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ProcessGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailsGrid.ItemsSource = ProcessHandler.LoadProcesses();
            ProcessGrid.AutoGenerateColumns = true;
        }
    }
}
