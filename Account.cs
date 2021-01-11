using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //abstract class. cannot be implemented only inherited from
    //Inherits from the interface Icomparable, allows for custom sorting
    public abstract class Account : IComparable
    {
        //properties
        public abstract int AccountNumber { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract decimal Balance { get; set; }
        public abstract DateTime InterestDate { get; set; }

        //methods
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            Balance -= amount;
        }
        public override string ToString()
        {
            //string format for accounts in the listobx
            return $"{AccountNumber} - {LastName}, {FirstName}";
        }

        //Method used to identify how this object will be sorted - in this case using Last Name
        //Sort method from Icomparable
        public int CompareTo(object obj)
        {
            Account that = obj as Account;
            return this.LastName.CompareTo(that.LastName);
        }

        //abstract methods
        public abstract void CalculateInterest();
    }

    public class CurrentAccount : Account
    {
        //props
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override decimal Balance { get; set; }
        public override DateTime InterestDate { get; set; }
        public decimal InterestRate { get; set; }
        public override int AccountNumber { get; set; }

        //ctors
        public CurrentAccount(string fName, string lName, int accNum, decimal bal)
        {//Dummy data easily implementable thorugh constructor
            //Default interest rate
            InterestRate = .03m;

            FirstName = fName;
            LastName = lName;
            AccountNumber = accNum;
            Balance = bal;
        }

        //methods
        public override void CalculateInterest()
        {
            DateTime date = DateTime.Now.AddYears(-1);
            //if the date is greater than 1 year ago
            if (InterestDate == null || InterestDate > date)
            {
                decimal interest = 0;
                interest = Balance * InterestRate;
                InterestDate = DateTime.Now;
            }
            
        }
    }
    //Child class of account
    public class SavingsAccount : Account
    {
        //props
        public override int AccountNumber { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override decimal Balance { get; set; }
        public override DateTime InterestDate { get; set; }
        public decimal InterestRate { get; set; }

        //ctors
        public SavingsAccount(string fName, string lName, int accNum, decimal bal)
        {
            InterestRate = .03m;

            FirstName = fName;
            LastName = lName;
            AccountNumber = accNum;
            Balance = bal;
        }

        //methods
        public override void CalculateInterest()
        {
            DateTime date = DateTime.Now.AddYears(-1);

            if (InterestDate == null || InterestDate > date)
            {
                decimal interest = 0;
                interest = Balance * InterestRate;
                InterestDate = DateTime.Now;
            }

        }
    }
}
