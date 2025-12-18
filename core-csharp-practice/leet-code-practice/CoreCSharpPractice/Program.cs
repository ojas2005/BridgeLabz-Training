// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Enter a number:");
int n = int.Parse(Console.ReadLine()!);  // the ! avoids null warnings
int sum = 0;
for (int i = 0; i <= n; i++)
{
    if (i % 2 == 0) sum += i;
}
Console.WriteLine(sum);
