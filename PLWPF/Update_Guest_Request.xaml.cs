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
    /// Interaction logic for NewGuestRequestWindoy.xaml
    /// </summary>
    public partial class Update_Guest_Request : Window
    {
        BL.IBL ibl;
        BE.GuestRequest guestRequest;

        public Update_Guest_Request()
        {
            InitializeComponent();
      
            guestRequest = findG_RByKey.guestRequest;
            this.UpadateGuestRequestGrid.DataContext = guestRequest;
            ibl = BL.Factory.GetBL();

            this.AreaCB.ItemsSource = Enum.GetValues(typeof(BE.Area));
            this.PoolCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.JacuzziCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.GardenCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.HikesCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.ChildrensAttractionsCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.AirConditionerCB.ItemsSource = Enum.GetValues(typeof(BE.Choice));
            this.ResortTypeCB.ItemsSource = Enum.GetValues(typeof(BE.ResortType));
        
        }

        private void FinishGusetRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ibl.UpdateGuestRequests(guestRequest);
                MessageBox.Show("youre guest request number is :" + guestRequest.GuestRequestKey.ToString());
               
                this.UpadateGuestRequestGrid.DataContext = guestRequest;
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString()) ;
            }

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
