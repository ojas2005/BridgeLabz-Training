using System;
using ExceptionHandlingProblems.Exceptions;

namespace ExceptionHandlingProblems.Handlers
{
    //handles age validation with custom exception
    public class AgeValidationHandler
    {
        //validate age and throw custom exception if invalid
        public static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException();
            }
        }

        //run age validation with exception handling
        public static void Run()
        {
            Console.WriteLine("\n===== Custom Exception - Age Validation =====");
            Console.Write("Enter your age: ");

            try
            {
                //parse user input
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    //validate age
                    ValidateAge(age);
                    Console.WriteLine("Access granted!");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            catch (InvalidAgeException ex)
            {
                //handle custom exception
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
