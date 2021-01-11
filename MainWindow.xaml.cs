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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //making accounts with the constructors
        CurrentAccount currAcc1 = new CurrentAccount("John", "Rambo", 55, 1000);
        CurrentAccount currAcc2 = new CurrentAccount("Shawn", "Michaels", 70, 2500);

        SavingsAccount saveAcc1 = new SavingsAccount("Booker", "DeWitt", 90, 3000);
        SavingsAccount saveAcc2 = new SavingsAccount("Nissa", "Revane", 101, 3400);

        List<Account> accounts = new List<Account>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //adding accounts to the list
            accounts.Add(currAcc1); accounts.Add(currAcc2); accounts.Add(saveAcc1); accounts.Add(saveAcc2);
            UpdateLbx();
        }

        private void UpdateLbx()
        {
            accounts.Sort();//sorts the list using the CompareTo method in the class

            //Refreshes the display
            lbx_accs.ItemsSource = null;
            lbx_accs.ItemsSource = accounts;

        }
    }
}
