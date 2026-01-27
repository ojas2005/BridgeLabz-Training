using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Tests
{
    [TestFixture]
    internal class DateFormatterTests
    {
        private DateFormatter formatter = new DateFormatter();

        [Test]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string outcome = formatter.FormatDate("2025-12-21");
            Assert.AreEqual("21-12-2025", outcome);
        }

        [Test]
        public void FormatDate_InvalidDate_ThrowsException()
        {
            Assert.Throws<FormatException>(() => formatter.FormatDate("21-12-2025"));
        }
    }
}
