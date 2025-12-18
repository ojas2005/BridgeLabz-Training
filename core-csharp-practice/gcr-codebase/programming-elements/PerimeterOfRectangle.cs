using System;
class PerimeterOfRectangle{
    static void Main()
    {
        int len = int.Parse(Console.ReadLine()); //Taking length as input
        int wid = int.Parse(Console.ReadLine()); //Taking width as input
        int per = 2*(len+wid); //calculating the perimeter
        Console.WriteLine(per); //printing the results.
    }
}