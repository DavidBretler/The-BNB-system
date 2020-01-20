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
    /// Interaction logic for Manger_Oreder_win.xaml
    /// </summary>
    public partial class Manger_Oreder_win : Window
    {
        BL.IBL myIBL;


        public Manger_Oreder_win()
        {

            myIBL = BL.Factory.GetBL();

            InitializeComponent();
            
            orderDataGrid.ItemsSource = myIBL.getListOfOrder();
        }

    }
}

