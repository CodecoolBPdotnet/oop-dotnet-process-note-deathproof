﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public ObservableCollection<BaseProcess> BaseProcesses { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ProcessHandler.LoadProcesses();
            BaseProcesses = BaseProcess.Processses;
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
        private void ProcessGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessGrid_MouseUp(sender,e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://github.com/CodecoolBPdotnet/oop-dotnet-process-note-deathproof";
            if (ProcessGrid.SelectedItem == null)
            {
                System.Diagnostics.Process.Start(url);
                return;
            }
            var selectedRow = ProcessGrid.SelectedItem as BaseProcess;
            url = "http://www.google.com/search?q=" + selectedRow.Name + "+process";
            System.Diagnostics.Process.Start(url);
        }

        private void CloseButton_Click( object sender, RoutedEventArgs e )
        {
            var selectedRow = ProcessGrid.SelectedItem as BaseProcess;
            if (selectedRow != null)
            {
                //Process.GetProcessById(selectedRow.PID).CloseMainWindow();
                Process.GetProcessById(selectedRow.PID).Kill();
            }
        }
    }
}
