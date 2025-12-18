using System;
class PowerCalculation{
    static void Main()
    {
        int basee = int.Parse(Console.ReadLine()); //Taking base as input
        int exp = int.Parse(Console.ReadLine()); //Taking exponent as input
        double power = Math.Pow(basee,exp); //Calculating the results.
        Console.WriteLine(power);
    }
}