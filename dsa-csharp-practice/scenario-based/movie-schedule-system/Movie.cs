using System;

namespace MovieTicketBookingSystem
{
    internal class Movie
    {
        private string name;
        private DateTime schedule;

        public Movie(string name, DateTime schedule)
        {
            this.name=name;
            this.schedule=schedule;
        }

        public string getName(){return name;}
        public DateTime getSchedule(){return schedule;}

        public override string ToString()
        {
            return $"movie title: {name} \nTime: {schedule}";
        }
    }
}
