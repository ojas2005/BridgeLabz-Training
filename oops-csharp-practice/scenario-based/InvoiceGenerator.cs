using System;
class InvoiceGenerator{

    static string[] ParseInvoice(string input)
    {
        string[] tasks = input.Split(","); //logo - 3000, webpage - 4000 INR to tasks[0] = logo - 3000 INR, tasks[1] =  webpage - 4000 INR.
        return tasks;
    }

    static int GetTotalAmount(string[] tasks){
    int total=0;
    for(int i = 0;i<tasks.Length;i++)
    {
        string taskWithoutExtraSpace =  tasks[i].Trim(); //to remove extra spaces in front or end like-" webpage - 4000 INR" will become "webpage - 4000 INR"

        string[] taskPartition = taskWithoutExtraSpace.Split(" - "); //taskPartition[0] = logo,taskpartition[1] = 3000 INR

        //now we only want total amount so we will skip task name part,only work on taskPartition[1] part
        string[] ToGetTheAmountPart = taskPartition[1].Split(" "); //ToGetTheAmountPart[0] = 3000,ToGetTheAmountPart[1]=INR

        int amount = Convert.ToInt32(ToGetTheAmountPart[0]); //3000 is in string so we need to convert it into int.
        total+=amount; //adding that 3000 in total amount.

    }
    return total; //returning total amount.
    }
    static void Main()
    {
        //initialising the variables
        string input;
        string[] tasks = null;
        int total = 0;

        //Giving choice to the freelancer whether to create a invoice or generate total bill.
        Console.WriteLine("--------------------------------Menu---------------------------------");
        while(true)
        {
            Console.WriteLine("");
            Console.WriteLine("Press 1 to create a new invoice");
            Console.WriteLine("Press 2 to Generate Total Bill");
            Console.WriteLine("Press 3 to exit this menu");
            int choice = int.Parse(Console.ReadLine()); //freelancer will opt for one of the options given above.
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the services user wants to take with its price");   
                    input = Console.ReadLine();
                    //calling our methods
                    tasks = ParseInvoice(input); 
                    total = GetTotalAmount(tasks);
                    
                    continue;
                    
                case 2:
                    //Generating total bill
                    Console.WriteLine("Services You have selected are: \n");
                    for(int i =0;i<tasks.Length;i++)
                    {
                        Console.WriteLine($"{tasks[i].Trim()}");
                    }
                    Console.WriteLine($"Total amount   -       {total} INR");
                    continue;

                case 3:
                    //exiting the menu
                    return;
                default:
                    //if user made an invalid choice
                    Console.WriteLine("Invalid Choice");
                    break;



            }
        }
    }
}