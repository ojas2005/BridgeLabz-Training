using System;
class CounterUsingWhile{
    static void Main()
    {
        //taking the counter value as input.
        int counter = int.Parse(Console.ReadLine());

        //creating counter using while loop
        while(counter>=1) //it will run till counter is greater than 1.
        {
            Console.WriteLine($"{counter}");
            counter--;
        }
        
    }
}