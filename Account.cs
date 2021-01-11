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
        public abstract decimal InterestRate { get; set; }

        //methods
        public abstract void Deposit();
        public abstract void Withdraw();

    }
}
