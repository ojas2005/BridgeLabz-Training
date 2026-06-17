using System;
public class Employee
    {
        public int employeeID;
        protected string department;
        private double salary;
        public Employee()
        {
            this.employeeID=221500;
            this.department="Emp1";
            this.salary=42000;
        }
        public Employee(int employeeID, string department, double salary)
        {
            this.employeeID=employeeID;
            this.department=department;
            this.salary=salary;
        }
        public double GetSalary()
        {
            return salary;
        }
        public void SetSalary(double salary)
        {
            if (salary>0)
            {
                this.salary=salary;
            }
            else
            {
                Console.WriteLine("enter valid salary");
            }
        }
        public virtual void Display()
        {
            double salary = GetSalary();
            Console.WriteLine($"Salary of Employee with employee id {employeeID},from department {department} is {salary}");
        }
    }
    public class Manager : Employee
    {
        public Manager() : base(221511,"management",17000)
        {

        }
        public override void Display()
        {
            double manSalary = GetSalary();
            Console.WriteLine($"Salary of Manager with manager id {employeeID},from department {department} is {manSalary}");
        }
    }