using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal class NavigationController
    {
        INavigator navigator = new NavigationManager();

        public void StartNavigation()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("welcome to the navigation app");
                Console.WriteLine("press 1 to launch window");
                Console.WriteLine("press 2 to shutdown window");
                Console.WriteLine("press 3 to recover window");
                Console.WriteLine("press 4 to exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch(option)
                {
                    case 1:
                        navigator.LaunchWindow();
                        WindowOptions(navigator);
                        break;
                    case 2:
                        navigator.ShutdownWindow();
                        break;
                    case 3:
                        navigator.RecoverWindow();
                        WindowOptions(navigator);
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        isRunning = false;
                        Console.Error.WriteLine("invalid selection");
                        break; 
                }
            }  
        }

        public void WindowOptions(INavigator navigator)
        {
            if(!navigator.IsWindowActive())
            {
                Console.WriteLine("no active windows");
                return;
            }
            bool isActive = true;

            while(isActive)
            {
                Console.WriteLine("window options");
                Console.WriteLine("press 1 to navigate to location");
                Console.WriteLine("press 2 to go to previous location");
                Console.WriteLine("press 3 to go to next location");
                Console.WriteLine("press 4 to exit");

                int selection = Convert.ToInt32(Console.ReadLine());

                switch(selection)
                {
                    case 1:
                        String uri = Console.ReadLine();
                        navigator.NavigateTo(uri);
                        break;
                    case 2:
                        navigator.GoBack();
                        break;
                    case 3:
                        navigator.GoForward();
                        break;
                    case 4:
                        isActive = false;
                        break;
                    default:
                        isActive = false;
                        Console.Error.WriteLine("invalid selection");
                        break;
                }
            }
        }
    }  
}
