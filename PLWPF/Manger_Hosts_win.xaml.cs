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
    /// Interaction logic for Manger_Hosts_win.xaml
    /// </summary>
    public partial class Manger_Hosts_win : Window
    {
        BL.IBL myIBL;


        public Manger_Hosts_win()
            {

                myIBL = BL.Factory.GetBL();

                InitializeComponent();

            hostDataGrid.ItemsSource = myIBL.getListOfHost();
            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myIBL.DeleteHost(myIBL.SearchForHostByKey(Int32.Parse(Delete_Textbox.Text)));
                MessageBox.Show("Deleted successfully.");
                this.Close();

                Window Manger_Hosts_win = new Manger_Hosts_win();
                Manger_Hosts_win.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window Manger_Add_Host_win = new Manger_Add_Host_win();
            Manger_Add_Host_win.Show();
            this.Close();
        }
    }
}
