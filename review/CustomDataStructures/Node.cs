namespace BookShelf.DataStructures
{
    public class Node
    {
        public object Data;
        public Node Next;

        public Node(object data)
        {
            this.Data=data;
            this.Next=null;
        }
    }
}
