using System;
class EvenSum{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for(int i = 0;i<=n;i++)

        {
            if(i%2==0)
            {
                sum = sum+i;
            }
        }
        Console.WriteLine(sum);
    }
}