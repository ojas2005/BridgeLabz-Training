using System;
using ExceptionHandlingProblems.Handlers;

namespace ExceptionHandlingProblems
{
    //main entry point for all exception handling examples
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n========== EXCEPTION HANDLING PROBLEMS ==========");
                Console.WriteLine("1. File Not Found Exception");
                Console.WriteLine("2. Division and Input Errors");
                Console.WriteLine("3. Custom Exception (Age Validation)");
                Console.WriteLine("4. Multiple Exceptions (Array Operations)");
                Console.WriteLine("5. Using Statement for File Handling");
                Console.WriteLine("6. Invalid Input in Interest Calculation");
                Console.WriteLine("7. Finally Block Execution");
                Console.WriteLine("8. Propagating Exceptions Across Methods");
                Console.WriteLine("9. Nested try-catch Blocks");
                Console.WriteLine("10. Bank Transaction System");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================================\n");

                Console.Write("Select a problem (0-10): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FileNotFoundHandler.Run();
                        break;
                    case "2":
                        DivisionAndInputHandler.Run();
                        break;
                    case "3":
                        AgeValidationHandler.Run();
                        break;
                    case "4":
                        ArrayOperationsHandler.Run();
                        break;
                    case "5":
                        FileStreamHandler.Run();
                        break;
                    case "6":
                        InterestCalculationHandler.Run();
                        break;
                    case "7":
                        FinallyBlockHandler.Run();
                        break;
                    case "8":
                        ExceptionPropagationHandler.Run();
                        break;
                    case "9":
                        NestedTryCatchHandler.Run();
                        break;
                    case "10":
                        BankTransactionHandler.Run();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nThank you for practicing exception handling!");
        }
    }
}
