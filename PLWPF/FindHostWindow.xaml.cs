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
    /// Interaction logic for FindHostWindow.xaml
    /// </summary>
    public partial class FindHostWindow : Window
    {
        BL.IBL ibl;
        public static BE.Host host = new BE.Host();           
        public FindHostWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//passward cheack...
            Window HostEntryWindow = new HostEntryWindow();
            HostEntryWindow.Show();
        }
    }
}
