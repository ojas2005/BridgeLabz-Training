using System;
class MaxOfThree{
    public static int[] Largest(int number1, int number2, int number3){

        int[] result = new int[2];
        int largest = number1;
        if(number2>largest)
        {
            largest=number2;
        }
        if(number3>largest)
        {
            largest = number3;
        }
        return result;
    }
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());
        
        int[] result = Largest(number1,number2,number3);
        Console.WriteLine($"Largest Number is {result[0]}");
    }

}
