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
    /// Interaction logic for FindHostWindow.xaml
    /// </summary>
    public partial class FindHostWindow : Window
    {
        BL.IBL ibl;
        public static BE.Host host = new BE.Host();           
        public FindHostWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try 
            {

                MainWindow.IsEmpty(HostNum.Text);
                MainWindow.IsEmpty(Passward.Password);
                MainWindow.IsInt(HostNum.Text);
                MainWindow.IsInt(Passward.Password);
                ibl = BL.Factory.GetBL();
                // BE.Host host = new BE.Host();
                Window HostEntryWindow = new HostEntryWindow();
                host = ibl.SearchForHostByKey(Int32.Parse(HostNum.Text));
                this.DataContext = host;
                if (host.password == Int32.Parse(Passward.Password))
                {
                    HostEntryWindow.Show();
                    this.Close();
                }

                else
                    MessageBox.Show("One of the detalis is not corect");
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }
    }
}
