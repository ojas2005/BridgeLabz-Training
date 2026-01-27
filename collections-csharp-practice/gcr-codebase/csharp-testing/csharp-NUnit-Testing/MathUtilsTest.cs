using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace CoreApp.Tests
{
    public  class MathUtilsTest
    {
        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            MathUtils utils = new MathUtils();
            Assert.Throws<ArithmeticException>(() => utils.Divide(10, 0));
        }
    }
}
