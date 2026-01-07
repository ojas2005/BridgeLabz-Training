using System;

namespace OfficeApp
{
    internal class Menu
    {
        Employee[] emps;
        int cnt;

        public Menu()
        {
            emps=new Employee[5];
            cnt=0;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nemployee management");
                Console.WriteLine("1. add full time employee");
                Console.WriteLine("2. add part time employee");
                Console.WriteLine("3. show all employees");
                Console.WriteLine("4. exit");
                Console.Write("choose option: ");

                int opt=Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        AddFullTime();
                        break;
                    case 2:
                        AddPartTime();
                        break;
                    case 3:
                        ShowAll();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }

        private void AddFullTime()
        {
            if (cnt >= emps.Length)
            {
                Console.WriteLine("storage full");
                return;
            }

            Console.Write("enter id: ");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter name: ");
            string nm=Console.ReadLine();
            Console.Write("enter salary: ");
            double sal=Convert.ToDouble(Console.ReadLine());
            Console.Write("enter department: ");
            string dept=Console.ReadLine();

            FullTimeEmployee emp=new FullTimeEmployee(id, nm, sal);
            emp.SetDepartment(dept);
            emps[cnt++]=emp;
            Console.WriteLine("full time employee added");
        }

        private void AddPartTime()
        {
            if (cnt >= emps.Length)
            {
                Console.WriteLine("storage full");
                return;
            }

            Console.Write("enter id: ");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter name: ");
            string nm=Console.ReadLine();
            Console.Write("enter hourly rate: ");
            double rate=Convert.ToDouble(Console.ReadLine());
            Console.Write("enter work hours: ");
            int hrs=Convert.ToInt32(Console.ReadLine());
            Console.Write("enter department: ");
            string dept=Console.ReadLine();

            PartTimeEmployee emp=new PartTimeEmployee(id, nm, rate, hrs);
            emp.SetDepartment(dept);
            emps[cnt++]=emp;
            Console.WriteLine("part time employee added");
        }

        private void ShowAll()
        {
            if (cnt == 0)
            {
                Console.WriteLine("no employees found");
                return;
            }

            for (int i=0; i < cnt; i++)
            {
                emps[i].Show();
                if (emps[i] is IDepartment d)
                {
                    Console.WriteLine("department: " + d.GetDept());
                }
            }
        }
    }
}
