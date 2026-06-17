using System;
class DivisibleByFive{
    static void Main()
{
    //taking the number as input.
    int number = int.Parse(Console.ReadLine());
    //checking if number is divisble by 5 or not.
    Console.WriteLine($"Is the number {number} divisible by 5? {number%5==0}");
}
}