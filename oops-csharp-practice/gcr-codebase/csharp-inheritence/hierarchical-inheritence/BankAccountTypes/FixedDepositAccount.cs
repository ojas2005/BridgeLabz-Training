using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.BankAccountTypes
{
    internal class FixedDepositAccount : BankAccount
    {
        int LockInPeriod;

        public FixedDepositAccount(int accountNumber, double balance, int lockInPeriod)
                                                    : base(accountNumber, balance)
        {
            this.LockInPeriod = lockInPeriod;
        }

        public override string ToString()
        {
            return "Fixed Deposit Account : " + base.ToString() + $" , Lock-in Period : {LockInPeriod} months";


        }
    }
}
