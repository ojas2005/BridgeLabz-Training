using NUnit.Framework;
namespace CoreApp.Tests
{
    [TestFixture]
    public class CalculatorUnitTest
    {
        private CalculatorApp calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorApp();
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int outcome = calculator.Add(10, 5);
            Assert.AreEqual(15, outcome);
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int outcome = calculator.Subtract(10, 5);
            Assert.AreEqual(5, outcome);
        }

        [Test]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int outcome = calculator.Multiply(10, 5);
            Assert.AreEqual(50, outcome);
        }

        [Test]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int outcome = calculator.Divide(10, 5);
            Assert.AreEqual(2, outcome);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}
