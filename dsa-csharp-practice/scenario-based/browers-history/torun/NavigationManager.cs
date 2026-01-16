using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal class NavigationManager: INavigator
    {
        private Window[] activeWindows=new Window[100];
        private int activeCount=0;
        
        private Window[] discardedWindows=new Window[100];
        private int discardedCount=0;
        
        private Window currentWindow;
        private int windowCounter=1;

        public void LaunchWindow()
        {
            Window w=new Window(windowCounter++);
            if(activeCount < activeWindows.Length)
            {
                activeWindows[activeCount++]=w;
            }
            currentWindow=w;
            Console.WriteLine("launched window with identifier " + w.GetWindowId());
        }

        public void ShutdownWindow()
        {
            if(currentWindow!=null)
            {
                Console.WriteLine("no windows are active");
                return;
            }

            int removeIndex=-1;
            for(int i=0;i < activeCount;i++)
            {
                if(activeWindows[i].GetWindowId() == currentWindow.GetWindowId())
                {
                    removeIndex=i;
                    break;
                }
            }
            
            if(removeIndex >= 0)
            {
                for(int i=removeIndex;i < activeCount - 1;i++)
                {
                    activeWindows[i]=activeWindows[i + 1];
                }
                activeCount--;
            }
            
            if(discardedCount < discardedWindows.Length)
            {
                discardedWindows[discardedCount++]=currentWindow;
            }
            
            Console.WriteLine("terminated window with identifier " + currentWindow.GetWindowId());

            if(activeCount > 0)
            {
                currentWindow=activeWindows[activeCount - 1];
            }
            else
            {
                currentWindow=null;
            }
        }

        public void RecoverWindow(){
            if(discardedCount == 0)
            {
                Console.WriteLine("no terminated windows available");
                return;
            }
            Window w=discardedWindows[discardedCount - 1];
            discardedCount--;
            
            if(activeCount < activeWindows.Length)
            {
                activeWindows[activeCount++]=w;
            }
            currentWindow=w;

            Console.WriteLine("successfully recovered window with identifier " + currentWindow.GetWindowId());
        }

        public void NavigateTo(string uri)
        {
            if(currentWindow == null)
            {
                Console.WriteLine("no windows are active");
            }

            currentWindow.GetNavigationStack().AddEntry(uri);
            Console.WriteLine("now navigating to " + uri);
        }

        public void GoBack()
        {
            if(currentWindow == null)
            {
                Console.WriteLine("no windows are active");
            }

            currentWindow.GetNavigationStack().Retreat();
        }

        public void GoForward()
        {
            if(currentWindow == null)
            {
                Console.WriteLine("no windows are active");
            }

            currentWindow.GetNavigationStack().Advance();
        }

        public bool IsWindowActive()
        {
            return currentWindow != null;
        }
    }
}
