using System;
class OddEvenCheck{
    static void Main()
    {   
        //taking the number as input.
        int number = int.Parse(Console.ReadLine());

        //checking for natural numbers
        if(number>0)
        {
            //using for loop
            for(int i = 1;i<=number;i++)
            { //if i is divisble by 2 then its even else odd.
                if(i%2==0)
                {
                    Console.WriteLine($"Number {number} is even"); //printing result.
                }
                else{
                    Console.WriteLine($"Number {number} is odd");
                }
            }
        }
    }
}