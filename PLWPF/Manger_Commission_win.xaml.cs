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
    /// Interaction logic for Manger_Commission_win.xaml
    /// </summary>
    public partial class Manger_Commission_win : Window
    {
        public Manger_Commission_win()
        {
            InitializeComponent();
            Commission_textbok.Text = BE.Configuration.Commission.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.IsEmpty(Commission_textbok.Text);
            MainWindow.IsInt(Commission_textbok.Text);
            BE.Configuration.Commission = Int32.Parse(Commission_textbok.Text);
            this.Close();
        }
    }
}
