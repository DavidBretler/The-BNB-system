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
    /// Interaction logic for hostingWin2.xaml
    /// </summary>
    public partial class hostingWin2 : Window
    {
        BL.IBL bl;

        public hostingWin2()
        {
            bl = BL.Factory.GetBL();
            InitializeComponent();
           
            ___listView_.ItemsSource= bl.getListOfHostingUnitsByOwnerKey(FindHostWindow.host.HostKey);
        }
    }
}
