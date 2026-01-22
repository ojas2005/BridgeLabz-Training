using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections
{
    internal class BankingSystem
    {
        private Dictionary<int, double> _accountBalances;
        private Queue<int> _transactionQueue;

        public BankingSystem()
        {
            _accountBalances = new Dictionary<int, double>();
            _transactionQueue = new Queue<int>();
        }

        private void OpenAccount(int accountId, double initialAmount)
        {
            _accountBalances[accountId] = initialAmount;
        }

        private void QueueWithdrawal(int accountId)
        {
            _transactionQueue.Enqueue(accountId);
        }

        private void ProcessWithdrawals(double amount)
        {
            while (_transactionQueue.Count > 0)
            {
                int accountId = _transactionQueue.Dequeue();
                if (_accountBalances[accountId] >= amount)
                {
                    _accountBalances[accountId] -= amount;
                    Console.WriteLine($"Withdrew {amount} from Account {accountId}");
                }
                else
                {
                    Console.WriteLine($"Insufficient funds in Account {accountId}");
                }
            }
        }

        private void DisplayAccountsByBalance()
        {
            SortedDictionary<double, int> balanceSorted = new SortedDictionary<double, int>();
            foreach (var account in _accountBalances)
                balanceSorted[account.Value] = account.Key;

            Console.WriteLine("\nAccounts Sorted by Balance:");
            foreach (var entry in balanceSorted)
                Console.WriteLine($"Account {entry.Value}: Rupees {entry.Key}");
        }

        public static void Main(string[] args)
        {
            BankingSystem bank = new BankingSystem();
            bank.OpenAccount(1001, 50000);
            bank.OpenAccount(1002, 20000);
            bank.OpenAccount(1003, 75000);

            bank.QueueWithdrawal(1002);
            bank.QueueWithdrawal(1001);

            bank.ProcessWithdrawals(5000);
            bank.DisplayAccountsByBalance();
        }
    }
}
