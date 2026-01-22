using System;
using System.IO;

namespace DataStreamProcessing
{
    /// <summary>
    /// Searches for specific terms within large text files line-by-line.
    /// Demonstrates efficient streaming for large file processing without loading entire content into memory.
    /// </summary>
    class TextSearchUtility
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Text File Search Utility ===\n");

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File does not exist.");
                return;
            }

            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();

            try
            {
                SearchInFile(filePath, searchTerm);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
        }

        private static void SearchInFile(string filePath, string searchTerm)
        {
            int matchCount = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Line {lineNumber}: {line}");
                        matchCount++;
                    }
                }
            }

            Console.WriteLine($"\nTotal matches found: {matchCount}");
        }
    }
}
