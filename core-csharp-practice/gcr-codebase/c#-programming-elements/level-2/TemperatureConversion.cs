using System;
class TemperatureConversion{
    static void Main()
    {
        float celsius = float.Parse(Console.ReadLine()); //Taking the celsius value as input
        float fahr = (celsius * 1.8f)+32f; //Converting the celsius value in fahrenheit.
        Console.WriteLine($"The {celsius} Celsius is {fahr} Fahrenheit"); //Printing results.
    }
}