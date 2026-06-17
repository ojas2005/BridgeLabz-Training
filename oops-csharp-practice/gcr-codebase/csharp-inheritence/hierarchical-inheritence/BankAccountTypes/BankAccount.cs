using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.BankAccountTypes
{
    internal class BankAccount
    {
        // attributes
        protected int AccountNumber;
        protected double Balance;

        //constructor
        public BankAccount(int accountNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        // string override 
        public override string ToString()
        {
            return $"Account Number : {AccountNumber} , Balance : {Balance}";
        }
    }
}
