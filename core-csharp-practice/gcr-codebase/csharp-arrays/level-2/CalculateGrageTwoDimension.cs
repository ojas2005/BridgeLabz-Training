using System;
class CalulateGradeTwoDimension
{
    static void Main()
    {
        //taking marks of physics chemistry maths as input.
        int numberOfStudents = int.Parse(Console.ReadLine());
        int[,] marks = new int[numberOfStudents,3];
        


        //calculating average.
        float[] average = new float[numberOfStudents];
        //calculating grade and giving remarks.
        for(int i = 0;i<numberOfStudents;i++)
        {
            marks[i,0] = int.Parse(Console.ReadLine()); //marks physics
            marks[i,1] = int.Parse(Console.ReadLine()); //marks chemistry
            marks[i,2] = int.Parse(Console.ReadLine()); //marks maths
            average[i]=(marks[i,1]+marks[i,2]+marks[i,0])/3f;

            if(average[i]>=80)
            {
                Console.WriteLine($"The student got {average[i]} marks to secure 'A' grade. Student is at Level 4,above agency-normalized standards.");
            }
            else if(average[i]<80 && average[i] >=70)
            {
                Console.WriteLine($"The student got {average[i]} marks to secure 'B' grade. Student is at Level 3, at agency-normalized standards.");
            }
            else if(average[i] <70 && average[i] >=60)
            {
                Console.WriteLine($"The student got {average[i]} marks to secure 'C' grade. Student is at Level 2, below, but approaching agency-normalized standards.");
            }
            else if(average[i] <60 && average[i] >=50)
            {
                Console.WriteLine($"The student got {average[i]} marks to secure 'D' grade. Student is at Level 1, well below agency-normalized standards.");
            }
            else if(average[i] <50 && average[i] >=40)
            {
                Console.WriteLine($"The student got {average[i]} marks to secure 'E' grade. Student is at Level -1, too below agency-normalized standards.");
            }
            else{
                Console.WriteLine($"The student got {average[i]} marks to secure 'R' grade. Student is at remedial standards");
            }
        }
    } 
}