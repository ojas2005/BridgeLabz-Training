using System;

namespace ExceptionHandlingProblems.Handlers
{
    //demonstrates exception propagation across multiple methods
    public class ExceptionPropagationHandler
    {
        //method 1 that throws exception
        public static void Method1()
        {
            //perform division that will throw exception
            int result = 10 / 0;
        }

        //method 2 that calls method 1
        public static void Method2()
        {
            //calls method 1 which throws exception
            Method1();
        }

        //run exception propagation example
        public static void Run()
        {
            Console.WriteLine("\n===== Propagating Exceptions Across Methods =====");

            try
            {
                //calls method 2 which calls method 1
                //exception propagates: Method1 -> Method2 -> Run
                Method2();
            }
            catch (ArithmeticException ex)
            {
                //catch exception in main method
                Console.WriteLine($"Handled exception in Main: {ex.Message}");
            }
            catch (DivideByZeroException)
            {
                //handle divide by zero specifically
                Console.WriteLine("Handled exception in Main: Cannot divide by zero");
            }
        }
    }
}
