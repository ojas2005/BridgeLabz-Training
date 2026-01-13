using System;
using System.Globalization;

namespace MovieTicketBookingSystem
{
    internal class Manager:IMovieManager
    {
        private static int adminPin=5426362;
        private Movie[] movieArray;
        private int movieCount;

        public Manager()
        {
            movieArray=new Movie[100];
            movieCount=0;
        }

        public void insertMovie()
        {
            Console.Write("enter movie name: ");
            string name=Console.ReadLine();

            Console.Write("enter schedule (dd-MM-yyyy HH:mm:ss): ");
            string timeInput=Console.ReadLine();

            DateTime schedule=DateTime.ParseExact(
                timeInput,
                "dd-MM-yyyy HH:mm:ss",
                CultureInfo.InvariantCulture
            );

            movieArray[movieCount]=new Movie(name,schedule);
            movieCount++;

            Console.WriteLine("movie added");
        }

        public void displayAllMovies()
        {
            if(movieCount==0)
            {
                Console.WriteLine("no movies available");
                return;
            }

            for(int i=0;i<movieCount;i++)
            {
                Console.WriteLine((i+1)+". "+movieArray[i]);
            }
        }

        public void findMovie(string name)
        {
            for(int i=0;i<movieCount;i++)
            {
                if(movieArray[i].getName().ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine(movieArray[i]);
                    return;
                }
            }

            Console.WriteLine("movie not found");
        }

        public bool validateAdmin(int pin)
        {
            if(pin==adminPin)
            {
                return true;
            }
            return false;
        }
    }
}
