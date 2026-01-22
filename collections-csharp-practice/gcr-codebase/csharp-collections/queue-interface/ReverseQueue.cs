using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.queue_interface
{
    internal class ReverseQueue
    {
        private static void DisplayQueue(Queue<int> queue)
        {
            foreach (int value in queue)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        private static void ReverseQueueRecursive(Queue<int> queue)
        {
            if (queue.Count == 0)
                return;

            int frontElement = queue.Dequeue();
            ReverseQueueRecursive(queue);
            queue.Enqueue(frontElement);
        }

        public static void Main(string[] args)
        {
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.Enqueue(40);
            myQueue.Enqueue(50);

            Console.WriteLine("Original Queue:");
            DisplayQueue(new Queue<int>(myQueue));

            ReverseQueueRecursive(myQueue);

            Console.WriteLine("Reversed Queue:");
            DisplayQueue(myQueue);
        }
    }
}
