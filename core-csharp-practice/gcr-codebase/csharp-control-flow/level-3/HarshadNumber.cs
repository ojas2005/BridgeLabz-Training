using System;
class HarhsadNumber{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        int originalNumber = number;
        //dividing the number by 10 repeatedly to get 1 digit out each time and adding that digit to sum.
        while(originalNumber!=0)
        {
            sum+=originalNumber%10;
            originalNumber/=10;
        }
        //checking if number is divisible by sum or not,if yes then its a harshad number.
        if(number%sum==0)
        {
            Console.WriteLine("Harshad Number");
        }
        else{
            Console.WriteLine("Not a Harshad Number");
        }
    }
}