using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreApp_MS_Testing
{
    [TestClass]
    public class TemperatureConverterTests
    {
        private TemperatureConverter converter;

        [TestInitialize]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [TestMethod]
        public void CelsiusToFahrenheit_ConvertsCorrectly()
        {
            Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
            Assert.AreEqual(212, converter.CelsiusToFahrenheit(100));
        }

        [TestMethod]
        public void FahrenheitToCelsius_ConvertsCorrectly()
        {
            Assert.AreEqual(0, converter.FahrenheitToCelsius(32), 0.1);
            Assert.AreEqual(100, converter.FahrenheitToCelsius(212), 0.1);
        }
    }

}
