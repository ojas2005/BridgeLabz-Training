using System;
class TemperatureAnalyzer{

    static float[] AverageTemperature(float[,] temp)
    { 
    
        float[] dailyAvg = new float[7]; //to store daily average temperature 

        //Calculating Daily Average for 7 days.
        for(int i =0;i<7;i++)
        {
            float total = 0;
            for(int j = 0;j<24;j++)
            {
                
                total+=temp[i,j]; //adding per hour temperature to total daily temperature.
            }
            dailyAvg[i] = total/24f; //calculating average.
            
            Console.WriteLine($"The average temperature of day {i+1} is {dailyAvg[i]}"); //Printing the result.
            
            
        }
        return dailyAvg; //returning the daily average array so that we can use it somewhere else.
    }

    static void HottestAndColdestDay(float[] dailyAvg){
        int cold = 0; //taking day 1 is the coldest
        int hot = 0; //taking day1 as hottest
        for(int i = 1;i<7;i++)
        {
            if(dailyAvg[i]>dailyAvg[hot]) //comparing
            {
                hot =i; //if day[i] is hotter than hot day then assigning i value to hot.
            }
            if(dailyAvg[i]<dailyAvg[cold]){
                cold=i; //if day[i] is colder than cold day then assigning value of i to coldest
            }
            
        }
        hot = hot+1; //not day 0 ,its day 1
        cold=cold+1;

        //printing the results.
        Console.WriteLine($"Hottest day is day {hot}"); 
        Console.WriteLine($"coldest day is day {cold}");

    }
    static void Main()
    {
        //inititalising and taking values for temperature in a 2d array.
        float[,] temp = new float[7,24];
        Console.WriteLine("Enter the temperature per hour for 24 hours for 7 days");
        for(int i =0;i<7;i++)
        {
            for(int j=0;j<24;j++)
            {
                temp[i,j] = float.Parse(Console.ReadLine());
            }
        }
        //calling the methods.
        float[] dailyAvg = AverageTemperature(temp);
        HottestAndColdestDay(dailyAvg); 
        }
}
