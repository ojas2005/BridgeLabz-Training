using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (CreatorStats creator in records)
        {
            int weekCount = 0;
            
            foreach (double weeklyLike in creator.WeeklyLikes)
            {
                if (weeklyLike >= likeThreshold)
                {
                    weekCount++;
                }
            }

            if (weekCount > 0)
            {
                result[creator.CreatorName] = weekCount;
            }
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        if (CreatorStats.EngagementBoard.Count == 0)
        {
            return 0;
        }

        double totalLikes = 0;
        int totalWeeks = 0;

        foreach (CreatorStats creator in CreatorStats.EngagementBoard)
        {
            foreach (double weeklyLike in creator.WeeklyLikes)
            {
                totalLikes += weeklyLike;
                totalWeeks++;
            }
        }

        return totalWeeks > 0 ? totalLikes / totalWeeks : 0;
    }

    static void Main()
    {
        Program program = new Program();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("creator name:-");
                    string creatorName = Console.ReadLine();

                    Console.Write("enter weekly line ");
                    string[] likesInput = Console.ReadLine().Split();
                    double[] weeklyLikes = new double[4];

                    for (int i = 0; i < 4; i++)
                    {
                        weeklyLikes[i] = double.Parse(likesInput[i]);
                    }

                    CreatorStats newCreator = new CreatorStats
                    {
                        CreatorName = creatorName,
                        WeeklyLikes = weeklyLikes
                    };

                    program.RegisterCreator(newCreator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case "2":
                    Console.Write("Enter like threshold: ");
                    double likeThreshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> topPosts = program.GetTopPostCounts(
                        CreatorStats.EngagementBoard,
                        likeThreshold
                    );

                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var entry in topPosts)
                        {
                            Console.WriteLine($"{entry.Key} - {entry.Value}");
                        }
                    }
                    break;

                case "3":
                    double averageLikes = program.CalculateAverageLikes();
                    Console.WriteLine($"average weekly likes:- {averageLikes}");
                    break;

                case "4":
                    Console.WriteLine("logging off");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("enter a valid choice");
                    break;
            }
        }
    }
}
