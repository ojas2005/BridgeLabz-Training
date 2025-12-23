using System;
class FizzBuzz{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());

        //looping from 0 to number
        for(int i = 0;i<=number;i++)
        {
            //checking if the number is divisible by 3 but not 5
            if(i%3==0 && i%5!=0)
            {
                Console.WriteLine("Fizz");
            }

            //checking if the number is divisible by 5 but not 3
            else if(i%5==0 && i%3!=0)
            {
                Console.WriteLine("Buzz");
            }
            //checking if the number is divisible by both 3 and 5
            else if(i%5==0 && i%3==0){
                Console.WriteLine("FizzBuzz");
            } 

            //printing numbers that are not divisible by 3 and 5 both
            else{
                Console.WriteLine(i);
            }
        }
    }
}