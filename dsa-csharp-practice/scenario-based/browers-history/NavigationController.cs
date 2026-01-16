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
                Console.WriteLine("1. launch window");
                Console.WriteLine("2. shutdown window");
                Console.WriteLine("3. recover window");
                Console.WriteLine("4. exit");
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
                Console.WriteLine("1. navigate to location");
                Console.WriteLine("2. go to previous location");
                Console.WriteLine("3. go to next location");
                Console.WriteLine("4. exit");

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
