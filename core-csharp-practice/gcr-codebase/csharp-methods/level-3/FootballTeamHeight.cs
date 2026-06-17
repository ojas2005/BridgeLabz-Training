using System;

class FootballTeamHeight
{
    // method to find sum of all heights
    static int FindSum(int[] heights)
    {
        int sum = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            sum += heights[i];
        }
        return sum;
    }

    // method to find mean height
    static double FindMean(int[] heights)
    {
        int sum = FindSum(heights);
        double mean = (double)sum / heights.Length;
        return mean;
    }

    // method to find shortest height
    static int FindShortest(int[] heights)
    {
        int min = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] < min)
            {
                min = heights[i];
            }
        }
        return min;
    }

    // method to find tallest height
    static int FindTallest(int[] heights)
    {
        int max = heights[0];
        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > max)
            {
                max = heights[i];
            }
        }
        return max;
    }

    static void Main()
    {
        // array to store heights of 11 players
        int[] heights = new int[11];
        Random random = new Random();

        // generating random heights between 150 and 250
        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = random.Next(150, 251);
        }

        // displaying heights
        Console.WriteLine("Heights of football players (in cm):");
        for (int i = 0; i < heights.Length; i++)
        {
            Console.WriteLine("Player " + (i + 1) + ": " + heights[i]);
        }

        // calling methods
        int sum = FindSum(heights);
        double mean = FindMean(heights);
        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);

        // final output
        Console.WriteLine("\nResults:");
        Console.WriteLine("Sum of heights: " + sum);
        Console.WriteLine("Mean height: " + mean);
        Console.WriteLine("Shortest height: " + shortest);
        Console.WriteLine("Tallest height: " + tallest);
    }
}
