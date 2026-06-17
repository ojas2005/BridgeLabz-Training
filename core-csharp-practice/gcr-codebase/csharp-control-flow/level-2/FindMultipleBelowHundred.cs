using System;
class FindMultipleBelowHundred{
    static void Main()
    {
        //taking number as input
        int number = int.Parse(Console.ReadLine());

        //finding multiple of number lesser or equals to 100
        for(int i = 100;i>=1;i--)
        {
            if(i%number==0)
            {
                Console.WriteLine(i);
            }
        }
    }
}