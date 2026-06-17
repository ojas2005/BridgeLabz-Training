using System;
using System.IO;
using IPLCensorshipAnalyzer.Services;

namespace IPLCensorshipAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string inputDataFolder = Path.Combine(baseDirectory, "data", "input");
            string outputDataFolder = Path.Combine(baseDirectory, "data", "output");

            Directory.CreateDirectory(outputDataFolder);

            var censorshipEngine = new CensorshipRulesEngine();
            var jsonDataHandler = new JsonDataHandler(censorshipEngine);
            var csvDataHandler = new CsvDataHandler(censorshipEngine);
            var dataProcessor = new DataProcessor(jsonDataHandler, csvDataHandler, censorshipEngine);

            dataProcessor.ProcessAllData(inputDataFolder, outputDataFolder);

            Console.WriteLine("\npress any key to exit...");
            Console.ReadKey();
        }
    }
}
