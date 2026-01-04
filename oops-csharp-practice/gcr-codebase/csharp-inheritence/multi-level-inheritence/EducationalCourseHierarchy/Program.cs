using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.Multilevel_Inheritance.EducationalCourseHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("C# Basics", 6);

            Course onlineCourse = new OnlineCourse(
                "C# Advanced",
                8,
                "Udemy",
                true
            );

            Course paidCourse = new PaidOnlineCourse(
                "Full Stack Development", 12, "Coursera", true, 15000, 20
            );

            Console.WriteLine(course);
            Console.WriteLine(onlineCourse);
            Console.WriteLine(paidCourse);
        }
    }
}
