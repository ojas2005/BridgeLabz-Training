using System;

class Collinear
{
    // method to check collinearity using slope formula
    public static bool IsCollinearUsingSlope(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);

        return (slopeAB == slopeBC) && (slopeBC == slopeAC);
    }

    // method to check collinearity using area of triangle
    public static bool IsCollinearUsingArea(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        double area = 0.5 * (
            x1 * (y2 - y3) +
            x2 * (y3 - y1) +
            x3 * (y1 - y2)
        );

        return area == 0;
    }

    static void Main()
    {
        // sample input as given in question
        double x1 = 2, y1 = 4;
        double x2 = 4, y2 = 6;
        double x3 = 6, y3 = 8;

        Console.WriteLine("Points:");
        Console.WriteLine("A (" + x1 + ", " + y1 + ")");
        Console.WriteLine("B (" + x2 + ", " + y2 + ")");
        Console.WriteLine("C (" + x3 + ", " + y3 + ")");

        bool slopeResult = IsCollinearUsingSlope(x1, y1, x2, y2, x3, y3);
        bool areaResult = IsCollinearUsingArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine("\nUsing Slope Method: " + slopeResult);
        Console.WriteLine("Using Area Method: " + areaResult);

        if (slopeResult && areaResult)
        {
            Console.WriteLine("\nThe given points are Collinear.");
        }
        else
        {
            Console.WriteLine("\nThe given points are NOT Collinear.");
        }
    }
}
