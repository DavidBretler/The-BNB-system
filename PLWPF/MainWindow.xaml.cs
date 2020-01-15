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

namespace PLWPF
{//  לראות האם להשתמש בuser control  !!
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
            Window FindHostWindow = new FindHostWindow();
            FindHostWindow.Show();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }
    }
}
