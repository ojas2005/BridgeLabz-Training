using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CoreApp;
namespace CoreApp.Tests
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection db;

        [SetUp]
        public void Init()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        [TearDown]
        public void Cleanup()
        {
            db.Disconnect();
        }

        [Test]
        public void Database_IsConnected_OnSetup()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [Test]
        public void Database_Disconnect_Works()
        {
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
