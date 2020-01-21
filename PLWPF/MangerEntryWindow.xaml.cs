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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MangerEntryWindow.xaml
    /// </summary>
    public partial class MangerEntryWindow : Window
    {
        public MangerEntryWindow()
        {
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Manger_Order_Button(object sender, RoutedEventArgs e)
        {
            Window Manger_Oreder_win = new Manger_Oreder_win();
            Manger_Oreder_win.Show();
        }

        private void Guest_Request_button_Click(object sender, RoutedEventArgs e)
        {
           

            Window Manger_GuestRequest_win = new Manger_GuestRequest_win();
            Manger_GuestRequest_win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                 Window Manger_Hosting_Unit_win = new Manger_Hosting_Unit_win();
            Manger_Hosting_Unit_win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window Manger_Hosts_win = new Manger_Hosts_win();
            Manger_Hosts_win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window HostingUnit_byArea = new HostingUnit_byArea();
            HostingUnit_byArea.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window Guestrequest_ByAreaAndNumOfBeds = new Guestrequest_ByAreaAndNumOfBeds();
            Guestrequest_ByAreaAndNumOfBeds.Show();
        }
    }
}
