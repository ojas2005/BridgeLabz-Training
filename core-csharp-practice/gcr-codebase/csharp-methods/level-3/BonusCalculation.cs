using System;
class BonusCalculation
{
    // method to generate salary and years of service
    public static int[,] GenerateEmployeeData(int employees)
    {
        int[,] data = new int[employees,2];
        Random random = new Random();

        for (int i = 0; i < employees; i++)
        {
            //generate 5-digit salary (10000 to 99999)
            data[i, 0] = random.Next(10000, 100000);

            //generate years of service (1 to 10)
            data[i, 1] = random.Next(1, 11);
        }

        return data;
    }

    // method to calculate new salary and bonus
    public static double[,] CalculateBonus(int[,] data)
    {
        int employees = data.GetLength(0);
        double[,] result = new double[employees, 2];

        for (int i = 0; i < employees; i++)
        {
            int salary = data[i, 0];
            int years = data[i, 1];
            double bonusRate;
            if (years > 5)
                bonusRate = 0.05;   // 5% bonus
            else
                bonusRate = 0.02;   // 2% bonus
            double bonus = salary * bonusRate;
            double newSalary = salary + bonus;
            result[i, 0] = newSalary;
            result[i, 1] = bonus;
        }
        return result;
    }

    // method to calculate totals and display result in tabular format
    public static void DisplayReport(int[,] oldData, double[,] newData)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        for (int i = 0; i < oldData.GetLength(0); i++)
        {
            int oldSalary = oldData[i, 0];
            int years = oldData[i, 1];
            double bonus = newData[i, 1];
            double newSalary = newData[i, 0];
            totalOldSalary += oldSalary;
            totalBonus += bonus;
            totalNewSalary += newSalary;
        }

        Console.WriteLine("Total Old Salary: " + totalOldSalary);
        Console.WriteLine("Total Bonus Paid: " + totalBonus);
        Console.WriteLine("Total New Salary: " + totalNewSalary);
    }

    static void Main()
    {
        int employees = 10;

        // generate salary and service years
        int[,] employeeData = GenerateEmployeeData(employees);

        // calculate bonus and new salary
        double[,] updatedData = CalculateBonus(employeeData);

        // display final report
        DisplayReport(employeeData, updatedData);
    }
}
