using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation
{
    internal class NavigationStack : INavigationStack
    {
        protected LinkNode head;
        protected LinkNode cursor;

        public void AddEntry(string uri)
        {
            LinkNode freshNode = new LinkNode(uri);

            if (head == null){
                head = freshNode;
                cursor = freshNode;
                return;
            }

            cursor.Next = null;
            freshNode.Previous = cursor;
            cursor.Next = freshNode;
            cursor = freshNode;
        }

        public void Retreat()
        {
            if(cursor != null && cursor.Previous != null)
            {
                cursor = cursor.Previous;
                Console.WriteLine("retreated to " + cursor.GetUri());
            }
            else
            {
                Console.WriteLine("no earlier entries available");
            }
        }

        public void Advance()
        {
            if(cursor != null && cursor.Next != null){
                cursor = cursor.Next;
                Console.WriteLine("advanced to " + cursor.GetUri());
            }
            else{
                Console.WriteLine("no subsequent entries available");
            }
        }

        public void DisplayCurrent()
        {
            if(cursor != null)
            {
                Console.WriteLine("current location is " + cursor.GetUri());
            }
            else
            {
                Console.WriteLine("no location loaded");
            }
        }
    }
}
