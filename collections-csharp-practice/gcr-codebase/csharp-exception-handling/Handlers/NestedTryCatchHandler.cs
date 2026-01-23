using System;

namespace ExceptionHandlingProblems.Handlers
{
    //demonstrates nested try-catch blocks for handling multiple exceptions
    public class NestedTryCatchHandler
    {
        //run nested try-catch example
        public static void Run()
        {
            Console.WriteLine("\n===== Nested try-catch Blocks =====");
            
            //sample array for testing
            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.Write("Enter array index: ");
            string indexInput = Console.ReadLine();

            Console.Write("Enter divisor: ");
            string divisorInput = Console.ReadLine();

            try
            {
                //outer try block for array access
                try
                {
                    //parse index input
                    int index = int.Parse(indexInput);
                    
                    //access array element
                    int value = numbers[index];

                    //inner try block for division
                    try
                    {
                        //parse divisor
                        int divisor = int.Parse(divisorInput);

                        //perform division
                        int result = value / divisor;
                        Console.WriteLine($"Result: {value} / {divisor} = {result}");
                    }
                    catch (DivideByZeroException)
                    {
                        //handle division by zero in inner catch
                        Console.WriteLine("Cannot divide by zero!");
                    }
                    catch (FormatException)
                    {
                        //handle invalid divisor format
                        Console.WriteLine("Invalid divisor format");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    //handle invalid array index in outer catch
                    Console.WriteLine("Invalid array index!");
                }
                catch (FormatException)
                {
                    //handle invalid index format
                    Console.WriteLine("Invalid index format");
                }
            }
            catch (Exception ex)
            {
                //catch any other unexpected exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
