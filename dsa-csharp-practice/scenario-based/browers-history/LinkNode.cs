using System;

namespace WebNavigationApp.SessionTracking.BrowserNavigation{

    internal class LinkNode
    {
        private string uri;
        public LinkNode Previous;
        public LinkNode Next;

        public LinkNode(string uri){
            this.uri = uri;
            Previous = null;
            Next = null;
        }
        public string GetUri(){return uri;}
    }
}
