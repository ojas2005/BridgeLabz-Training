using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.List_Interface
{
    internal class CountFrequency
    {
        private static Dictionary<string, int> ComputeOccurrences(List<string> data)
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();
            
            foreach (string element in data)
            {
                if (occurrences.ContainsKey(element))
                    occurrences[element]++;
                else
                    occurrences[element] = 1;
            }

            return occurrences;
        }

        private static void PrintElements(List<string> elements)
        {
            Console.Write("Elements: ");
            foreach (string element in elements)
                Console.Write(element + " ");
            Console.WriteLine();
        }

        private static void PrintFrequencies(Dictionary<string, int> frequencies)
        {
            Console.WriteLine("Frequency Distribution:");
            foreach (var pair in frequencies)
                Console.WriteLine($"  {pair.Key}: {pair.Value} times");
        }

        public static void Main(String[] args)
        {
            List<String> fruits = new List<string>
            {
                "apple",
                "banana",
                "orange",
                "apple",
                "banana",
                "apple",
                "grape"
            };

            PrintElements(fruits);
            Console.WriteLine();

            Dictionary<string, int> fruitCounts = ComputeOccurrences(fruits);
            PrintFrequencies(fruitCounts);
        }
    }
}
