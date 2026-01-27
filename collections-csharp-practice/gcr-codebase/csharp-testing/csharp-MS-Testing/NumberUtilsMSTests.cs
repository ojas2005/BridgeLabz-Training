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
    public class NumberUtilsMSTests
    {
        private NumberUtils utils = new NumberUtils();
        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_TestMultipleValues(int inputValue, bool expected)
        {
            Assert.AreEqual(expected, utils.IsEven(inputValue));
        }
    }
}
