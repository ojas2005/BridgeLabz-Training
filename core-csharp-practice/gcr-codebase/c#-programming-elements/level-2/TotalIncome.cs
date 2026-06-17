using System;
class TotalIncome
{
    static void Main()
    {
        //taking salary and bonus as input from user.
        int salary = int.Parse(Console.ReadLine());
        int bonus = int.Parse(Console.ReadLine());

        //calculating total income.
        int totalIncome = salary+bonus;

        //printing the results.
        Console.WriteLine($"The salary is INR {salary} and bonus is INR {bonus}. Hence Total Income is INR {totalIncome} ");
    }
}
