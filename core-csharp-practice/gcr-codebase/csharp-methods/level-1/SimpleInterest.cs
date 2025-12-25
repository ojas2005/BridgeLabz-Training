using System;
class SimpleInterest{
    public static float SimpleInterestCalculate(int principal,float rate,int time)
    {
        float SI = (principal * rate * time)/100.0f; //Calculating The Simple Interest.
        return SI; 
    }
    static void Main()
    {
        int principal = int.Parse(Console.ReadLine()); //Taking principal amount as input
        float rate = float.Parse(Console.ReadLine()); //Taking Rate of interest as input
        int time = int.Parse(Console.ReadLine()); //Taking Time as input
        float result = SimpleInterestCalculate(principal,rate,time);
        Console.WriteLine($"The Simple Interest is {result} for Principal {principal}, Rate of Interest {rate} and Time {time}");
    }
}