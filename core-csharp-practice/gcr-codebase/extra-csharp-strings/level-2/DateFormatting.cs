using System;
class DateFormatting
{   
    static void Main()
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("dd/MM/yyyy        : " + dt.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd        : " + dt.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy : " + dt.ToString("ddd, MMM dd, yyyy"));
    }
}
