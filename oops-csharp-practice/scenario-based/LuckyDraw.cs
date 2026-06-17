using System;

class LuckyDraw
{
    static void Main()
    {
        int visitor = 1;
        while (true)
        {
            Console.WriteLine($"\nVisitor number {visitor},Do you want to draw a number? Press 1 for yes and 2 for no");
            int choice = int.Parse(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                    Random r = new Random();
                    int number = r.Next(100);
                    visitor++;
                    if (number<=0)
                    {
                        Console.WriteLine("please enter a valid input");
                        
                        continue;
                    }
                    if(number%15==0)
                    {
                        Console.WriteLine($"you got number {number} in your draw and you won a prize");
                    }
                    else
                    {
                        Console.WriteLine($"you got number {number} in your draw and sadly you could not win a prize");
                    }
                    continue;
                case 2:
                    
                    Console.WriteLine($"Visitor number {visitor} doesn't want to make a draw so we will move to the next visitor");
                    visitor++;
                    break;
                default:
                    Console.WriteLine("please enter a valid input");
                    continue;
                
                

            }
        }
    }
}
