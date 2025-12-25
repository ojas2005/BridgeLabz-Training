using System;

class Calendar
{
    // method to get month name
    public static string GetMonthName(int month)
    {
        string[] months = {"January", "February", "March", "April", "May", "June","July", "August", "September", "October", "November", "December"
        };
        return months[month - 1];
    }

    // method to check leap year
    public static bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
            return true;
        if (year % 100 == 0)
            return false;
        if (year % 4 == 0)
            return true;

        return false;
    }

    // method to get number of days in month
    public static int GetDaysInMonth(int month, int year)
    {
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (month == 2 && IsLeapYear(year))
            return 29;

        return days[month - 1];
    }

    // method to get first day of month using Gregorian algorithm
    public static int GetFirstDay(int day, int month, int year)
    {
        int y0 = year - (14 - month) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = month + 12 * ((14 - month) / 12) - 2;
        int d0 = (day + x + (31 * m0) / 12) % 7;

        return d0;
    }

    static void Main()
    {
        int month = int.Parse(Console.ReadLine()); //enter month number
        int year = int.Parse(Console.ReadLine()); //input for year
 
        string monthName = GetMonthName(month);
        int totalDays = GetDaysInMonth(month, year);

        // first day of the month (1st date)
        int firstDay = GetFirstDay(1, month, year);

        Console.WriteLine(monthName + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        // first loop for indentation
        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("    ");
        }

        // second loop to print days
        for (int day = 1; day <= totalDays; day++)
        {
            Console.Write(String.Format("{0,3} ", day));

            // move to next line after Saturday
            if ((day + firstDay) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }
}
