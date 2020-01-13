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
    /// Interaction logic for HostEntryWindow.xaml
    /// </summary>
    public partial class HostEntryWindow : Window
    {
       BE. Host host;
        public HostEntryWindow()
        {
            InitializeComponent();
            host = new BE.Host();
            this.hostDeteil.DataContext = host;
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
