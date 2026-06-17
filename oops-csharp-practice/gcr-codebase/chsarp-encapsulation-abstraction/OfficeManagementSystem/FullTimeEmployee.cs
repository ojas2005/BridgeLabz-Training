using System;

namespace OfficeApp
{
    internal class FullTimeEmployee : Employee, IDepartment
    {
        private string dept;

        public FullTimeEmployee(int id, string nm, double sal)
            : base(id, nm, sal)
        {
        }

        public override double GetSalary()
        {
            return sal;
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
