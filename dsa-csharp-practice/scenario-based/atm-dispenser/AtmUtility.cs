using System;
using System.Collections.Generic;

class AtmUtility
{
    public void NoteCombinationForA()
    {
        int amount=880;
        int[] notes={500,200,100,50,20,10,5,2,1};
        Dictionary<int,int> noteCount=GetNoteCounts(notes);
        List<int> result=new List<int>();
        Console.WriteLine($"amount: {amount}");
        int remaining=amount;
        for(int i=0;i<notes.Length;i++)
        {
            int available=noteCount[notes[i]];
            while(remaining>=notes[i] && available>0)
            {
                result.Add(notes[i]);
                remaining-=notes[i];
                available--;
            }
        }
        Console.WriteLine("note combination:-");
        PrintNotes(result);
        Console.WriteLine("");

        }

    public void NoteCombinationForB()
    {
        int amount=880;
        int[] notes={200,100,50,20,10,5,2,1};
        Dictionary<int,int> noteCount=GetNoteCounts(notes);
        List<int> result=new List<int>();
        Console.WriteLine($"amount: {amount}");
        int remaining=amount;
        for(int i=0;i<notes.Length;i++)
        {
            int available=noteCount[notes[i]];
            while(remaining>=notes[i] && available>0)
            {
                result.Add(notes[i]);
                remaining-=notes[i];
                available--;
            }
        }
        Console.WriteLine("notes combination:-");
        PrintNotes(result);
        Console.WriteLine("");

    }
    public void NoteCombinationForC()
    {
        Console.Write("enter amount you want:-");
        int amount=int.Parse(Console.ReadLine());
        int[] notes={1,2,5,10,20,50,100,200,500};
        Dictionary<int,int> noteCount=GetNoteCounts(notes);
        List<int> result=new List<int>();
        int remaining=amount;

        for(int i=notes.Length-1;i>=0;i--)
        {
            int available=noteCount[notes[i]];
            while(remaining>=notes[i] && available>0)
            {
                result.Add(notes[i]);
                remaining-=notes[i];
                available--;
            }
        }

        if(remaining==0)
        {
            Console.WriteLine($"note combination for {amount}rs is:-");
            PrintNotes(result);
        }
        else
        {
            Console.WriteLine("cannot dispense exact change for amount "+amount);
            Console.WriteLine("closest possible: "+(amount-remaining));
            if(result.Count>0)
            {
                PrintNotes(result);
            }
        }
        Console.WriteLine("");

    }

    private void PrintNotes(List<int> notes)
    {
        int count500=0,count200=0,count100=0,count50=0,count20=0,count10=0,count5=0,count2=0,count1=0;
        for(int i=0;i<notes.Count;i++)
        {
            if(notes[i]==500)
            {
                count500++;
            }
            else if(notes[i]==200)
            {
                count200++;
            }
            else if(notes[i]==100)
            {
                count100++;
            }
            else if(notes[i]==50)
            {
                count50++;
            }
            else if(notes[i]==20)
            {
                count20++;
            }
            else if(notes[i]==10)
            {
                count10++;
            }
            else if(notes[i]==5)
            {
                count5++;
            }
            else if(notes[i]==2)
            {
                count2++;
            }
            else if(notes[i]==1)
            {
                count1++;
            }

        }

        if(count500>0)
        {
            Console.WriteLine("500 x "+count500);
        }
        if(count200>0)
        {
            Console.WriteLine("200 x "+count200);
        }
        if(count100>0)
        {
            Console.WriteLine("100 x "+count100);
        }
        if(count50>0)
        {
            Console.WriteLine("50 x "+count50);
        }
        if(count20>0)
        {
            Console.WriteLine("20 x "+count20);
        }
        if(count10>0)
        {
            Console.WriteLine("10 x "+count10);
        }
        if(count5>0)
        {
            Console.WriteLine("5 x "+count5);
        }
        if(count2>0)
        {
            Console.WriteLine("2 x "+count2);
        }
        if(count1>0)
        {
            Console.WriteLine("1 x "+count1);
        }
        int total=count500+count200+count100+count50+count20+count10+count5+count2+count1;
        Console.WriteLine($"total number of notes:-{total}");
    }

    private Dictionary<int,int> GetNoteCounts(int[] notes)
    {
        Dictionary<int,int> map=new Dictionary<int,int>();
        for(int i=0;i<notes.Length;i++)
        {
            Console.Write("enter number of "+notes[i]+" notes: ");
            map[notes[i]]=int.Parse(Console.ReadLine());
        }
        return map;
    }

}
