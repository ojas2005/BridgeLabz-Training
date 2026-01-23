using System;

namespace ExceptionHandlingProblems.Handlers
{
    //handles interest calculation with argument validation
    public class InterestCalculationHandler
    {
        //calculate simple interest with validation
        public static double CalculateInterest(double amount, double rate, int years)
        {
            //check if amount is negative
            if (amount < 0)
            {
                throw new ArgumentException("Invalid input: Amount must be positive");
            }

            //check if rate is negative
            if (rate < 0)
            {
                throw new ArgumentException("Invalid input: Rate must be positive");
            }

            //check if years is negative
            if (years < 0)
            {
                throw new ArgumentException("Invalid input: Years must be positive");
            }

            //calculate simple interest: I = P * R * T / 100
            double interest = (amount * rate * years) / 100;
            return interest;
        }

        //run interest calculation with exception handling
        public static void Run()
        {
            Console.WriteLine("\n===== Invalid Input in Interest Calculation =====");
            Console.Write("Enter principal amount: ");
            string amountInput = Console.ReadLine();

            Console.Write("Enter rate of interest (%): ");
            string rateInput = Console.ReadLine();

            Console.Write("Enter time period (years): ");
            string yearsInput = Console.ReadLine();

            try
            {
                //parse inputs
                double amount = double.Parse(amountInput);
                double rate = double.Parse(rateInput);
                int years = int.Parse(yearsInput);

                //calculate interest
                double interest = CalculateInterest(amount, rate, years);
                Console.WriteLine($"Interest: {interest}");
            }
            catch (ArgumentException ex)
            {
                //handle argument validation errors
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                //handle invalid number format
                Console.WriteLine("Invalid input: Please enter valid numbers");
            }
            catch (Exception ex)
            {
                //handle any other exceptions
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
