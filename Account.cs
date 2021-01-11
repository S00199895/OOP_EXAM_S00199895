using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //abstract class. cannot be implemented oly inherited from
    public abstract class Account
    {
        //properties
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract decimal Balance { get; set; }
        public abstract decimal InterestDate { get; set; }

        //methods
        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public abstract decimal CalculateInterest();
    }

    public class CurrentAccount : Account
    {
        //props
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override decimal Balance { get; set; }
        public override decimal InterestDate { get; set; }
        public decimal InterestRate { get; set; }
        
        //ctors
        public CurrentAccount()
        {
            InterestRate = .03m;
        }

        //methods
        public override decimal CalculateInterest()
        {
            return 0;
        }
    }
    public class SavingsAccount : Account
    {
        //props
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override decimal Balance { get; set; }
        public override decimal InterestDate { get; set; }
        public decimal InterestRate { get; set; }

        //ctors
        public SavingsAccount()
        {
            InterestRate = .06m;
        }

        //methods
        public override decimal CalculateInterest()
        {
            return 0;
        }
    }
}
