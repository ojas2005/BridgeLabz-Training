using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.map_interface
{
    internal class InverseDictionary
    {
        private static Dictionary<int, List<string>> TransposeDictionary(Dictionary<string, int> original)
        {
            Dictionary<int, List<string>> transposed = new Dictionary<int, List<string>>();

            foreach (var pair in original)
            {
                int key = pair.Value;
                string value = pair.Key;

                if (!transposed.ContainsKey(key))
                    transposed[key] = new List<string>();

                transposed[key].Add(value);
            }

            return transposed;
        }

        private static void DisplayOriginal(Dictionary<string, int> data)
        {
            Console.WriteLine("Original Dictionary (String -> Int):");
            foreach (var pair in data)
            {
                Console.WriteLine($"  {pair.Key} => {pair.Value}");
            }
        }

        private static void DisplayTransposed(Dictionary<int, List<string>> data)
        {
            Console.WriteLine("\nTransposed Dictionary (Int -> List<String>):");
            foreach (var pair in data)
            {
                Console.Write($"  {pair.Key} => [");
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.Write(pair.Value[i]);
                    if (i < pair.Value.Count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine("]");
            }
        }

        public static void Main(string[] args)
        {
            Dictionary<string, int> mapping = new Dictionary<string, int>
            {
                { "Alice", 10 },
                { "Bob", 20 },
                { "Charlie", 10 },
                { "David", 30 },
                { "Eve", 20 }
            };

            DisplayOriginal(mapping);
            Dictionary<int, List<string>> inversed = TransposeDictionary(mapping);
            DisplayTransposed(inversed);
        }
    }
}
