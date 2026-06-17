using System;
class CalulateGrade
{
    static void Main()
    {
        //initialising arrays
        int numberOfStudents = int.Parse(Console.ReadLine());
        int[] marksPhysics = new int[numberOfStudents];
        int[] marksChemistry = new int[numberOfStudents];
        int[] marksMaths = new int[numberOfStudents];
        float[] average = new float[numberOfStudents];
        for(int i = 0;i<numberOfStudents;i++)
        {
            //taking marks of physics chemistry maths as input.
            marksPhysics[i] = int.Parse(Console.ReadLine());
            marksChemistry[i] = int.Parse(Console.ReadLine());
            marksMaths[i] = int.Parse(Console.ReadLine());

            //calculating average.
            average[i]=(marksChemistry[i]+marksMaths[i]+marksPhysics[i])/3f;

            //calculating grade and giving remarks.
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