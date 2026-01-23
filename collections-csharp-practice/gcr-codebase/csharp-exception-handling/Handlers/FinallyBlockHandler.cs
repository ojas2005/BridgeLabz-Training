using System;

namespace ExceptionHandlingProblems.Handlers
{
    //demonstrates finally block execution regardless of exception occurrence
    public class FinallyBlockHandler
    {
        //perform division and demonstrate finally block
        public static void Run()
        {
            Console.WriteLine("\n===== Finally Block Execution =====");
            Console.Write("Enter first number: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter second number: ");
            string input2 = Console.ReadLine();

            try
            {
                //parse inputs
                int num1 = int.Parse(input1);
                int num2 = int.Parse(input2);

                //perform division
                int result = num1 / num2;
                Console.WriteLine($"Result: {num1} / {num2} = {result}");
            }
            catch (DivideByZeroException)
            {
                //handle division by zero
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (FormatException)
            {
                //handle invalid number format
                Console.WriteLine("Error: Please enter valid numbers");
            }
            finally
            {
                //finally block always executes regardless of exception
                Console.WriteLine("Operation completed");
            }
        }
    }
}
