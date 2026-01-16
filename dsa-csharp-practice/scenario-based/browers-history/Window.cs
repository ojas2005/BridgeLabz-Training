using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal class Window
    {
        private int windowId;
        private NavigationStack navStack;

        public Window(int id)
        {
            this.windowId = id;
            navStack = new NavigationStack();
        }

        public int GetWindowId(){return windowId;}
        public NavigationStack GetNavigationStack(){return navStack;}
    }
}
