
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
                MainWindow.IsEmpty(___GuestRequest_key_textbox_.Text);
                MainWindow.IsInt(___GuestRequest_key_textbox_.Text);

                myIBL = BL.Factory.GetBL();
                int temp = Int32.Parse(___GuestRequest_key_textbox_.Text);
                guestRequest = myIBL.SearchGetGuestRequestByKey(temp);
                if(MessageBox.Show("Are you sure you want to delete?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                 {
                    this.Close();
                  }
            else
                {
                   
                    myIBL.DeleteGuestRequests(guestRequest);
                    this.Close();
                    MessageBox.Show("the guest Request have beet deleted");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


    }
}
