
using System;
class TemperatureConverter{
    static float FahrenheitToCelcius(float fahrenheit)
    {
        float celsius = (fahrenheit - 32f)*5f/9;//Converting the fahrenheit value in Celsius.

        Console.WriteLine($"The {fahrenheit} fahrenheit is {celsius} celsius"); //Printing results.
        return celsius;
    }

    static void CelsiusToFahrenheit(float celsius){
        float fahr = (celsius * 1.8f)+32f; //Converting the celsius value in fahrenheit.
        Console.WriteLine($"The {celsius} Celsius is {fahr} Fahrenheit"); //Printing results.
        }
    static void Main()
    {
        float fahrenheit = float.Parse(Console.ReadLine()); //Taking the fahrenheit value as input
        float celsius = FahrenheitToCelcius(fahrenheit);
        float newFahr = CelsiusToFahrenheit(celsius);
       
    }
}