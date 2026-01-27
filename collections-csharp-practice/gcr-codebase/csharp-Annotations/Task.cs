using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TaskInfoAttribute : Attribute
    {
        public string Priority { get; }
        public string AssignedTo { get; }

        public TaskInfoAttribute(string priority, string assignedTo)
        {
            Priority = priority;
            AssignedTo = assignedTo;
        }
    }
    public class TaskManager
    {
        [TaskInfo("High", "Alice")]
        public void CompleteReport()
        {
            Console.WriteLine("Report completed");
        }
    }
    class Task
    {
        static void Main()
        {
            MethodInfo method = typeof(TaskManager).GetMethod("CompleteReport");

            var attribute = method.GetCustomAttribute<TaskInfoAttribute>();

            Console.WriteLine($"Priority: {attribute.Priority}");
            Console.WriteLine($"Assigned To: {attribute.AssignedTo}");
        }
    }
}
