﻿using System;
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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           BL.IBL myIBL;


        }
 
        private void HostEntryButton_Click(object sender, RoutedEventArgs e)
        {
            Window HostEntryWindow = new HostEntryWindow();
            HostEntryWindow.Show();
        }

        private void MangerEntryButton_Click(object sender, RoutedEventArgs e)
        {
            
            Window MangerEntryWindow = new MangerEntryWindow();
            MangerEntryWindow.Show();
        }

        private void GuestEntryButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestEntryWindow  = new GuestEntryWindow();
            GuestEntryWindow.Show();
        }
    }
}