using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    class Calculator
    {
        private int Multiply(int a, int b) => a * b;
    }

    class InvokePrivateMethod
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            Type type = calc.GetType();

            MethodInfo method = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

            int outcome = (int)method.Invoke(calc, new object[] { 4, 5 });
            Console.WriteLine("Result: " + outcome);
        }
    }
}
