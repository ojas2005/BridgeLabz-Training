using System;
class DayOfWeek{
    static void Main()
    {
        //taking month day and year as input
        int m  = int.Parse(Console.ReadLine());
        int d  = int.Parse(Console.ReadLine());
        int y  = int.Parse(Console.ReadLine());

        //calculating the day using formula
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0/4 - y0/100 + y0/400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + 31*m0 / 12) % 7;

        //printing the output based on the day we recieved.
        if(d0==0)
        {
        Console.WriteLine("Sunday");
        }
        else if(d0==1)
        {
        Console.WriteLine("Monday");
        }
        else if(d0==2)
        {
        Console.WriteLine("Tuesday");
        }
        else if(d0==3)
        {
        Console.WriteLine("Wednesday");
        }
        else if(d0==4)
        {
        Console.WriteLine("Thursday");
        }
        else if(d0==5)
        {
        Console.WriteLine("Friday");
        }
        else
        {
        Console.WriteLine("Saturday");
        }

    }
}