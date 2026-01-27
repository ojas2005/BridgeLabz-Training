using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CoreApp.Tests
{
    [TestFixture]
    internal class StringUtilsTests
    {
        private StringUtils utils;

        [SetUp]
        public void Setup()
        {
            utils = new StringUtils();
        }

        [Test]
        public void Reverse_ReturnsReversedString()
        {
            Assert.AreEqual("olleh", utils.Reverse("hello"));
        }

        [Test]
        public void IsPalindrome_ReturnsTrueForPalindrome()
        {
            Assert.IsTrue(utils.IsPalindrome("madam"));
        }

        [Test]
        public void ToUpperCase_ReturnsUpperCaseString()
        {
            Assert.AreEqual("HELLO", utils.ToUpperCase("hello"));
        }
    }
}
