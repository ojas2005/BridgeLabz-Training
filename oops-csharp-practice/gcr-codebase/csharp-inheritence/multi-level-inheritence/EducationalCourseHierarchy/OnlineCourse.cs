using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.Multilevel_Inheritance.EducationalCourseHierarchy
{
    internal class OnlineCourse : Course
    {
        protected string Platform;
        protected bool IsRecorded;

        // parametrized constructor of child class Named Online Course
        public OnlineCourse(string courseName, int duration, string platform, bool isRecorded)
            : base(courseName, duration)
        {
            this.Platform = platform;
            this.IsRecorded = isRecorded;
        }

        //string override method
        public override string ToString()
        {
            return base.ToString() +
                   $" , Platform : {Platform} , Recorded : {IsRecorded}";
        }
    }
}
