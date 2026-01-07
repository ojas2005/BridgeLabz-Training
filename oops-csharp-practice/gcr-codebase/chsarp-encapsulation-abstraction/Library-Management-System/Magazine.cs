using System;

namespace LibraryApp
{
    internal class Magazine : LibraryItem, IReservable
    {
        private bool avail = true;

        public override int GetDays()
        {
            return 7;
        }

        public bool IsAvailable()
        {
            return avail;
        }

        public void Reserve()
        {
            if (avail)
            {
                avail = false;
                Console.WriteLine("magazine reserved");
            }
            else
            {
                Console.WriteLine("magazine not available");
            }
        }
    }
}
