using System;
class AreaOfCircle{
    static void Main()
    {
        float radius = float.Parse(Console.ReadLine()); //Taking Radius as input
        float pi = 3.14f;
        float area = pi * radius * radius; //Calculating area of circle.
        Console.WriteLine(area); //Printing results.
    }

}