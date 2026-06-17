using Newtonsoft.Json;
using System;

class Car
{
    public string Brand;
    public int Year;
}

class Program
{
    static void Main()
    {
        Car c = new Car { Brand = "BMW", Year = 2022 };
        string json = JsonConvert.SerializeObject(c);
        Console.WriteLine(json);
    }
}
