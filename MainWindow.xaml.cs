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
        List<Account> filteredAccounts = new List<Account>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbx_current.IsChecked = true;
            cbx_save.IsChecked = true;
            //adding accounts to the list
            accounts.Add(currAcc1); accounts.Add(currAcc2); accounts.Add(saveAcc1); accounts.Add(saveAcc2);
            UpdateLbx(accounts);
        }

        private void UpdateLbx(List<Account> accs)
        {
            accounts.Sort();//sorts the list using the CompareTo method in the class

            //Refreshes the display
            lbx_accs.ItemsSource = null;
            lbx_accs.ItemsSource = accs;

        }

        private void lbx_accs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account selected = lbx_accs.SelectedItem as Account;
            if (selected != null)
            {
                tblk_fName.Text = selected.FirstName;
                tblk_lName.Text = selected.LastName;
                tblk_bal.Text = selected.Balance.ToString();
                tblk_balance.Text = selected.Balance.ToString();

                if (selected is CurrentAccount)
                {
                    CurrentAccount cA = lbx_accs.SelectedItem as CurrentAccount;
                    tblk_type.Text = "Current Account";
                    tblk_interestRate.Text = cA.InterestRate.ToString();
                }
                else if (selected is SavingsAccount)
                {

                }
            }
        }

        private void cbx_Click(object sender, RoutedEventArgs e)
        {
            if ((cbx_current.IsChecked == true) && (cbx_save.IsChecked == true))
            {
                UpdateLbx(accounts);
            }
            else if ((cbx_current.IsChecked == false) && (cbx_save.IsChecked == false))
            {
                lbx_accs.ItemsSource = null;
            }
            else if ((cbx_current.IsChecked == true) && (cbx_save.IsChecked == false))
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is CurrentAccount)
                    {
                        filteredAccounts.Add(account);
                    }
                }
                UpdateLbx(filteredAccounts);
            }
            else if ((cbx_current.IsChecked == false) && (cbx_save.IsChecked == true))
            {
                filteredAccounts.Clear();

                foreach (Account account in accounts)
                {
                    if (account is SavingsAccount)
                    {
                        filteredAccounts.Add(account);
                    }
                }
                UpdateLbx(filteredAccounts);
            }
        }
    }
}
