using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.EmployeeManagementSystem
{
    public class Developer : Employee
    {
        string ProgrammingLanguages;
        public Developer (string name, int id, double salary,string prgrammingLanguages)
            : base(name, id, salary) 
        {
            this.ProgrammingLanguages = prgrammingLanguages;
        }

        public override string ToString()
        {
            return $"Name : {Name} , Id : {id} ,Salary : {salary} , Prgramming Language : {ProgrammingLanguages}";
        }
    }
}
