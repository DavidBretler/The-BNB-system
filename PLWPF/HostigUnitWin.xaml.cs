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
        BE.GuestRequest GuestRequest;
        public HostigUnitWin()
        {
            try
            {
                InitializeComponent();
                hostingUnit = null;
                GuestRequest = null;
                bl = BL.Factory.GetBL();

                this.studentsComboBox.ItemsSource = bl.getListOfHostingUnitsByOwnerKey(FindHostWindow.host.HostKey).ToList();
                this.studentsComboBox.DisplayMemberPath = "HostingUnitName";
                this.studentsComboBox.SelectedValuePath = "HostingUnitKey";

                this.guestRequestCB.ItemsSource = bl.getListOfGuestRequest().ToList();
                this.guestRequestCB.DisplayMemberPath = "GuestRequestKey";
                this.guestRequestCB.SelectedValuePath = "GuestRequestKey";

                this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
                this.poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.hikesComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.airConditionerComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.ResortType));

                //this.DataContext = studentsComboBox.SelectedItem;
                //// this.studentsComboBox.ItemsSource = bl.GetAllStudents();
                // this.studentsComboBox.DisplayMemberPath = "StudentName";
                // this.studentsComboBox.SelectedValuePath = "StudentId";
                //// this.registerSemesterComboBox.ItemsSource = Enum.GetValues(typeof(BE.Semester));
                // this.registerSemesterComboBox.SelectedIndex = 0;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
                // Load data by setting the CollectionViewSource.Source property:
                // hostingUnitViewSource.Source = [generic data source]
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
        private void studentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.studentsComboBox.SelectedItem is BE.HostingUnit) { 
                this.hostingUnit = ((BE.HostingUnit)this.studentsComboBox.SelectedItem).GetCopy();
                this.hostigUnit.DataContext = hostingUnit; 
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

               
                if (MessageBox.Show("האם אתה בטוח שברצונך לבטל את ההזמנה?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {

                    bl.DeleteHostingUnit(this.hostingUnit.HostingUnitKey);
                    this.Close();

                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.guestRequestCB.SelectedItem is BE.GuestRequest)
            {
                this.GuestRequest = ((BE.GuestRequest)this.guestRequestCB.SelectedItem).GetCopy();
                this.DataContext = GuestRequest;
            }

    }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.NewOrder(GuestRequest, hostingUnit);
                MessageBox.Show("your order have been craeted" );
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}
