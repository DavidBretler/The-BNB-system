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
    /// Interaction logic for findG_RByKey.xaml
    /// </summary>
    public partial class findG_RByKey : Window
    {
        BL.IBL myIBL;

     

        public static BE.GuestRequest guestRequest;
        public findG_RByKey()
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

                Window Update_Guest_Request = new Update_Guest_Request();
                Update_Guest_Request.Show();
                this.Close();

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

      
    }
}
