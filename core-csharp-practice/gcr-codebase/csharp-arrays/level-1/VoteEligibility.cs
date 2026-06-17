using System;
class VoteEligibility{
    static void Main()
    {
        int[] studentAge = new int[10];
        for(int i = 0;i<studentAge.Length;i++)
        {
            studentAge[i] = int.Parse(Console.ReadLine());

            if(studentAge[i]>=0) //checking for valid age.
            {
                if(studentAge[i]>=18) //checking if student is eligible to vote or not
                {
                    Console.WriteLine($"The student with the age {studentAge[i]} can vote");
                }
                else{
                    Console.WriteLine($"The student with the age {studentAge[i]} can not  vote");
                }
            }
            else{
                Console.WriteLine($"An Invalid age"); //for invalid age
            }
        }
    }

}
