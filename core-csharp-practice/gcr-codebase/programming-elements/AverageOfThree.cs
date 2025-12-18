using System;
class AverageOfThree{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine()); //Taking 1st value as input
        int b = int.Parse(Console.ReadLine()); //Taking 2nd value as input
        int c = int.Parse(Console.ReadLine()); //Taking 3rd value as input
        float avg = (a+b+c)/3.0f; //Calculating the average
        Console.WriteLine(avg); //printing the average.
    }
}