using System;
class LargestOfThree{
    public static int[] FindSmallestAndLargest(int number1, int number2, int number3){

        int[] result = new int[2];
        int largest = number1;
        int smallest=number1;
        if(number2>largest)
        {
            largest=number2;
        }
        if(number3>largest)
        {
            largest = number3;
        }
        if(number2<smallest)
        {
            smallest=number2;
        }
        if(number3<smallest)
        {
            smallest=number3;
        }
        result[0] = largest;
        result[1] = smallest;
        return result;
    }
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());
        
        int[] result = FindSmallestAndLargest(number1,number2,number3);
        Console.WriteLine($"Smallest Number is {result[1]}");
        Console.WriteLine($"Largest Number is {result[0]}");
    }

}
