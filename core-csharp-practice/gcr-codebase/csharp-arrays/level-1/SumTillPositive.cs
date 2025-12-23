using System;
class SumTillPositive
{
    static void Main()
    {
        //initialising the variables.
        double[] arr = new double[10];
        double total = 0.0;
        int index = 0;

        //taking infinnite loop that'll break if input is 0,negative or index =10.
        while(true)
        {
            int number = int.Parse(Console.ReadLine());
            if(number<=0)
            {
                break;
            }
            if(index==10)
            {
                break;
            }
            arr[index] = number;
            index++;
        }

        //adding the numbers
        for(int i = 0;i<index;i++)
        {
            total+=arr[i];
        }

        //printing results.
        Console.WriteLine($"The total sum is {total}");
    }
}