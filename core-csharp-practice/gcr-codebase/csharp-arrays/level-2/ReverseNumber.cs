using System;
class ReverseNumber{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;
        //storing digits of numbers in digits array.
        while(number!=0)
        {
            digits[index] = number%10;
            number/=10;
            index++;
            if(index==maxDigit)
            {
                maxDigit+=10;
                int[] tempDigits = new int[maxDigit];
                for(int i = 0;i<digits.Length;i++)
                {
                    tempDigits[i] = digits[i];
                }
                digits=tempDigits;
            }

        }
        //printing in reverse order.
        for(int i = index;i>=0;i++)
        {
            Console.WriteLine($"{digits[i]}");
        }
    }
}