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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
