
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
    /// Interaction logic for fiend_G_RByKe_Delete.xaml
    /// </summary>
    public partial class fiend_G_RByKe_Delete : Window
    {
        BL.IBL myIBL;



        public static BE.GuestRequest guestRequest;
        public fiend_G_RByKe_Delete()
        {
            InitializeComponent();
        }

        private void ___FinedGuestRequest_Button__Click(object sender, RoutedEventArgs e)
        {

            try
            {

                myIBL = BL.Factory.GetBL();
                int temp = Int32.Parse(___GuestRequest_key_textbox_.Text);
                guestRequest = myIBL.SearchGetGuestRequestByKey(temp);
                if(MessageBox.Show("האם אתה בטוח שברצונך לבטל את ההזמנה?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                    myIBL.DeleteGuestRequests(guestRequest);
                }
            else
                {
                    this.Close();
                }

                //Window Update_Guest_Request = new Update_Guest_Request();
                //Update_Guest_Request.Show();
                //this.Close();

            }
            catch (BE.MissingIdException ex)
            {
                ///not implemnted
            }
        }


    }
}
