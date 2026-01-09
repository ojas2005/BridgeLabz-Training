using System;

class MenuDisplay
{
    public void ShowMenu()
    {
        int choice=0;
        while(true)
        {
            Console.WriteLine("Atm Dispenser menu");
            Console.WriteLine("press 1 to take changes for your amount(including 500rs notes)");
            Console.WriteLine("press 2 to take change for your amount(without 500 note)");
            Console.WriteLine("press 3 to take change for any other amount");
            Console.WriteLine("press 4 for exit");
            Console.Write(" ");
            choice=int.Parse(Console.ReadLine());
            if(choice==1)
            {
                AtmUtility util=new AtmUtility();
                util.NoteCombinationForA();
            }
            else if(choice==2)
            {
                AtmUtility util=new AtmUtility();
                util.NoteCombinationForB();
            }
            else if(choice==3)
            {
                AtmUtility util=new AtmUtility();
                util.NoteCombinationForC();
            }
            else if(choice==4)
            {
                break;
            }
            else
            {
                Console.WriteLine("enter valid choice");
            }
        }
    }
}
