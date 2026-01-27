using CoreApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp_MS_Testing
{
    public class MathUtilsMSTest
    {
        [TestMethod]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            MathUtils utils = new MathUtils();
            Assert.Throws<ArithmeticException>(() => utils.Divide(10, 0));
        }
    }
}
