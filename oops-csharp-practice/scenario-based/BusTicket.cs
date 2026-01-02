using System;
class BusTicket
{
        static void Main()
    {
        int distanceBetweenStops=5; //we are taking 5km distance between each stops and total 8 stops
        int totalDistanceTravelled=0; //to calculate total distance
        int cur=0;
            Console.WriteLine("------------Bus Route Menu------------");
            Console.WriteLine("Where do you want to go? Select an option.");
            Console.WriteLine("1. Stop 1");
            Console.WriteLine("2. Stop 2");
            Console.WriteLine("3. Stop 3");
            Console.WriteLine("4. Stop 4");
            Console.WriteLine("5. Stop 5");
            Console.WriteLine("6. Stop 6");
            Console.WriteLine("7. Stop 7");
            Console.WriteLine("8. Stop 8");
            Console.WriteLine("0. Exit");
            Console.Write("enter your choice: ");
            int choice=int.Parse(Console.ReadLine());
            if(choice==0)
            {
                Console.WriteLine("you are already at your destination.");
                return;
            }
            else{
                totalDistanceTravelled=choice*5;
                Console.WriteLine("Bus starts.....");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("you have reached your destination");
                Console.WriteLine($"you have travelled {totalDistanceTravelled}kms");
                return;
            }
            
        }
    }

