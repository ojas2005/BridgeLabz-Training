using System;
class Trigonometry{
    public static double[] calculateTrigonometricFunctions(double angle)
    {
        //calculating using math functions
        double[] result = new double[3];
        double radians = angle*Math.PI/180;
        result[0] = Math.Sin(radians);
        result[1] = Math.Cos(radians);
        result[2] = Math.Tan(radians);
        return result;

    }

    static void Main()
    {
        //taking angle and printing results
        double angle = double.Parse(Console.ReadLine());
        double[] result = calculateTrigonometricFunctions(angle);
        Console.WriteLine($"Sin value of angle {angle} is {result[0]}");
        Console.WriteLine($"Cos value of angle {angle} is {result[1]}");
        Console.WriteLine($"Tan value of angle {angle} is {result[2]}");
    }
}