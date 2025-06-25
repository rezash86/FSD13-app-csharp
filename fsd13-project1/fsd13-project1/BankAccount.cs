using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsd13_project1
{
    //This class is respresenting a simple bank account
    //and demonstrates how encapsulation protects and 
    //controls access to sensitive data
    internal class BankAccount
    {
        //private fields not accessible outside
        private decimal balance;

        // it is a read-only property
        public string AccountHolder { get; }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                  
            }
        }

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        //public methods to modify private data
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Withdrow(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
