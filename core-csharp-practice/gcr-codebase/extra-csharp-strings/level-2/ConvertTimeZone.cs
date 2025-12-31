using System;

class TimeZonesDemo
{
    static void Main()
    {
        
        DateTimeOffset timeInUTC = DateTimeOffset.UtcNow;
        TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        DateTimeOffset timeInGMT = TimeZoneInfo.ConvertTime(timeInUTC, gmtZone);
        DateTimeOffset timeInIST = TimeZoneInfo.ConvertTime(timeInUTC, istZone);
        DateTimeOffset timeInPST = TimeZoneInfo.ConvertTime(timeInUTC, pstZone);

        Console.WriteLine($"Time in GMT is {timeInGMT}");
        Console.WriteLine($"Time in IST is {timeInIST}");
        Console.WriteLine($"Time in PST is {timeInPST}");
    }
}
