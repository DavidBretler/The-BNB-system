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
        public FindHostWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { BE.Host host = new BE.Host();
           // host= SearchHostByKey(HostNum.Text);
          //  if(host.password== hostPassword.Text)
                Window HostEntryWindow = new HostEntryWindow();
                HostEntryWindow.Show();
            else
                MessageBox.Show("אחד הפרטים שהכנסת אינו נכון");
        }
    }
}
