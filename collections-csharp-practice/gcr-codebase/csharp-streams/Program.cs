using System;

namespace DataStreamProcessing
{
    /// <summary>
    /// Entry point for the Data Stream Processing application.
    /// Provides menu-driven access to various stream processing utilities.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine("║   Data Stream Processing Utilities Suite           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════╝\n");

            Console.WriteLine("Select a utility:\n");
            Console.WriteLine("1. File Copy Performance Analyzer");
            Console.WriteLine("2. Binary File Data Handler");
            Console.WriteLine("3. Media File Converter");
            Console.WriteLine("4. File Copy Utility");
            Console.WriteLine("5. Text Transformation Processor");
            Console.WriteLine("6. Text Search Utility");
            Console.WriteLine("7. Inter-Process Pipe Communication");
            Console.WriteLine("8. JSON Data Persistence Manager");
            Console.WriteLine("9. User Profile Writer");
            Console.WriteLine("10. Text Analysis Engine");
            Console.WriteLine("11. Exit\n");

            Console.Write("Enter your choice (1-11): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    FileCopyPerformanceAnalyzer.Main(args);
                    break;
                case "2":
                    BinaryFileDataHandler.Main(args);
                    break;
                case "3":
                    MediaFileConverter.Main(args);
                    break;
                case "4":
                    FileCopyUtility.Main(args);
                    break;
                case "5":
                    TextTransformationProcessor.Main(args);
                    break;
                case "6":
                    TextSearchUtility.Main(args);
                    break;
                case "7":
                    InterProcessPipeComm.Main(args);
                    break;
                case "8":
                    JsonDataPersistence.Main(args);
                    break;
                case "9":
                    UserProfileWriter.Main(args);
                    break;
                case "10":
                    TextAnalysisEngine.Main(args);
                    break;
                case "11":
                    Console.WriteLine("\nExiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please run the program again.");
                    break;
            }
        }
    }
}
