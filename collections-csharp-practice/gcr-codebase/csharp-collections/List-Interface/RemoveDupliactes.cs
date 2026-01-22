using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.List_Interface
{
    internal class RemoveDuplicates
    {
        private static List<int> EliminateDuplicates(List<int> input)
        {
            HashSet<int> encountered = new HashSet<int>();
            List<int> unique = new List<int>();

            foreach (int value in input)
            {
                if (encountered.Add(value))
                    unique.Add(value);
            }

            return unique;
        }

        private static void PrintList(List<int> list)
        {
            foreach (int value in list)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        public static void Main(String[] args)
        {
            List<int> numbers = new List<int>
            {
                1,
                2,
                1,
                3,
                2,
                1,
                4,
                5,
                3
            };

            Console.WriteLine("Original list with duplicates:");
            PrintList(numbers);

            List<int> deduplicated = EliminateDuplicates(numbers);
            
            Console.WriteLine("After removing duplicates:");
            PrintList(deduplicated);
        }
    }
}
