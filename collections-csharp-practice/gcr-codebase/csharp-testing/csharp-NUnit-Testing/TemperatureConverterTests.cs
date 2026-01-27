using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Tests
{
    [TestFixture]
    internal class TemperatureConverterTests
    {
        private TemperatureConverter converter = new TemperatureConverter();

        [Test]
        public void CelsiusToFahrenheit_ConvertsCorrectly()
        {
            Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
            Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));
        }

        [Test]
        public void FahrenheitToCelsius_ConvertsCorrectly()
        {
            Assert.AreEqual(0, converter.FahrenheitToCelsius(32), 0.1);
            Assert.AreEqual(100, converter.FahrenheitToCelsius(212), 0.1);
        }
    }
}
