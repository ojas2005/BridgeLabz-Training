using System;
class AreaOfTriangle{
    static void Main()
    {
        int baseval = int.Parse(Console.ReadLine()); //Taking base as input
        int height = int.Parse(Console.ReadLine()); //Taking height as input
        double area = 0.5*baseVal*height; //calculating the area
        double areaInSquareInches = area*0.393701; //Converting Area(in cm square to square inch)
        double areaInSquareFeet = area*0.0328084; //Converting Area(in cm square to square feet)
        Console.WriteLine($"Height in cm is {height} while area in squarefeet is {areaInSquareFeet} and area in squareinches is {areaInSquareInches}");
    }
}