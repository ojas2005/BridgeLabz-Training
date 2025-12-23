using System;
class CalulateGrade
{
    static void Main()
    {
        //taking marks of physics chemistry maths as input.
        int marksPhysics = int.Parse(Console.ReadLine());
        int marksChemistry = int.Parse(Console.ReadLine());
        int marksMaths = int.Parse(Console.ReadLine());

        //calculating average.
        float average = (marksChemistry+marksMaths+marksPhysics)/3f;

        //calculating grade and giving remarks.
        
        if(average>=80)
        {
            Console.WriteLine($"The student got {average} marks to secure 'A' grade. Student is at Level 4,above agency-normalized standards.");
        }
        else if(average<80 && average>=70)
        {
            Console.WriteLine($"The student got {average} marks to secure 'B' grade. Student is at Level 3, at agency-normalized standards.");
        }
        else if(average<70 && average>=60)
        {
            Console.WriteLine($"The student got {average} marks to secure 'C' grade. Student is at Level 2, below, but approaching agency-normalized standards.");
        }
        else if(average<60 && average>=50)
        {
            Console.WriteLine($"The student got {average} marks to secure 'D' grade. Student is at Level 1, well below agency-normalized standards.");
        }
        else if(average<50 && average>=40)
        {
            Console.WriteLine($"The student got {average} marks to secure 'E' grade. Student is at Level -1, too below agency-normalized standards.");
        }
        else{
            Console.WriteLine($"The student got {average} marks to secure 'R' grade. Student is at remedial standards");
        }
    }
} 