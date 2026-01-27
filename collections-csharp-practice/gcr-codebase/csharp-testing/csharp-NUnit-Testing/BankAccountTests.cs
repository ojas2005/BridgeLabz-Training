using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
        }

        [Test]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);
            Assert.AreEqual(1000, account.GetBalance());
        }

        [Test]
        public void Withdraw_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);
            account.Withdraw(400);
            Assert.AreEqual(600, account.GetBalance());
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(200);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(500));
        }
    }

}
