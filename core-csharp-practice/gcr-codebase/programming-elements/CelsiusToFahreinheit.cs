using System;
class CelsiusToFahrenheit{
    static void Main()
    {
        float cels = float.Parse(Console.ReadLine()); //Taking the celsius value as input
        float fahr = (cels * 1.8f)+32f; //Converting the celsius value in fahrenheit.
        Console.WriteLine(fahr); //Printing results.
    }
}