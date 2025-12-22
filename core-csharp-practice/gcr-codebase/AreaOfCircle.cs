using System;
class AreaOfCircle{
    static void Main()
    {
        float r = float.Parse(Console.ReadLine()); //takes radius as input
        float pi = 3.14f;
        float area = pi * r * r; //Calculation of area
        Console.WriteLine(area);
    }
}