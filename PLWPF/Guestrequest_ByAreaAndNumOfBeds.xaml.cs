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
    /// Interaction logic for Guestrequest_ByAreaAndNumOfBeds.xaml
    /// </summary>
    public partial class Guestrequest_ByAreaAndNumOfBeds : Window
    {
        BL.IBL bl;
        public Guestrequest_ByAreaAndNumOfBeds()
        {
            InitializeComponent();           
            bl = BL.Factory.GetBL();
            guestRequestDataGrid.ItemsSource = bl.ListOfguestRequestsByArea();

            guestRequestDataGrid1.ItemsSource = bl.ListOfGustRequestByNumOfBeds();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title != "MainWindow")
                    window.Close();
            }
        }
    }
}
