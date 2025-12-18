using System;
class CalculateSimpleInterest{
    static void Main()
    {
        int principal = int.Parse(Console.ReadLine()); //Taking principal amount as input
        float rate = float.Parse(Console.ReadLine()); //Taking Rate of interest as input
        int time = int.Parse(Console.ReadLine()); //Taking Time as input
        float SI = (principal * rate * time)/100.0f; //Calculating The Simple Interest.
        Console.WriteLine(SI); //Printing results.
    }
}