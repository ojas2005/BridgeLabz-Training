using System;
class Program
{
    static void Main()
    {
        LeaderBoard board = new LeaderBoard();
        board.AddUser(new User("aakash",5000));
        board.AddUser(new User("rahul",4200));
        board.AddUser(new User("priya",6100));
        board.AddUser(new User("neha",3900));
        board.AddUser(new User("anjali",5500));
        board.AddUser(new User("rohan",4800));
        board.AddUser(new User("suresh",5900));

        Console.WriteLine("fitness leaderboard system");
        Console.WriteLine("tracking steps for group (max 20 users)");

        board.BubbleSort();
        board.Display();

        Console.WriteLine("update 1: rahul walked 1200 more steps");
        board.UpdateSteps(1,1200);
        board.BubbleSort();
        board.Display();

        Console.WriteLine("update 2: neha walked 2000 more steps");
        board.UpdateSteps(3,2000);
        board.BubbleSort();
        board.Display();

        Console.WriteLine("update 3: aakash walked 600 more steps");
        board.UpdateSteps(0,600);
        board.BubbleSort();
        board.Display();

        Console.WriteLine("update 4: rohan walked 1500 more steps");
        board.UpdateSteps(5,1500);
        board.BubbleSort();
        board.Display();

        Console.WriteLine("update 5: suresh walked 400 more steps");
        board.UpdateSteps(6,400);
        board.BubbleSort();
        board.Display();

        Console.WriteLine("end of day final rankings");
        board.Display();

        Console.WriteLine("total active users:" + board.GetCount());
    }
}
