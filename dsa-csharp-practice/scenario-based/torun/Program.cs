using System;

class CustomFurniture
{
    static void Main()
    {
        int size=12;
        int[] prices={0,2,4,5,20,8,12,17,23,30,40,54,56};

        //scenario A
        int[] normalRevenue=MaxRevenue(prices,size);
        Console.WriteLine($"for {size}ft rod maximum revenue is {normalRevenue[size]}");
        Console.WriteLine();

        //scenario B
        int wasteLimit=1;
        int revenueWaste=BestWithWaste(prices,size,wasteLimit);
        Console.WriteLine($"with waste limit of {wasteLimit}ft,maximum revenue is {revenueWaste}");
        Console.WriteLine();

        //scenario C
        int[] result=MaxRevenueWithWaste(prices,size);
        Console.WriteLine($"best revenue is {result[0]}");
        Console.WriteLine($"minimum waste is{result[1]}ft");
    }

    //for scenario A
    static int[] MaxRevenue(int[] prices,int length)
    {
        int[] revenue=new int[length+1];

        for(int i=1;i<=length;i++)
        {
            int maxVal=0;

            for(int j=1;j<=i;j++)
            {
                int candidate=prices[j]+revenue[i-j];
                if(candidate>maxVal)
                {
                    maxVal=candidate;
                }
            }
            revenue[i]=maxVal;
        }
        return revenue;
    }

    //scenario B
    static int BestWithWaste(int[] prices,int rodLength,int maxWaste)
    {
        int best=0;
        for(int usable=rodLength;usable>=rodLength-maxWaste;usable--)
        {
            int[] revenue=MaxRevenue(prices,usable);
            if(revenue[usable]>best)
            {
                best=revenue[usable];
            }
        }
        return best;
    }

    //scenario C
    static int[] MaxRevenueWithWaste(int[] prices,int rodLength)
    {
        int bestRevenue=0;
        int minWaste=rodLength;

        for(int usable=1;usable<=rodLength;usable++)
        {
            int[] dp=new int[usable+1];

            for(int len=1;len<=usable;len++)
            {
                int maxValue=0;

                for(int cut=1;cut<=len;cut++)
                {
                    int current=prices[cut]+dp[len-cut];
                    if(current>maxValue)
                    {
                        maxValue=current;
                    }
                }
                dp[len]=maxValue;
            }

            int waste=rodLength-usable;

            if(dp[usable]>bestRevenue||(dp[usable]==bestRevenue&&waste<minWaste))
            {
                bestRevenue=dp[usable];
                minWaste=waste;
            }
        }
        int[] result=new int[2];
        result[0]=bestRevenue;
        result[1]=minWaste;
        return result;
    }
}
