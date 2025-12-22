
using System;
class FahrenheitToCelsius{
    static void Main()
    {
        float fahrenheit = float.Parse(Console.ReadLine()); //Taking the fahrenheit value as input
        float celsius = (fahrenheit - 32f)*5f/9;//Converting the fahrenheit value in Celsius.
        Console.WriteLine($"The {fahrenheit} fahrenheit is {celsius} celsius"); //Printing results.
    }
}