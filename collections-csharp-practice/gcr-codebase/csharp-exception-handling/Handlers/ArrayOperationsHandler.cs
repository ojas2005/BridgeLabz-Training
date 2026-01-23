using System;

namespace ExceptionHandlingProblems.Handlers
{
    //handles array operations with multiple exception types
    public class ArrayOperationsHandler
    {
        //retrieve value from array at specific index
        public static void Run()
        {
            Console.WriteLine("\n===== Multiple Exceptions - Array Operations =====");

            //create sample array
            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.Write("Enter array index (0-4): ");
            string input = Console.ReadLine();

            try
            {
                //parse index input
                int index = int.Parse(input);

                //check if array is null (this won't happen in this example but shows the logic)
                if (numbers == null)
                {
                    throw new NullReferenceException("Array is not initialized");
                }

                //attempt to access array element
                int value = numbers[index];
                Console.WriteLine($"Value at index {index}: {value}");
            }
            catch (IndexOutOfRangeException)
            {
                //handle index out of range
                Console.WriteLine("Invalid index! Index must be between 0 and 4");
            }
            catch (NullReferenceException ex)
            {
                //handle null reference
                Console.WriteLine($"Array is not initialized! {ex.Message}");
            }
            catch (FormatException)
            {
                //handle invalid number format
                Console.WriteLine("Invalid input! Please enter a valid number");
            }
            catch (Exception ex)
            {
                //handle any other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
