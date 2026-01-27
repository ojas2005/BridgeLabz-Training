using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class MathUtils
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArithmeticException("Division by zero");

            return a / b;
        }
    }
}
