using System;
class Program
{
    static void Main()
    {
        AadharManager manager = new AadharManager();
        IConsoleUtility utility = new ConsoleUtility();

        while (true)
        {
            utility.DisplayMenu();
            Console.Write("enter choice:- ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("enter a valid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    utility.AddNewNumber(manager);
                    break;

                case 2:
                    manager.DisplayAllNumbers();
                    break;

                case 3:
                    manager.SortAscending();
                    break;

                case 4:
                    manager.SortStable();
                    break;

                case 5:
                    utility.SearchAadhar(manager);
                    break;

                case 6:
                    manager.DisplaySorted();
                    break;

                case 7:
                    utility.LoadSampleData(manager);
                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("enter a valid choice");
                    break;
            }
        }
    }
}
