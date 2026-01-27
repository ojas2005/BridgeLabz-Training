using CoreApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class BankAccountTests
    {
        private BankAccount account;

        [TestInitialize]
        public void Setup()
        {
            account = new BankAccount();
        }

        [TestMethod]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);
            Assert.AreEqual(1000, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);
            account.Withdraw(400);
            Assert.AreEqual(600, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(200);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(500));
        }
    }

}
