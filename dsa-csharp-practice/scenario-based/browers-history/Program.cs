using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal class Program
    {
        public static void Main(string[]args)
        {
            NavigationController nc = new NavigationController();
            nc.StartNavigation();
        }
    }
}
