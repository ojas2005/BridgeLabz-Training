//2. Write an doubleOperation program by taking a, b, and c as input values and print the following integer operations: a + b * c, a * b + c, c + a / b, and a % b + c. Please also understand the precedence of the operators.
using System;
class IntOperation{
    static void Main()
    {
        //taking user inputs for a,b,c values.
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        //performing the operations.
        double sumMul = a + b * c;
        double mulSum =  a * b + c;
        double sumDiv =  c + a / b;
        double modSum = a % b + c;

        //printing the results.
        Console.WriteLine($"The results of double Operations are {sumMul}, {mulSum}, {sumDiv} and {modSum}");


    }
}
