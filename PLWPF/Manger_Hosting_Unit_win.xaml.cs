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

using System.Data.SqlClient;
using System.Data;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Manger_Hosting_Unit_win.xaml
    /// </summary>
    public partial class Manger_Hosting_Unit_win : Window
    {
        BL.IBL myIBL;

        public Manger_Hosting_Unit_win()
        {
            myIBL = BL.Factory.GetBL();

            InitializeComponent();
            hostingUnitDataGrid.ItemsSource = myIBL.getListOfHostingUnits();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        
        
    }
}
