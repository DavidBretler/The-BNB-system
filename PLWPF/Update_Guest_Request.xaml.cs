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
            //EntryDatePicker.SelectedDate = DateTime.Today;
            //EndDatePicker.SelectedDate = DateTime.Today.AddDays(1);
        }

        private void FinishGusetRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                guestRequest.GuestRequestKey = BE.Configuration.getNewGuestRequestKey();
                ibl.NewGuestRequests(guestRequest);
                MessageBox.Show("מס ההזמנה שלך הוא :" + guestRequest.GuestRequestKey.ToString());
                guestRequest = new BE.GuestRequest();
                this.UpadateGuestRequestGrid.DataContext = guestRequest;
                this.Close();
            }
            catch
            {

            }

        }
    }
}
