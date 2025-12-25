using System;
class LargestNumber{
    static void Main()
{
    //taking 3 numbers as input
    int number1 = int.Parse(Console.ReadLine());
    int number2 = int.Parse(Console.ReadLine());
    int number3 = int.Parse(Console.ReadLine());
    

    //checking and printing the results if number1 is largest or not.
    Console.WriteLine($"Is the first number the largest? {(number1 > number2 ) && (number1 > number3)}"); //if both conditions are true we will get true,if any one of the condition is false it'll result false.

    //checking and printing the results if number2 is largest or not.
    Console.WriteLine($"Is the Second number the largest? {(number2 > number1 ) && (number2 > number3)}"); //if both conditions are true we will get true,if any one of the condition is false it'll result false.

    //checking and printing the results if number3 is largest or not.
    Console.WriteLine($"Is the third number the largest? {(number3 > number2 ) && (number3 > number1)}"); //if both conditions are true we will get true,if any one of the condition is false it'll result false.
    }
}
     