using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.introduction_of_inheritence.EmployeeManagementSystem
{
    public class Employee
    {
        protected String Name;
        protected int id;
        protected double salary;

        public Employee(String name, int id, double salary)
        {
            this.Name = name;
            this.id = id;
            this.salary = salary;
        }

        public override String ToString()
        {
            return $"Name : {Name} , Id : {id} ,Salary : {salary}";
        }
    }
}
