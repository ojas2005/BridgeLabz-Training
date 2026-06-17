using System;
class CalculatePower{
    static void Main()
    {
        //taking number and power as input
        int number = int.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());
        int result = 1; //for power = 0. edge case
        for(int i = 1;i<=power;i++)
        {
            result*=number; //multiplying the number by result.After the first iteration,result will become number.
        }
        //printing result.
        Console.WriteLine(result);
    }
}