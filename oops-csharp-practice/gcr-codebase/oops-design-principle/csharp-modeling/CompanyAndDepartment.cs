using System;

namespace BridgelabzTraining.class_modeling_and_diagram.csharp_modeling
{
    internal class CompanyAndDepartment
    {
        static void Main(string[] args)
        {
            Company org = new Company("BridgeLabz");
            org.Show();
        }
    }
    class Company
    {
        public string orgName;
        public Department[] Departments = new Department[2];

        public Company(string orgName)
        {
            this.orgName = orgName;
            Departments[0] = new Department("HR");
            Departments[1] = new Department("IT");
        }

        public void Show()
        {
            Console.WriteLine($"company name is {orgName}");
            for (int i = 0; i < Departments.Length; i++)
            {
                Console.WriteLine($"department is {Departments[i].DepartmentName}");
            }
        }
    }
    class Department
    {
        public string DepartmentName;
        public Department(string DepartmentName)
        {
            this.DepartmentName = DepartmentName;
        }
    }
}
