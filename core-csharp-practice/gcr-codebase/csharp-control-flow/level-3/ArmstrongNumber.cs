using System;
class ArmstrongNumber{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int originalNumber = number;

        //calculating sum of the cube of the digits of the number
        while(originalNumber!=0)
        {
            int remainder = originalNumber%10;
            int cube = remainder*remainder*remainder;
            sum+=cube;
            originalNumber = originalNumber/10;

        }

        //now verifying if sum is equals to number.If yes then its an armstrong number.
        if(sum==number)
        {
            Console.WriteLine($"Number {number} is an Armstrong Number");
        }
        else{
            Console.WriteLine("Number is not armstrong number");
        }
    }
}