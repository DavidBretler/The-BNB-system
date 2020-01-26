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
using System.Text.RegularExpressions;

namespace PLWPF
{//  לראות האם להשתמש בuser control  !!
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL myIBL;
        BackgroundWorker workerThread;

        public MainWindow()
        {
            InitializeComponent();

            myIBL = BL.Factory.GetBL();
            workerThread = new BackgroundWorker();
            workerThread.DoWork += new DoWorkEventHandler(workerThread_DoWork);
            workerThread.RunWorkerAsync();

        }
      
        void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            myIBL.GetBankXml();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static public bool IsInt (string a)
        {
            int n;
            if (int.TryParse(a, out n))
                if (n >= 0)
                    return true;
                     else
                    throw new Exception("Must enter a  positive number.");
            throw new Exception("Must enter a number.");
        }
        static public bool IsEmpty(string a)
        {
            if (a == "")
                throw new Exception("Must Fill all the data.");
            else
                return true;
          
        }
      
            public static bool IsValidEmailAddress( string s)
            {
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!regex.IsMatch(s))
                throw new Exception("the email is incorecct.");
            return true;
            }
        


        private void HostEntryButton_Click(object sender, RoutedEventArgs e)
        {
            Window FindHostWindow = new FindHostWindow();
            FindHostWindow.Show();
        }

        private void MangerEntryButton_Click(object sender, RoutedEventArgs e)
        {
            
            Window Manger_Password = new Manger_Password();
            Manger_Password.Show();
        }

        private void GuestEntryButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestEntryWindow  = new GuestEntryWindow();
            GuestEntryWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }
    }
}
