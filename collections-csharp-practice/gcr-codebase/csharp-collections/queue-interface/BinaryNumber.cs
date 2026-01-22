using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.queue_interface
{
    internal class BinaryNumber
    {
        private static void ProduceBinarySequence(int count)
        {
            Queue<string> binaryQueue = new Queue<string>();
            binaryQueue.Enqueue("1");

            Console.WriteLine($"First {count} binary numbers:");
            for (int i = 0; i < count; i++)
            {
                string current = binaryQueue.Dequeue();
                Console.WriteLine(current);
                
                binaryQueue.Enqueue(current + "0");
                binaryQueue.Enqueue(current + "1");
            }
        }

        public static void Main(string[] args)
        {
            ProduceBinarySequence(7);
        }
    }
}
