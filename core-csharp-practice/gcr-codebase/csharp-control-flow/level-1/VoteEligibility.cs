using System;
class VoteEligibility{
    static void Main()
    {
        //taking age as input
        int age = int.Parse(Console.ReadLine());

        //checking if age is greater than 18 or not.
        if(age>=18)
        {
            //if age is above 18 candidate is eligible to vote.
            Console.WriteLine($"The person's age is {age} and can vote.");
        }
        else{
            //if age is not above 18 candidate is not eligible to vote.
            Console.WriteLine($"The person's age is {age} and can not vote.");
        }
    }
}