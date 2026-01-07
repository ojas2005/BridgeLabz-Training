using System;

namespace LibraryApp
{
    internal class Book : LibraryItem, IReservable
    {
        private bool avail=true;

        public override int GetDays()
        {
            return 14;
        }

        public bool IsAvailable()
        {
            return avail;
        }

        public void Reserve()
        {
            if (avail)
            {
                avail=false;
                Console.WriteLine("book reserved");
            }
            else
            {
                Console.WriteLine("book not available");
            }
        }
    }
}
