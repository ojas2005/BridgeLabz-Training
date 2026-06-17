using System;

class StudentMarks
{
    // method to generate random PCM marks
    // returns 2D array: [student, 0]=Physics, [1]=Chemistry, [2]=Maths
    public static int[,] GeneratePCMMarks(int students)
    {
        int[,] marks = new int[students, 3];
        Random random = new Random();

        for (int i = 0; i < students; i++)
        {
            marks[i, 0] = random.Next(10, 100); // Physics
            marks[i, 1] = random.Next(10, 100); // Chemistry
            marks[i, 2] = random.Next(10, 100); // Maths
        }

        return marks;
    }

    // method to calculate total, average and percentage
    // returns 2D array: [student, 0]=Total, [1]=Average, [2]=Percentage
    public static double[,] CalculateResult(int[,] marks)
    {
        int students = marks.GetLength(0);
        double[,] result = new double[students, 3];

        for (int i = 0; i < students; i++)
        {
            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100;

            result[i, 0] = total;
            result[i, 1] = Math.Round(average, 2);
            result[i, 2] = Math.Round(percentage, 2);
        }

        return result;
    }

    // method to display scorecard
    public static void DisplayScoreCard(int[,] marks, double[,] result)
    {
        Console.WriteLine("\nStudent\tPhy\tChem\tMath\tTotal\tAverage\tPercentage");
        Console.WriteLine("------------------------------------------------------------");

        for (int i = 0; i < marks.GetLength(0); i++)
        {
            Console.WriteLine(
                (i + 1) + "\t" +
                marks[i, 0] + "\t" +
                marks[i, 1] + "\t" +
                marks[i, 2] + "\t" +
                result[i, 0] + "\t" +
                result[i, 1] + "\t" +
                result[i, 2]
            );
        }
    }

    static void Main()
    {
        Console.Write("Enter number of students: ");
        int students = int.Parse(Console.ReadLine());

        // generate marks
        int[,] pcmMarks = GeneratePCMMarks(students);

        // calculate result
        double[,] finalResult = CalculateResult(pcmMarks);

        // display scorecard
        DisplayScoreCard(pcmMarks, finalResult);
    }
}
