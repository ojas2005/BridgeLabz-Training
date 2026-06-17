using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.hierarchical_inheritence.SchoolSystem
{
    internal class Teacher : Person
    {
        string Subject;

        public Teacher(string name, int age, string subject)
            : base(name, age)
        {
            this.Subject = subject;
        }

        public override string ToString()
        {
            return "Teacher : " +
                   base.ToString() +
                   $" , Subject : {Subject}";
        }
    }
}
