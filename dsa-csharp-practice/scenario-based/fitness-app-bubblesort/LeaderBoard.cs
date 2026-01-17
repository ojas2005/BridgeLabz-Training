using System;
public class LeaderBoard
{
    private IUser[] users;
    private int count;
    private int size=20;
    public LeaderBoard()
    {
        users=new IUser[size];
        count=0;
    }
    public void AddUser(IUser u)
    {
        if(count<size)
        {
            users[count]=u;
            count=count+1;
        }
    }
    public void UpdateSteps(int idx,int s)
    {
        if(idx>=0&&idx<count)
        {
            users[idx].AddSteps(s);
        }
    }
    public void BubbleSort()
    {
        int i=0;
        while(i<count-1)
        {
            int j=0;
            while(j<count-i-1)
            {
                if(users[j].GetSteps()<users[j+1].GetSteps())
                {
                    IUser temp=users[j];
                    users[j]=users[j+1];
                    users[j+1]=temp;
                }
                j=j+1;
            }
            i=i+1;
        }
    }
    public void Display()
    {
        Console.WriteLine("\n Leaderboard");
        int rank=1;
        int i=0;
        while(i<count)
        {
            Console.WriteLine("Rank "+rank+". "+users[i].GetName()+" - "+users[i].GetSteps()+" steps");
            rank=rank+1;
            i=i+1;
        }
        Console.WriteLine("\n");
    }

    public int GetCount()
    {
        return count;
    }

    public IUser GetUser(int idx)
    {
        if(idx>=0&&idx<count)
        {
            return users[idx];
        }
        return null;
    }
}