using System;
using System.Collections;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.List_Interface
{
    internal class ReverseList
    {
        private static void SwapArrayElements(ArrayList collection)
        {
            int left = 0;
            int right = collection.Count - 1;

            while (left < right)
            {
                object temp = collection[left];
                collection[left] = collection[right];
                collection[right] = temp;
                left++;
                right--;
            }
        }

        private static void SwapLinkedListNodes(LinkedList<int> collection)
        {
            var frontNode = collection.First;
            var backNode = collection.Last;

            for (int i = 0; i < collection.Count / 2; i++)
            {
                int temp = frontNode.Value;
                frontNode.Value = backNode.Value;
                backNode.Value = temp;

                frontNode = frontNode.Next;
                backNode = backNode.Previous;
            }
        }

        private static void ShowArrayList(ArrayList arr)
        {
            foreach (object element in arr)
                Console.Write(element + " ");
        }

        private static void ShowLinkedList(LinkedList<int> list)
        {
            foreach (int element in list)
                Console.Write(element + " ");
        }

        public static void Main(String[] args)
        {
            ArrayList dynamicList = new ArrayList
            {
                1, 2, 3, 4, 5
            };

            LinkedList<int> genericList = new LinkedList<int>();
            genericList.AddLast(1);
            genericList.AddLast(2);
            genericList.AddLast(3);
            genericList.AddLast(4);
            genericList.AddLast(5);

            Console.WriteLine("ArrayList before reversal:");
            ShowArrayList(dynamicList);
            Console.WriteLine();

            Console.WriteLine("LinkedList before reversal:");
            ShowLinkedList(genericList);
            Console.WriteLine("\n");

            SwapArrayElements(dynamicList);
            SwapLinkedListNodes(genericList);

            Console.WriteLine("ArrayList after reversal:");
            ShowArrayList(dynamicList);
            Console.WriteLine();

            Console.WriteLine("LinkedList after reversal:");
            ShowLinkedList(genericList);
            Console.WriteLine();
        }
    }
}
