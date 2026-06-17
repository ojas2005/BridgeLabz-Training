using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.senario_based.Movie_Schedule__System
{
    internal interface IMovies
    {
        void ViewMovies();
        void AddMovie();
        void SearchMovie(string title);
    }
}
