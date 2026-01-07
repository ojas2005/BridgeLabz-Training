sealed class EmployeeMenu
{
    private IEmployee empUtility;

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
            Console.WriteLine("\nMenu");
            Console.WriteLine("press 1 to add employee");
            Console.WriteLine("press 2 to check today wage");
            Console.WriteLine("press 3 to display employees");
            Console.WriteLine("press 4 to mark attendance");
            Console.WriteLine("press 5 for part time wages");
            Console.WriteLine("press 9 to exit");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    empUtility.AddEmployee();
                    break;
                case 2:
                    empUtility.CalculateTodayWage();
                    break;
                case 3:
                    empUtility.DisplayEmployees();
                    break;
                case 4:
                    empUtility.MarkAttendance();
                    break;
                case 5:
                    empUtility.DisplayEmployees();
                    break;
                case 9:
                    return;
            }
        } while(choice!=5);
    }
}
