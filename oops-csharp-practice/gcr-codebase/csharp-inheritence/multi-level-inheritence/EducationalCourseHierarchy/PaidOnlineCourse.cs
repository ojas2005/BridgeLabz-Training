using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.Multilevel_Inheritance.EducationalCourseHierarchy
{
    internal class PaidOnlineCourse : OnlineCourse
    {
        double Fee;
        double Discount;

        public PaidOnlineCourse(string courseName, int duration, string platform, bool isRecorded,
                             double fee, double discount) : base(courseName, duration, platform, isRecorded)

        {
            this.Fee = fee;
            this.Discount = discount;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $" , Fee : {Fee} , Discount : {Discount}%";
        }
    }
}
