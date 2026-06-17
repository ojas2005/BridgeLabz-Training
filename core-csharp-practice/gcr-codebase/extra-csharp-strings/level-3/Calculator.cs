using System;

class Calculator
{
    static double Add(double x,double y)
    {
        return x+y;
    }

    static double Subtract(double x,double y)
    {
        return x-y;
    }

    static double Multiply(double x,double y)
    {
        return x*y;
    }

    static double Divide(double x,double y)
    {
        return x/y;
    }
    static void Main()
    {
        double a=10;
        double b=5;
        Console.WriteLine(Add(a,b));
        Console.WriteLine(Subtract(a,b));
        Console.WriteLine(Multiply(a,b));
        Console.WriteLine(Divide(a,b));
    }


}
