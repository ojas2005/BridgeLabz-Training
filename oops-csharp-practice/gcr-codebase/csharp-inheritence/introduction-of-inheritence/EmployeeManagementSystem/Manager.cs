using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.EmployeeManagementSystem
{
    public class Manager : Employee
    {
        int TeamSize;
        public Manager(string name , int id, double salary, int teamSize) : base(name, id, salary)
        {
            this.TeamSize = teamSize;
        }

        public override string ToString()
        {
            return $"Name : {Name} , Id : {id} ,Salary : {salary} , TeamSize : {TeamSize}";
        }
    }
}
