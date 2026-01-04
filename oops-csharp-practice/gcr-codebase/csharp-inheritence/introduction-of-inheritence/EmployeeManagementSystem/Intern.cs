using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.EmployeeManagementSystem
{
    internal class Intern : Employee
    {
        string Duration;
        public Intern(string name ,int id , double salary ,string duration)
            : base(name, id, salary)
        {
            this.Duration = duration;
        }

        public override string ToString()
        {
            return $"Name : {Name} , Id : {id} ,Salary : {salary} , Duration : {Duration}";
        }

    }
}
