using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.set_interface
{
    internal class SetMethods
    {
        private static void PrintSet(HashSet<int> elements, string label)
        {
            Console.Write($"{label}: ");
            foreach (int num in elements)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        private static void PrintList(List<int> elements, string label)
        {
            Console.Write($"{label}: ");
            foreach (int num in elements)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        public static void Main(String[] args)
        {
            HashSet<int> setA = new HashSet<int> { 1, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 1, 2, 4, 6 };

            PrintSet(setA, "Set A");
            PrintSet(setB, "Set B");

            bool areEqual = setA.SetEquals(setB);
            Console.WriteLine($"Sets Equal: {areEqual}\n");

            HashSet<int> combined = new HashSet<int>(setA);
            combined.UnionWith(setB);
            PrintSet(combined, "Union");

            HashSet<int> common = new HashSet<int>(setA);
            common.IntersectWith(setB);
            PrintSet(common, "Intersection");

            HashSet<int> symmetric = new HashSet<int>(setA);
            symmetric.SymmetricExceptWith(setB);
            PrintSet(symmetric, "Symmetric Difference");

            List<int> sortedUnion = new List<int>(combined);
            sortedUnion.Sort();
            PrintList(sortedUnion, "Sorted Union");

            bool isSuperset = setA.IsSupersetOf(common);
            Console.WriteLine($"Set A is superset of Intersection: {isSuperset}");
        }
    }
}
