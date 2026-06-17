using System;
class MeanOfHeight{
    static void Main()
    {
        //initialising heights array with size 11 and sum variable with the value 0.
        double[] heights = new double[11];
        int sum = 0;
        //taking sum of all heights
        for(int i = 0;i<heights.Length;i++)
        {
            heights[i]=double.Parse(Console.ReadLine());
            sum+=heights[i];
        }
        //calculating and printing the mean.
        double meanOfHeights = sum/11;
        Console.WriteLine($"The mean of heights is : {meanOfHeights}");

    }
}