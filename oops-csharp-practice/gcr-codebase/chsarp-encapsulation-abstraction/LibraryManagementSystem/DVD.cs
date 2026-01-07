using System;

namespace LibraryApp
{
    internal class DVD : LibraryItem, IReservable
    {
        private bool avail=true;

        public override int GetDays()
        {
            return 3;
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
                Console.WriteLine("dvd reserved");
            }
            else
            {
                Console.WriteLine("dvd not available");
            }
        }
    }
}
