using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStreamProcessing
{
    /// <summary>
    /// Analyzes text files to compute word frequency statistics.
    /// Identifies and displays the most frequently occurring words in a document.
    /// </summary>
    class TextAnalysisEngine
    {
        private static readonly char[] WORD_DELIMITERS = { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?', '-', '(', ')' };

        static void Main(string[] args)
        {
            Console.WriteLine("=== Text Analysis Engine ===\n");

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File does not exist.");
                return;
            }

            try
            {
                Dictionary<string, int> wordFrequency = AnalyzeTextFile(filePath);
                DisplayTopWords(wordFrequency, topCount: 10);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File I/O Error: {ex.Message}");
            }
        }

        private static Dictionary<string, int> AnalyzeTextFile(string filePath)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(WORD_DELIMITERS, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        string normalizedWord = word.ToLower();
                        
                        if (frequency.ContainsKey(normalizedWord))
                            frequency[normalizedWord]++;
                        else
                            frequency[normalizedWord] = 1;
                    }
                }
            }

            return frequency;
        }

        private static void DisplayTopWords(Dictionary<string, int> frequency, int topCount)
        {
            var topWords = frequency
                .OrderByDescending(w => w.Value)
                .Take(topCount)
                .ToList();

            Console.WriteLine($"\nTop {topCount} Most Frequent Words:");
            Console.WriteLine(new string('-', 40));

            int rank = 1;
            foreach (var word in topWords)
            {
                Console.WriteLine($"{rank,2}. {word.Key,-20} : {word.Value,5} occurrences");
                rank++;
            }
        }
    }
}
