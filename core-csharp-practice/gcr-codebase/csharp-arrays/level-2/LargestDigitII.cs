using System;
class LargestDigitII{
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
            if(index==maxDigit) //if index reaches maxDigits we increase maxDigits by 10
            {
                maxDigit+=10; //increase by 10
                int[] tempDigits = new int[maxDigit]; //new temporary array
                for(int i = 0;i<digits.Length;i++) //taking values of digits in this new temp array
                {
                    tempDigits[i] = digits[i];
                }
                digits=tempDigits; //resetting the array
            }
        }
        //setting largest and second largest elements as -1.
        int largestElement = -1;
        int secondLargestElement = -1;
        for(int i = 0;i<index;i++)
        {
            //if that digit is larger than largest element we will set largets to that digit.
            if(largestElement<digits[i])
            {
                secondLargestElement = largestElement;
                largestElement = digits[i];
            }
            else if(secondLargestElement<digits[i] && digits[i]!=largestElement)
            {
                secondLargestElement = digits[i];
            }
        }
        //printing results.
        Console.WriteLine($"Largest digit of number {number} is {largestElement}");

        if(secondLargestElement!= -1)
        {
        Console.WriteLine($"Second Largest digit of number {number} is {secondLargestElement}");
        }
        else{
            Console.WriteLine("There is no second element");
        }
    }
}