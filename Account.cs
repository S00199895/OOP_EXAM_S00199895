using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //abstract class. cannot be implemented oly inherited from
    public abstract class Account : IComparable
    {
        //properties
        public abstract int AccountNumber { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract decimal Balance { get; set; }
        public abstract DateTime InterestDate { get; set; }

        //methods
        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }
        public override string ToString()
        {
            return $"{AccountNumber} - {LastName}, {FirstName}";
        }

        //Method used to identify how this object will be sorted - in this case using Surname
        public int CompareTo(object obj)
        {
            Account that = obj as Account;
            return this.LastName.CompareTo(that.LastName);
        }

        //abstract methods
        public abstract decimal CalculateInterest();
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
        {
            InterestRate = .03m;

            FirstName = fName;
            LastName = lName;
            AccountNumber = accNum;
            Balance = bal;
        }

        //methods
        public override decimal CalculateInterest()
        {
            decimal interest = 0;
            interest = Balance * InterestRate;
            InterestDate = DateTime.Now;
            return interest;
        }
    }
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
        public override decimal CalculateInterest()
        {
            /*DateTime toSubtract = new DateTime(1996, 6, 3, 22, 15, 0);
            if (InterestDate !=null)
            { 
                DateTime oneYear = InterestDate.Subtract(toSubtract);
            }*/
            decimal interest = 0;
            interest = Balance * InterestRate;
            InterestDate = DateTime.Now;
            return interest;
        }
    }
}
