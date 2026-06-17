using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.SchoolSystem
{
    internal class Student : Person
    {
        string Grade;

        public Student(string name, int age, string grade)
            : base(name, age)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            return "Student : " + base.ToString() + $" , Grade : {Grade}";

        }
    }
}
