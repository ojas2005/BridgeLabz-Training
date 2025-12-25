using System;
class WindChill{
    static void Main()
    {
        int temperature = int.Parse(Console.ReadLine());
        int windSpeed = int.Parse(Console.ReadLine());
        double windChill = 35.74 + (0.6215*temp) + (0.4275*temp - 35.75) * (windSpeed*0.16);
        Console.WriteLine(windChill);
    }
}