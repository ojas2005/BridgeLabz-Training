using System;
class LargestDigit{
    static void Main()
    { 
        //taking number input.
        int number = int.Parse(Console.ReadLine());
        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;
        int original = number;
        //storing digits of numbers in digits array.
        while(number!=0)
        {
            digits[index] = number%10;
            number/=10;
            index++;
            if(index==10)
            {
                break;
            }
        }
        //setting largest and second largest elements as 0.
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

        Console.WriteLine($"Largest digit of number {original} is {largestElement}");
        if(secondLargestElement!=-1){
        Console.WriteLine($"Second Largest digit of number {original} is {secondLargestElement}");
        }
        else{
            Console.WriteLine("There is no second digit");
        }
    }
}