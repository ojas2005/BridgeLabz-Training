class CutSolver
{
    private int[] priceTable;
    private int[] decision;

    public CutSolver(int[] prices)
    {
        priceTable=prices;
        decision=new int[prices.Length+1];
    }
    public int calculate(int size)
    {
        int[] dp=new int[size+1];
        dp[0]=0;

        for(int i=1;i<=size;i++)
        {
            int best=-1;
            for(int j=1;j<=i;j++)
            {
                int temp=priceTable[j-1]+dp[i-j];
                if(temp>best)
                {
                    best=temp;
                    decision[i]=j;
                }
            }
            dp[i]=best;
        }
        return dp[size];
    }
    public void display(int size)
    {
        List<int> parts=new List<int>();
        int remaining=size;

        while(remaining>0)
        {
            int cut=decision[remaining];
            parts.Add(cut);
            remaining=remaining-cut;
        }

        for(int i=0;i<parts.Count;i++)
        {
            Console.Write(parts[i]);
            if(i<parts.Count-1)
            {
                Console.Write(",");
            }
        }
        Console.WriteLine();
    }
}