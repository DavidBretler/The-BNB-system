using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class NewGuestRequestWindoy : Window
    {
        BL.IBL ibl;
        BE.GuestRequest guestRequest;
        private ObservableCollection<BE.GuestRequest> _myCollection = 
            new ObservableCollection<BE.GuestRequest>(); 
      
        public NewGuestRequestWindoy ()
        {
            InitializeComponent();
            this.ListBoxGR.DataContext = _myCollection;
            
            guestRequest = new BE.GuestRequest(); 
            this.newGuestRequestGrid.DataContext = guestRequest;
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
        private int counter = 0;
        private void FinishGusetRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MainWindow.IsEmpty(last_name_textbox.Text);
                MainWindow.IsEmpty(privte_Name_textbox.Text);

                MainWindow.IsEmpty(email_text_box.Text);
                MainWindow.IsValidEmailAddress(email_text_box.Text);

                //guestRequest.EndDate = this.calender.SelectedDates.Last;
                //guestRequest.GuestRequestKey = BE.Configuration.getNewGuestRequestKey();
                  ibl.NewGuestRequests(guestRequest);              
                MessageBox.Show("guest request key is:" + guestRequest.GuestRequestKey.ToString() );
                _myCollection.Add(guestRequest);
                guestRequest = new BE.GuestRequest();
                this.newGuestRequestGrid.DataContext = guestRequest;

               

                //++counter; 
                //_myCollection.Add(new BE.GuestRequest() { FirstName = "item " + counter,
                //    LastName = "item " +  counter,
                //    IsLecturer = counter % 3 == 0 });

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
         
        }

        private void AreaCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
