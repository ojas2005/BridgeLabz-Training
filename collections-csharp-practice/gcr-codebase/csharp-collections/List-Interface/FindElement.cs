using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.List_Interface
{
    internal class FindElement
    {
        private static string FindElementAtDistanceFromEnd(LinkedList<string> list, int distance)
        {
            var quickPointer = list.First;
            var slowPointer = list.First;

            // Advance quick pointer by distance positions
            for (int i = 0; i < distance; i++)
            {
                if (quickPointer == null)
                    return null;
                quickPointer = quickPointer.Next;
            }

            // Move both pointers until quick reaches end
            while (quickPointer != null)
            {
                slowPointer = slowPointer.Next;
                quickPointer = quickPointer.Next;
            }

            return slowPointer.Value;
        }

        private static void PrintLinkedList(LinkedList<string> list)
        {
            Console.Write("LinkedList: ");
            foreach (string item in list)
                Console.Write(item + " ");
            Console.WriteLine();
        }

        public static void Main(String[] args)
        {
            LinkedList<string> words = new LinkedList<string>();
            words.AddLast("hello");
            words.AddLast("world");
            words.AddLast("from");
            words.AddLast("csharp");
            words.AddLast("program");
            words.AddLast("design");

            PrintLinkedList(words);

            string result = FindElementAtDistanceFromEnd(words, 3);
            Console.WriteLine($"Element at distance 3 from end: {result}");
        }
    }
}
