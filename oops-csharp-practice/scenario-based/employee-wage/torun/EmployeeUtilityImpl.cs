using System;

class EmployeeUtilityImpl : IEmployee
{
    private Employee[] employee = new Employee[100];
    private int count=0;
    public void AddEmployee()
    {
        Employee emp = new Employee();
        Console.Write("enter employee id: ");
        emp.EmployeeId = Console.ReadLine();
        Console.Write("salary: ");
        emp.EmployeeSalary = Convert.ToDouble(Console.ReadLine());
        Console.Write("email: ");
        emp.EmployeeEmail = Console.ReadLine();
        Console.Write("phone: ");
        emp.EmployeePhone = Console.ReadLine();
        employee[count] = emp;
        count++;
        Console.WriteLine("employee added successfully");
    }

    public void DisplayEmployees()
    {
        if (count==0)
        {
            Console.WriteLine("add employee first");
            return;
        }

        for (int i=0;i<count;i++)
        {
            Console.WriteLine($"employee {i + 1}: {employee[i]}");
        }
    }
    public void MarkAttendance()
    {
        if (count==0)
        {
            Console.WriteLine("add employee first");
            return;
        }
        DisplayEmployees();
        Console.Write("enter employee number: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        string status = GetAttendance();
        Console.WriteLine("attendance: " + status);
        if (status == "Present")
            Console.WriteLine("today wage: " + CalculateWage());
        else
            Console.WriteLine("today wage: 0");
    }
    public void CalculateTodayWage()
    {
        if (count==0)
        {
            Console.WriteLine("add employee first");
            return;
        }
        DisplayEmployees();
        Console.Write("enter employee number: ");
        int index = int.Parse(Console.ReadLine())-1;
        string status = GetAttendance();
        Console.WriteLine("attendance: " + status);
        if (status == "Present")
            Console.WriteLine("today wage: " + CalculateWage());
        else
            Console.WriteLine("today wage: 0");
    }
    private string GetAttendance()
    {
        Random r = new Random();
        return r.Next(0, 2) == 0 ? "Absent" : "Present";
    }

    private int CalculateWage()
    {
        int perHourWage = 20;
        int totalHours = 8;
        return perHourWage * totalHours;
    }
    public void CalculateMonthlyWage()
    {
    if (count==0)
    {
        Console.WriteLine("add employee first");
        return;
    }
    DisplayEmployees();
    Console.Write("enter employee number: ");
    int index = int.Parse(Console.ReadLine()) - 1;
    int workingDays=20;
    int presentDays = 0;
    for (int i=1;i<=workingDays;i++)
    {
        if (GetAttendance()=="Present")
        {
            presentDays++;
        }
    }
    int perDayWage = CalculateWage();
    int monthlyWage = presentDays * perDayWage;
    Console.WriteLine($"employee present days: {presentDays}");
    Console.WriteLine($"monthly wage: {monthlyWage}");
}

}
