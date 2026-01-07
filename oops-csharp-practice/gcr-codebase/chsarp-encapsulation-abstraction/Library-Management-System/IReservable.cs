using System;

namespace LibraryApp
{
    internal interface IReservable
    {
        void Reserve();
        bool IsAvailable();
    }
}
