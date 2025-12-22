using System;
class CounterUsingFor{
    static void Main()
    {
        //taking the counter value as input.
        int counter = int.Parse(Console.ReadLine());

        //creating counter using for loop.
        for(int i = counter;i>0;i--)
        {
            Console.WriteLine($"{counter}");
        }
        
    }
}