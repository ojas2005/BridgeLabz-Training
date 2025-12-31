using System;
 class NumberGusser
    {
        static void Main(string[] args)
        {
            // taking the user input
            int user = int.Parse(Console.ReadLine());
            int low = 1;
            int high = 100;
            Random r = new Random();
            while (true)
            {
                //choosing the number
                int number = Guessing(low, high, r);
                Console.WriteLine(number);
                string guess = Console.ReadLine(); //user's guess
                // if guessed it correctly print correct 
                if (guess=="correct")
                {
                    break;
                }
                // if the guess is high write high or if less write low
                if (guess=="high")
                {
                    high = number - 1;
                }
                if (guess=="low")
                {
                    low = number + 1;
                }
            }
        }
        static int Guessing(int low,int high,Random r)
        {
            return r.Next(low,high+1);
        }
    }