using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CoreApp_MS_Testing
{
   
        [TestClass]
        public class DatabaseConnectionMSTests
        {
            private DatabaseConnection db;

            [TestInitialize]
            public void Init()
            {
                db = new DatabaseConnection();
                db.Connect();
            }

            [TestCleanup]
            public void Cleanup()
            {
                db.Disconnect();
            }

            [TestMethod]
            public void Database_IsConnected_OnSetup()
            {
                Assert.IsTrue(db.IsConnected);
            }

            [TestMethod]
            public void Database_Disconnect_Works()
            {
                db.Disconnect();
                Assert.IsFalse(db.IsConnected);
            }
        }
    }

