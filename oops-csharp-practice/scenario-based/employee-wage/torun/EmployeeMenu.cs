using System;

sealed class EmployeeMenu
{
    private IEmployee empUtility;
    private Employee[] employee = new Employee[100];

    static int count = 0;
    public EmployeeMenu()
    {
        empUtility = new EmployeeUtilityImpl();
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
            Console.WriteLine("press 4 to mark ettendance");
            Console.WriteLine("press 5 to exit");
            Console.Write("\n");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    
                    employee[count] = AddEmployee();
                    count++;
                    break;
                case 2:
                    break;
                case 3:

                    DisplayEmployee();
                    break;
                case 4:
                    for(int i = 0;i<count;i++)
                    {
                    empUtility.Attendace();
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("enter valid choice");
                    break;
            }

        } while (choice!=0);
    }
    private Employee AddEmployee()
    {
        Employee emp = empUtility.AddEmployee();
        Console.Write("enter employee id");
        emp.EmployeeId = Console.ReadLine();
        Console.Write("salary");
        emp.EmployeeSalary = Convert.ToDouble(Console.ReadLine());
        Console.Write("email");
        emp.EmployeeEmail = Console.ReadLine();
        Console.Write("phone");
        emp.EmployeePhone = Console.ReadLine();
        Console.WriteLine("added the employee details");
        return emp;
    }   
    private void DisplayEmployee()
    {
        if (employee==null)
        {
            Console.WriteLine("add a employee first");
            return;
        }

        for(int i = 0;i<count;i++)
        {
        Console.WriteLine("details");
        Console.WriteLine(employee[i]);
        }
    }
}
