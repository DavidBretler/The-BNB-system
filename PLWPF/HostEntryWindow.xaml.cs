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
    /// Interaction logic for HostEntryWindow.xaml
    /// </summary>
    public partial class HostEntryWindow : Window 
    {
        BL.IBL bl;
      
        public HostEntryWindow()
        {
           
                InitializeComponent();
           // host = new BE.Host();
          
        }

        private void goBack_Click(object sender, RoutedEventArgs e)
        {    
            this.hostDeteil.DataContext = FindHostWindow.host;
            BankText.Text = FindHostWindow.host.HostBankAccuont.BankAccountNumber.ToString();
            //this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = BL.Factory.GetBL();
                bl.UpdateHost((BE.Host)this.hostDeteil.DataContext);
                MessageBox.Show("פרטיך עודכנו בהצלחה ");
            }
            catch (Exception E) { MessageBox.Show( E.ToString()); }
            //catch (BE.MissingIdException E2) { MessageBox.Show(E2.ToString()); }
        }


    }
}
