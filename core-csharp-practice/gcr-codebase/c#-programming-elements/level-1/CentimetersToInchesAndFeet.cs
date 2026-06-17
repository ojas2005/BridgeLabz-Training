using System;
class CentimeterToInchesAndFeet{
    static void Main()
    {
        float height = float.Parse(Console.ReadLine()); //Taking height(cm) as input
        double HeightInInches = height*0.393701; //Converting height in inches
        double HeightInFeet = height*0.0328084; //Converting height in feet.
        Console.WriteLine($"Your Height in cm is {height} while in feet is {HeightInFeet} and inches is {HeightInInches}");
    }
}