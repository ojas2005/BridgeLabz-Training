using System;

namespace OfficeApp
{
    internal class PartTimeEmployee : Employee, IDepartment
    {
        private int hrs;
        private string dept;

        public PartTimeEmployee(int id, string nm, double rate, int hrs)
            : base(id, nm, rate)
        {
            this.hrs=hrs;
        }

        public override double GetSalary()
        {
            return sal * hrs;
        }

        public void SetDepartment(string deptName)
        {
            dept=deptName;
        }

        public string GetDept()
        {
            return dept;
        }
    }
}
