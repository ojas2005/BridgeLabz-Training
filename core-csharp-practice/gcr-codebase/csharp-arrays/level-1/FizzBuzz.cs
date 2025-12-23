using System;
class FizzBuzz
    {
        static void Main(String[] args)
        {
            //taking number as input from the user
            int number = int.Parse(Console.ReadLine());
            string[] fizzBuzz = new string[number];
            for(int i=1;i<=number; i++)
            {
            //checking if the number is divisible by 3 but not 5
            if(i%3==0 && i%5!=0)
            {
                fizzBuzz[i-1] = "Fizz";
            }

            //checking if the number is divisible by 5 but not 3
            else if(i%5==0 && i%3!=0)
            {
                fizzBuzz[i-1]="Buzz";
            }
            //checking if the number is divisible by both 3 and 5
            else if(i%5==0 && i%3==0){
                fizzBuzz[i-1]="FizzBuzz";
            } 

            //printing numbers that are not divisible by 3 and 5 both
            else{
                fizzBuzz[i-1]=i.ToString();
            }


        }
            for(int i = 0;i<number;i++)
            {
                Console.WriteLine($"Position {i+1} = {fizzBuzz[i]}");
            }

        }
    }
