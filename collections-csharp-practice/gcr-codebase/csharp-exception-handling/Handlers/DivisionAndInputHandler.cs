using System;

namespace ExceptionHandlingProblems.Handlers
{
    //handles division operation with multiple exception types
    public class DivisionAndInputHandler
    {
        //perform division with exception handling
        public static void Run()
        {
            Console.WriteLine("\n===== Division and Input Errors =====");
            Console.Write("Enter first number: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter second number: ");
            string input2 = Console.ReadLine();

            try
            {
                //parse input strings to integers
                int num1 = int.Parse(input1);
                int num2 = int.Parse(input2);

                //perform division
                int result = num1 / num2;
                Console.WriteLine($"Result: {num1} / {num2} = {result}");
            }
            catch (FormatException)
            {
                //handle invalid number format
                Console.WriteLine("Error: Please enter valid numeric values");
            }
            catch (DivideByZeroException)
            {
                //handle division by zero
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                //handle any other exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
