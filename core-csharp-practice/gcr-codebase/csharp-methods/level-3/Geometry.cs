using System;

class Geometry
{
    // method to find Euclidean distance between two points
    public static double FindDistance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;

        double distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        return distance;
    }

    // method to find slope and y-intercept
    // returns array where index 0 = slope (m), index 1 = intercept (b)
    public static double[] FindLineEquation(double x1, double y1, double x2, double y2)
    {
        double[] result = new double[2];

        double m = (y2 - y1) / (x2 - x1);   // slope
        double b = y1 - (m * x1);          // y-intercept

        result[0] = m;
        result[1] = b;

        return result;
    }

    static void Main()
    {
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double distance = FindDistance(x1, y1, x2, y2);
        double[] line = FindLineEquation(x1, y1, x2, y2);

        Console.WriteLine("\nResults:");
        Console.WriteLine("Euclidean Distance: " + distance);
        Console.WriteLine("Slope (m): " + line[0]);
        Console.WriteLine("Y-Intercept (b): " + line[1]);

        Console.WriteLine("\nEquation of Line:");
        Console.WriteLine("y = " + line[0] + "x + " + line[1]);
    }
}
