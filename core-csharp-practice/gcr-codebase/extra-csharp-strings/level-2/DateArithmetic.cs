using System;
class DateArithmetic{
    static void Main()
    {
         DateTime originalDate = DateTime.Parse(Console.ReadLine());
         DateTime newDate =     originalDate.AddDays(7);
         newDate =     originalDate.AddMonthss(1);
         newDate =     originalDate.AddYears(2);
         newDate =     originalDate.AddDays(-21);
         Console.WriteLine(newDate);
    }
}