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
    public class DateFormatterTests
    {
        private DateFormatter formatter;

        [TestInitialize]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [TestMethod]
        public void FormatDate_ValidInput_ReturnsFormattedDate()
        {
            string outcome = formatter.FormatDate("2025-12-21");
            Assert.AreEqual("21-12-2025", outcome);
        }

        [TestMethod]
        public void FormatDate_InvalidInput_ThrowsException()
        {
            Assert.Throws<FormatException>(() => formatter.FormatDate("21-12-2025"));
        }
    }

}
