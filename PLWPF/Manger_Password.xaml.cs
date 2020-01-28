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
    /// Interaction logic for Manger_Password.xaml
    /// </summary>
    public partial class Manger_Password : Window
    {
        public Manger_Password()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.IsEmpty(Password_box.Password);
                 
                

                if (BE.Configuration.getMangerPassword() == (Password_box.Password))
                {
                    Window MangerEntryWindow = new MangerEntryWindow();
                    MangerEntryWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password incorrect.");
                    Password_box.Clear();
                }
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }
    }
}
