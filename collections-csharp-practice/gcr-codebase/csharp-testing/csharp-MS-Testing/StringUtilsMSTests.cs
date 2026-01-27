using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    [TestClass]
    internal class StringUtilsMSTests
    {
        private StringUtils utils;

        [TestInitialize]
        public void Setup()
        {
            utils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_ReturnsReversedString()
        {
            Assert.AreEqual("olleh", utils.Reverse("hello"));
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrueForPalindrome()
        {
            Assert.IsTrue(utils.IsPalindrome("madam"));
        }

        [TestMethod]
        public void ToUpperCase_ReturnsUpperCaseString()
        {
            Assert.AreEqual("HELLO", utils.ToUpperCase("hello"));
        }
    }
}
