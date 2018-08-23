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
        public List<BaseProcess> BaseProcesses { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BaseProcesses = ProcessHandler.LoadProcesses();
            DataContext = this;
        }


        private void ProcessGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ProcessGrid.SelectedItem == null)
            {
                return;
            }
            var selectedRow = ProcessGrid.SelectedItem as BaseProcess;
            TestBox.Text = ProcessHandler.GetProcessDetails(selectedRow);
        }

        private void AlwaysOnTopCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void AlwaysOnTopCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
        }
    }
}
