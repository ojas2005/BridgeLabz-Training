using System;

class CallLog
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
}

class Main
{
    static CallLog[] logs = new CallLog[100];
    static int logCount = 0;
    static string currentUser = "";

    static void MainMethod()
    {
        Login();
        ShowMenu();
    }

    static void Login()
    {
        string username = "admin";
        string password = "1234";

        while (true)
        {
            Console.Write("Enter username: ");
            string user = Console.ReadLine();

            Console.Write("Enter password: ");
            string pwd = Console.ReadLine();

            if (user == username && pwd == password)
            {
                currentUser = user;
                Console.WriteLine("Login successful");
                break;
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("1 Add Call Log");
            Console.WriteLine("2 Search by Keyword");
            Console.WriteLine("3 Filter by Time Range");
            Console.WriteLine("4 View All Logs");
            Console.WriteLine("5 Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCallLog();
                    break;
                case "2":
                    SearchByKeyword();
                    break;
                case "3":
                    FilterByTime();
                    break;
                case "4":
                    ViewAllLogs();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    static void AddCallLog()
    {
        if (logCount >= logs.Length)
        {
            Console.WriteLine("Log storage full");
            return;
        }

        Console.Write("Enter phone number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter message: ");
        string msg = Console.ReadLine();

        logs[logCount] = new CallLog
        {
            PhoneNumber = phone,
            Message = msg,
            Timestamp = DateTime.Now
        };

        logCount++;
        Console.WriteLine("Log added");
    }

    static void SearchByKeyword()
    {
        Console.Write("Enter keyword: ");
        string searchTerm = Console.ReadLine().ToLower();

        bool found = false;

        for (int i = 0; i < logCount; i++)
        {
            if (logs[i].Message.ToLower().Contains(searchTerm))
            {
                DisplayLog(i);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No results found");
    }

    static void FilterByTime()
    {
        Console.Write("Enter start date (yyyy-MM-dd HH:mm): ");
        DateTime startTime = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter end date (yyyy-MM-dd HH:mm): ");
        DateTime endTime = DateTime.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < logCount; i++)
        {
            if (logs[i].Timestamp >= startTime && logs[i].Timestamp <= endTime)
            {
                DisplayLog(i);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No logs found");
    }

    static void ViewAllLogs()
    {
        if (logCount == 0)
        {
            Console.WriteLine("No logs available");
            return;
        }

        for (int i = 0; i < logCount; i++)
        {
            DisplayLog(i);
        }
    }

    static void DisplayLog(int index)
    {
        Console.WriteLine("Phone: " + logs[index].PhoneNumber);
        Console.WriteLine("Message: " + logs[index].Message);
        Console.WriteLine("Time: " + logs[index].Timestamp);
    }
}
