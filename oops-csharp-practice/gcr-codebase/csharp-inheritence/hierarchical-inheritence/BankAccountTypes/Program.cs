using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.BankAccountTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount savings = new SavingsAccount(101, 50000, 4.5);
            BankAccount checking = new CheckingAccount(102, 30000, 10000);
            BankAccount fixedDeposit = new FixedDepositAccount(103, 100000, 24);

            Console.WriteLine(savings);
            Console.WriteLine(checking);
            Console.WriteLine(fixedDeposit);
        }
    }
}
