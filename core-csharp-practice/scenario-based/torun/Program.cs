using System;
class ManageStudentScore{

    static void HighestAndLowestScores(float[] scores)
    {
        float highest = scores[0];
        float lowest = scores[0];
        for(int i = 0;i<scores.Length;i++)
        {
            if(scores[i]>highest)
            {
                highest = scores[i];
            }
            if(scores[i]<lowest)
            {
                lowest=scores[i];
            }
            
        }
        Console.WriteLine($"Lowest scores are {lowest}");
        Console.WriteLine($"Highest marks are {highest}");
    }
    static void Main()
    {
        Console.WriteLine("Enter number of students");
        int n = int.Parse(Console.ReadLine());

        float[] scores = new float[n];
        float sum = 0;
        float avg=0f;
        Console.WriteLine($"Enter scores of {n} students");
        for(int i = 0;i<n;i++)
        {
            float b = 0;
            try{
                string a = Console.ReadLine();
                 b = float.Parse(a);
            }
            catch(FormatException e){
                Console.WriteLine(e.GetType().Name);
                break;
            }
            if(b<0)
            {
                Console.WriteLine("Invalid input");
                break;
            }
            else{
            scores[i]=b;
            
            }
            sum+=scores[i];
        }
        avg = (1f*sum)/n; //calculating average scores of n students.
        Console.WriteLine($"Average scores of {n} students is {avg}");
        HighestAndLowestScores(scores);




    }
    }
