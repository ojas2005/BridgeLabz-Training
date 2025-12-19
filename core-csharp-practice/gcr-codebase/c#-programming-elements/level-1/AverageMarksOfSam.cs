using System;
class AverageMarksOfSam{
    static void Main()
    { 
        //taking marks of all three subjects.
        int marksInMath = 94;
        int marksInPhysics = 95;
        int marksInChemistry = 96;
        //taking number of subjects.
        int numberOfSubjects = 3;
        //calculating the average.
        float average = (marksInMath+marksInPhysics+marksInChemistry)/numberOfSubjects;

        //printing the average.
        Console.WriteLine($"Sam’s average mark in PCM is {average}");
    }
}