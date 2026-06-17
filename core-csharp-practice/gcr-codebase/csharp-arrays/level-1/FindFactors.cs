using System;
class FindFactors{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());
        int maxFactor = 10;
        int[] factor = new int[maxFactor];
        int index=0;


        //taking the value of i from number-1 to 1 so that it doesnt consider the number itself as factor.
        for(int i=number-1;i>=1;i--)
        {
            //if number is divisible from i then i is a facor of the number.
            if(number%i==0)
            {
                factor[index]=i;
                index++;
            }
        }
        //printing the factors.
        for(int i = 0;i<maxFactor;i++)
        {
            if(factor[i]==0)
            {
                break;
            }
            Console.WriteLine(factor[i]);
        }
    }
}