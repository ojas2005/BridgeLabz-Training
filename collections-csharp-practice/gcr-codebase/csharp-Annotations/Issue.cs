using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; }

        public BugReportAttribute(string description)
        {
            Description = description;
        }
    }
    public class IssueTracker
    {
        [BugReport("NullReferenceException occurs on login")]
        [BugReport("UI freezes after submit")]
        public void SubmitForm()
        {
            Console.WriteLine("Form submitted");
        }
    }
    class Issue
    {
        static void Main()
        {
            MethodInfo method = typeof(IssueTracker).GetMethod("SubmitForm");

            var bugs = method.GetCustomAttributes<BugReportAttribute>();

            foreach (var bug in bugs)
            {
                Console.WriteLine("Bug: " + bug.Description);
            }
        }
    }
}
