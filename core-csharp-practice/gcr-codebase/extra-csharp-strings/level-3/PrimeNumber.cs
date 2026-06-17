using System;

class PrimeNumber{
    static bool PrimeOrNot(int number)
    {
        bool flag = true;

        //checking if number is divisible by any number between 2 to number/2
        for(int i = 2;i<=number/2;i++)
        {
            //if the number is divisible then it cant be prime number
            if(number%i==0)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
    static void Main()
    {
        //taking number as input and taking a flag as true.
        int number = int.Parse(Console.ReadLine());
        bool flag = PrimeOrNot(number);
        
        //1 and below 1 are not considered as prime number.
        if(number<=1){
        Console.WriteLine($"number {number} is not a prime number");
        }

        //if flag is true that means our number is not divisible by any number between 2 to n/2
        else if(flag==true){
        Console.WriteLine($"number {number} is a prime number");
        }
        //print number is not prime.
        else{
            Console.WriteLine($"number {number} is not a prime number");
        }
    }

}