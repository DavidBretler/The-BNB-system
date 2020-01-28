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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostigUnitWin.xaml
    /// </summary>
    public partial class HostigUnitWin : Window
    {
            BackgroundWorker workerThread;
       

        BL.IBL bl;
        BE.HostingUnit hostingUnit;
        BE.GuestRequest GuestRequest;
        public HostigUnitWin()
        {
            try
            {
                InitializeComponent();
               // hostingUnit = null;
                GuestRequest = null;
                bl = BL.Factory.GetBL();
                guestRequestDataGrid.ItemsSource = bl.getListOfGuestRequest();
                
                 hostingUnit = new BE.HostingUnit ();
                this.hostigUnit.DataContext = hostingUnit;

                

                this.areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
                this.poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.hikesComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.airConditionerComboBox.ItemsSource = Enum.GetValues(typeof(BE.Choice));
                this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.ResortType));


                this.studentsComboBox.ItemsSource = bl.getListOfHostingUnitsByOwnerKey(FindHostWindow.host.HostKey).ToList();
                this.studentsComboBox.DisplayMemberPath = "HostingUnitName";
                this.studentsComboBox.SelectedValuePath = "HostingUnitKey";

                this.guestRequestCB.ItemsSource = bl.getListOfGuestRequest().ToList();
                this.guestRequestCB.DisplayMemberPath = "GuestRequestKey";
                this.guestRequestCB.SelectedValuePath = "GuestRequestKey";
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
                MainWindow.IsEmpty(guestRequestCB.Text);

                bl.UpdateHostingUnit(hostingUnit);
                MessageBox.Show("your detail have been update  ");
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

               
                if (MessageBox.Show("are you sure you want to delete this hosting unit?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
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

                // a thred that activates sending email to guest
                workerThread = new BackgroundWorker();
                workerThread.DoWork += new DoWorkEventHandler(workerThread_DoWork);
                workerThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerThread_RunWorkerCompleted);
                workerThread.RunWorkerAsync();


      
                MessageBox.Show("your order have been craeted" );
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else
                MessageBox.Show("email sent.");
        }
        void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bl.sendEmailIfHasClearance(bl.getListOfOrder().Last());
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
             }
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void NewHostinUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hostingUnit.Owner = FindHostWindow.host;
                bl.AddNewHostingUnit( hostingUnit);
                MessageBox.Show("your Hosting Unit have been added");
                this.Close();
                Window HostigUnitWin = new HostigUnitWin();
                HostigUnitWin.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title != "MainWindow")
                    window.Close();
            }
        }
    }
}
