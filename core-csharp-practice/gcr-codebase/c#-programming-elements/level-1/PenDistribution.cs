using System;
class PenDistribution{
    static void Main()
    {
        //taing number of pens and number of students as input.
        int numberOfPens = 14;
        int numberOfStudents = 3;

        //Calculating numbers of pens which will be remaining after distributing pens equally.
        int remainingAfterDistribution = numberOfPens%numberOfStudents;

        //calculating how many pens each student will get.
        int penPerStudent = (numberOfPens-remainingAfterDistribution)/numberOfStudents;
        Console.WriteLine($"The Pen Per Student is {penPerStudent} and the remaining pen not distributed is {remainingAfterDistribution}");
    }
}