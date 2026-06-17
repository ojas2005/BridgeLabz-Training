using System;

namespace MovieTicketBookingSystem
{
    internal interface IMovieManager
    {
        void displayAllMovies();
        void insertMovie();
        void findMovie(string name);
    }
}
