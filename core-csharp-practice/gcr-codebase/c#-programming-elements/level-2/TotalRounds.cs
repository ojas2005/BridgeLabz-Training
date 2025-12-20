using System;
class TotalRounds{
    static void Main()
    {   //taking sides of triangle as input.
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int distance = 5000;

        //Calculating the parameter of the triangle.
        int parameter = a+b+c;

        //Calculating the number of rounds the athelete have to complete.
        float rounds = (distance*1f)/parameter;
        //Printing results.
        Console.WriteLine($"The total number of rounds the athlete will run is {rounds} to complete 5 km");

    
    }
}