using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections.queue_interface
{
    internal class PriorityQueueDemo
    {
        public static void Main(string[] args)
        {
            PriorityQueue<string, int> taskQueue = new PriorityQueue<string, int>();

            // Enqueue tasks with priorities (lower number = higher priority)
            taskQueue.Enqueue("Database Backup", 1);
            taskQueue.Enqueue("Email Notifications", 5);
            taskQueue.Enqueue("System Update", 2);
            taskQueue.Enqueue("Cache Cleanup", 8);
            taskQueue.Enqueue("User Authentication", 3);

            Console.WriteLine("Processing tasks by priority:");
            while (taskQueue.Count > 0)
            {
                string task = taskQueue.Dequeue();
                Console.WriteLine($"  Executing: {task}");
            }
        }
    }
}
