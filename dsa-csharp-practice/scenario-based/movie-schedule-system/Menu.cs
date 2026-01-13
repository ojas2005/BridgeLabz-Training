using System;

namespace MovieTicketBookingSystem
{
    internal class Menu
    {
        private Manager manager=new Manager();

        public void start()
        {
            bool active=true;
            while(active)
            {
                Console.WriteLine();
                Console.WriteLine("movie ticket booking system");
                Console.WriteLine("press 1 to login as admin");
                Console.WriteLine("press 2 to continue as user");
                Console.WriteLine("press 3 to exit");
                Console.Write("choose option: ");

                int choice;
                if(!int.TryParse(Console.ReadLine(),out choice))
                {
                    Console.WriteLine("invalid input");
                    continue;
                }

                switch(choice)
                {
                    case 1:
                        adminMenu();
                        break;
                    case 2:
                        userMenu();
                        break;
                    case 3:
                        active=false;
                        Console.WriteLine("exit");
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }

        private void adminMenu()
        {
            Console.Write("enter admin pin: ");
            if(!int.TryParse(Console.ReadLine(),out int pin))
            {
                Console.WriteLine("invalid pin");
                return;
            }

            if(!manager.validateAdmin(pin))
            {
                Console.WriteLine("wrong pin");
                return;
            }

            bool inAdmin=true;
            while(inAdmin)
            {
                Console.WriteLine();
                Console.WriteLine("admin menu");
                Console.WriteLine("press 1 to add movie");
                Console.WriteLine("press 2 to view movies");
                Console.WriteLine("press 3 to search movie");
                Console.WriteLine("press 4 to go back");
                Console.Write("choose option: ");

                if(!int.TryParse(Console.ReadLine(),out int opt))
                {
                    Console.WriteLine("invalid input");
                    continue;
                }

                switch(opt)
                {
                    case 1:
                        manager.insertMovie();
                        break;
                    case 2:
                        manager.displayAllMovies();
                        break;
                    case 3:
                        Console.Write("enter movie name: ");
                        string query=Console.ReadLine();
                        manager.findMovie(query);
                        break;
                    case 4:
                        inAdmin=false;
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }

        private void userMenu()
        {
            bool inUser=true;
            while(inUser)
            {
                Console.WriteLine();
                Console.WriteLine("user menu");
                Console.WriteLine("press 1 to view movies");
                Console.WriteLine("press 2 to search movie");
                Console.WriteLine("press 3 to exit");
                Console.Write("choose option: ");

                if(!int.TryParse(Console.ReadLine(),out int opt))
                {
                    Console.WriteLine("invalid input");
                    continue;
                }

                switch(opt)
                {
                    case 1:
                        manager.displayAllMovies();
                        break;
                    case 2:
                        Console.Write("enter movie name: ");
                        string query=Console.ReadLine();
                        manager.findMovie(query);
                        break;
                    case 3:
                        inUser=false;
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            }
        }
    }
}
