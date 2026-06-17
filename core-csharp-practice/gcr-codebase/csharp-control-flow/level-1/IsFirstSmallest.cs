using System;
class IsFirstSmallest{
    static void Main()
{
    //taking 3 numbers as input
    int number1 = int.Parse(Console.ReadLine());
    int number2 = int.Parse(Console.ReadLine());
    int number3 = int.Parse(Console.ReadLine());

    //checking and printing the results if number1 is smallest. true or false
    Console.WriteLine($"Is the first number the smallest? {(number1 < number2 ) && (number1 < number3)}"); //if both conditions are true we will get true,if any one of the condition is false it'll result false.

}
}
