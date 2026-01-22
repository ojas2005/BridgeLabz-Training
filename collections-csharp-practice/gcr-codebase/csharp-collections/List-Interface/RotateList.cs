using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.List_Interface
{
    internal class RotateList
    {
        private static void PerformRotation(List<int> data, int positions)
        {
            if (data.Count == 0)
                return;

            positions = positions % data.Count;
            
            List<int> rotated = new List<int>();
            
            // Add elements from position onwards
            for (int i = positions; i < data.Count; i++)
                rotated.Add(data[i]);
            
            // Add first 'positions' elements
            for (int i = 0; i < positions; i++)
                rotated.Add(data[i]);

            data.Clear();
            data.AddRange(rotated);
        }

        private static void DisplayList(List<int> list)
        {
            foreach (int value in list)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        public static void Main(String[] args)
        {
            List<int> numbers = new List<int>
            {
                10,
                20,
                30,
                40,
                50,
                60,
                70
            };

            Console.WriteLine("Original list:");
            DisplayList(numbers);

            PerformRotation(numbers, 3);

            Console.WriteLine("After rotating by 3 positions:");
            DisplayList(numbers);
        }
    }
}
