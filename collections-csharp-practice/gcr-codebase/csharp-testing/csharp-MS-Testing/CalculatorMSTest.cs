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
    public class CalculatorMSTest
    {
        private CalculatorApp calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new CalculatorApp();
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int outcome = calculator.Add(10, 5);
            Assert.AreEqual(15, outcome);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int outcome = calculator.Subtract(10, 5);
            Assert.AreEqual(5, outcome);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int outcome = calculator.Multiply(10, 5);
            Assert.AreEqual(50, outcome);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int outcome = calculator.Divide(10, 5);
            Assert.AreEqual(2, outcome);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}
