using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal interface INavigator
    {
        void LaunchWindow();
        void ShutdownWindow();
        void RecoverWindow();
        void NavigateTo(string uri);
        void GoBack();
        void GoForward();
        bool IsWindowActive();
    }
}
