sealed class EmployeeMenu
{
    private IEmployee empUtility;
    private Employee[] employee=new Employee[100];
    static int count=0;
    public EmployeeMenu()
    {
        empUtility=new EmployeeUtilityImpl();
        ShowMenu();
    }
    private void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("press 1 to add employee");
            Console.WriteLine("press 2 to delete employee");
            Console.WriteLine("press 3 to display employee details");
            Console.WriteLine("press 4 to mark attendance");
            Console.WriteLine("press 5 to exit");
            Console.WriteLine(" ");

            choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    employee[count]=AddEmployee();
                    count++;
                    break;

                case 3:
                    DisplayEmployee();
                    break;

                case 4:
                    PresentAbsent();
                    break;

                case 5:
                    return;
            }

        } while (choice !=5);
    }

    private Employee AddEmployee()
    {
        Employee emp=empUtility.AddEmployee();
        Console.Write("enter employee id: ");
        emp.EmployeeId=Console.ReadLine();
        Console.Write("salary: ");
        emp.EmployeeSalary=Convert.ToDouble(Console.ReadLine());
        Console.Write("email: ");
        emp.EmployeeEmail=Console.ReadLine();
        Console.Write("phone: ");
        emp.EmployeePhone=Console.ReadLine();
        Console.WriteLine("added the employee details");
        return emp;
    }

    private void DisplayEmployee()
    {
        if(count==0)
        {
            Console.WriteLine("add employee first");
            return;
        }

        for(int i=0;i<count;i++)
        {
            Console.WriteLine($"employee {i+1}: {employee[i]}");
        }
    }

    private void PresentAbsent()
    {
        if(count==0)
        {
            Console.WriteLine("add employee first");
            return;
        }
        DisplayEmployee();
        Console.Write("enter employee number ");
        int index=int.Parse(Console.ReadLine());
        string status=empUtility.Attendace(employee[index]);
        Console.WriteLine("attendance: " + status);

    }
}
