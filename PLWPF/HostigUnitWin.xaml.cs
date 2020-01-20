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
    /// Interaction logic for HostigUnitWin.xaml
    /// </summary>
    public partial class HostigUnitWin : Window
    {
       
            BL.IBL bl;
        BE.HostingUnit hostingUnit;
        public  HostigUnitWin()
        {
            InitializeComponent();
            hostingUnit = null;
            bl = BL.Factory.GetBL();

            this.studentsComboBox.ItemsSource = bl.getListOfHostingUnitsByOwnerKey(FindHostWindow.host.HostKey).ToList();
           this.studentsComboBox.DisplayMemberPath =  "HostingUnitName";
            this.studentsComboBox.SelectedValuePath = "HostingUnitKey";
            //this.DataContext = studentsComboBox.SelectedItem;
           //// this.studentsComboBox.ItemsSource = bl.GetAllStudents();
           // this.studentsComboBox.DisplayMemberPath = "StudentName";
           // this.studentsComboBox.SelectedValuePath = "StudentId";
           //// this.registerSemesterComboBox.ItemsSource = Enum.GetValues(typeof(BE.Semester));
           // this.registerSemesterComboBox.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }
        private void studentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.studentsComboBox.SelectedItem is BE.HostingUnit) { 
                this.hostingUnit = ((BE.HostingUnit)this.studentsComboBox.SelectedItem).GetCopy();
                this.DataContext = hostingUnit; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl = BL.Factory.GetBL();
                bl.UpdateHostingUnit(hostingUnit);
                MessageBox.Show("פרטיך עודכנו בהצלחה ");
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }
    }
}
