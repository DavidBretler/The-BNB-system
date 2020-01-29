using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Manger_Add_Host_win.xaml
    /// </summary>
    /// 

 
    public partial class Manger_Add_Host_win : Window
    {
        public BE.Host host = new BE.Host();
        BE.BankAccount bank = new BE.BankAccount();
        BL.IBL myIBL;
        public Manger_Add_Host_win()
        {
            myIBL = BL.Factory.GetBL();

            InitializeComponent();
            grid1.DataContext = host;
           bankBranchDataGrid.ItemsSource = myIBL.getListOfBankBranch();
            BankBranch_CB.ItemsSource = myIBL.getListOfBankBranch();
            BankBranch_CB.DisplayMemberPath = "BranchNumber";
            this.BankBranch_CB.DataContext = bank;

        }

      
        private void Add_Host_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                MainWindow.IsEmpty(familyNameTextBox.Text);
                MainWindow.IsValidEmailAddress(mailAddressTextBox.Text);
                MainWindow.IsEmpty(mailAddressTextBox.Text);
                MainWindow.IsEmpty(passwordTextBox.Text);
                MainWindow.IsEmpty(phoneNumberTextBox.Text);
                MainWindow.IsEmpty(privateNameTextBox.Text);
                         
                bank.BankAccountNumber = Int32.Parse(Bank_Number_Textbox.Text);
                host.HostBankAccuont = bank;
                host.HostKey = BE.Configuration.getNewHostKey();
                myIBL.NewHost(host);
                MessageBox.Show("Host added Successfuly.  key: " + host.HostKey);
                this.Close();
                Window Manger_Hosts_win = new Manger_Hosts_win();
                Manger_Hosts_win.Show();
            }
            
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource bankBranchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bankBranchViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bankBranchViewSource.Source = [generic data source]
        }

        private void BankBranch_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                if (this.BankBranch_CB.SelectedItem is BE.BankBranch)
                {
                BE.BankBranch branch = ((BE.BankBranch)this.BankBranch_CB.SelectedItem).GetCopy();
                bank.BankName = branch.BankName;
                bank.BranchAddress = branch.BankName;
                bank.BranchCity = branch.BranchCity;
                bank.BranchNumber = branch.BranchNumber;
                }
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }

