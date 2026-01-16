using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal interface INavigationStack
    {
        void AddEntry(string uri);
        void Retreat();
        void Advance();
        void DisplayCurrent();
    }
}
