using System;
class PerimeterOfSquare{
    static void Main()
    {
        float parameter = float.Parse(Console.ReadLine()); //taking parameter of square as an input from the user.
        float side = parameter/4f; //calculating the value of sides
        Console.WriteLine($"the length of the side is {side} whose perimeter is {parameter}");

    }
}