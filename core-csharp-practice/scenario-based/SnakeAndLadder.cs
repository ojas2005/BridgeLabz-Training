using System;
class SnakeAndLadder
{

    //creating the board and fixing the position of snakes and ladders.
    //board reference:- https://share.google/ngtWyF56Jxbitw1ox 
    static int[,] ladders ={{9,27},{18,37},{25,54},{28,51},{56,64},{68,88},{76,97},{79,100}};
    static int[,] snakes ={{16,7},{59,17},{63,19},{67,30},{87,24},{93,69},{95,75},{99,77}};
    static Random random = new Random();
    static void Main()
    {
        Console.WriteLine("Enter number of players.");
        int numberOfPlayers = int.Parse(Console.ReadLine());
        int[] positions = new int[4] {0, 0, 0, 0};
        int[] flags = new int[4] {0, 0, 0, 0};
        //checking if there is 2 to 4 players or not.
        if (numberOfPlayers<2)
        {
            Console.WriteLine("Not enough player to play this game");
            return;
        }
        else if (numberOfPlayers>4)
        {
            Console.WriteLine("Max 4 players are allowed");
            return;
        }
        //for 2 player,3 player and 4 players
        while (true)
        {
            bool allPlayersLeft = true;
            for (int i=0;i<numberOfPlayers;i++)
            {
                if (flags[i]==0)
                {
                    //checking if all players left or not,if not then giving player choice whether to play or quit.
                    allPlayersLeft = false;
                    Console.WriteLine($"Player {i+1} choice:");
                    Console.WriteLine("1- Roll Dice");
                    Console.WriteLine("2- Quit Game");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice==2)
                    {
                        Console.WriteLine($"Player {i+1} quit the game");
                        flags[i]=1;
                    }
                    else
                    {
                        int result = DiceRoll();
                        positions[i] = PositionAfterRoll(result, positions[i]);
                        Console.WriteLine($"Player {i+1} rolled the dice and got {result}, moved to {positions[i]}");
                        Console.WriteLine(" ");
                        if (positions[i]==100) 
                        {
                            Console.WriteLine($"Player {i+1} wins the match.");
                            return;
                        }
                    }
                }
            }
            if (allPlayersLeft)
            {
                Console.WriteLine("Game ended as all players have quit.");
                return;
            }
        }
    }

    //using random.Next to generate a random number for our dice.
    public static int DiceRoll()
    {
        return random.Next(1,7);
    }
    //creating a method to find the new position of the player after he throws dice.
    public static int PositionAfterRoll(int result,int currentPosition)
    {
        if (currentPosition + result > 100){
            return currentPosition; //if the player is at 98 and gets 3 he will not move to 101 instead he'll remain at 98.
        }
        int newPosition = currentPosition + result; 

        //checking if our new position is at ladder position,if yes we will move to the top of ladder
        for (int i = 0; i < ladders.GetLength(0); i++)
            if (newPosition == ladders[i, 0]){
                return ladders[i, 1];
            }

        //checking if our new position is at snake head position,if yes we will move to the tail of snake
        for (int i=0;i<snakes.GetLength(0);i++)
            if (newPosition == snakes[i,0]){
                return snakes[i,1];
            }
        //returning the new position after players chance
        return newPosition;
    }
}
