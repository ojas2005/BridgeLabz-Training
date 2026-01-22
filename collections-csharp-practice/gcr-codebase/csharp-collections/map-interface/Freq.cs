using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.map_interface
{
    internal class WordFrequency
    {
        public static void Main(string[] args)
        {
            string passage = "The quick brown fox jumps over the lazy dog. The fox is quick.";
            string normalized = passage.ToLower();

            char[] delimiters = { ' ', '.', ',', '!', '?', ';', ':' };
            string[] wordList = normalized.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in wordList)
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }

            Console.WriteLine("Word Frequency Analysis:");
            Console.WriteLine(new string('-', 30));
            foreach (var entry in wordCount)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
