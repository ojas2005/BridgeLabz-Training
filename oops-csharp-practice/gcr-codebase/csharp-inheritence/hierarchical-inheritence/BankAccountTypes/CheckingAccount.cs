using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.BankAccountTypes
{
    internal class CheckingAccount : BankAccount
    {
        double WithdrawalLimit;

        public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
                                        : base(accountNumber, balance)
        {
            this.WithdrawalLimit = withdrawalLimit;
        }

        public override string ToString()
        {
            return "Checking Account : " + base.ToString() + $" , Withdrawal Limit : {WithdrawalLimit}";


        }
    }
}
