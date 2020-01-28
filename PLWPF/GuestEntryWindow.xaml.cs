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
    /// Interaction logic for GuestEntryWindow.xaml
    /// </summary>
    public partial class GuestEntryWindow : Window
    {
        public GuestEntryWindow()
        {
            InitializeComponent();
        }

      

        private void Go_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ___NewOrderButton__Click(object sender, RoutedEventArgs e)
        {
            Window NewGuestRequestWindoy = new NewGuestRequestWindoy();
            NewGuestRequestWindoy.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window findG_RByKey = new findG_RByKey();
            findG_RByKey.Show();
            this.Close();
        }

        private void Cancel_Guest_Request_Click(object sender, RoutedEventArgs e)
        {
            Window fiend_G_RByKe_Delete = new fiend_G_RByKe_Delete();
            fiend_G_RByKe_Delete.Show();
            this.Close();
        }

     
    }
}
