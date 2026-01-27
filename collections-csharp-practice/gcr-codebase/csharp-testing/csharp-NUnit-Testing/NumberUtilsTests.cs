using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CoreApp.Tests
{
    [TestFixture]
    public class NumberUtilsTests
    {
        private NumberUtils utils = new NumberUtils();

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_TestMultipleValues(int inputValue, bool expected)
        {
            Assert.AreEqual(expected, utils.IsEven(inputValue));
        }
    }
}
