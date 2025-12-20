//2. Write an IntOperation program by taking a, b, and c as input values and print the following integer operations: a + b * c, a * b + c, c + a / b, and a % b + c. Please also understand the precedence of the operators.
using System;
class IntOperation{
    static void Main()
    {
        //taking user inputs for a,b,c values.
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        //performing the operations.
        int sumMul = a + b * c;
        int mulSum =  a * b + c;
        float sumDiv =  c + (a*1f) / b;
        int modSum = a % b + c;
        Console.WriteLine($"The results of Int Operations are {sumMul}, {mulSum}, {sumDiv} and {modSum}");


    }
}
