using BookShelf.Interfaces;
using BookShelf.Models;

namespace BookShelf.DataStructures
{
    public class LinkedList:ILinkedList
    {
        private Node head;
        private int size;

        public LinkedList()
        {
            this.head=null;
            this.size=0;
        }

        public void Insert(object data)
        {
            if(data==null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Node newNode=new Node(data);

            if(head==null)
            {
                head=newNode;
            }
            else
            {
                Node current=head;
                while(current.Next!=null)
                {
                    current=current.Next;
                }
                current.Next=newNode;
            }
            size++;
        }

        public void Delete(object data)
        {
            if(head==null)
            {
                return;
            }

            if(head.Data.Equals(data))
            {
                head=head.Next;
                size--;
                return;
            }

            Node current=head;
            while(current.Next!=null)
            {
                if(current.Next.Data.Equals(data))
                {
                    current.Next=current.Next.Next;
                    size--;
                    return;
                }
                current=current.Next;
            }
        }

        public bool Contains(object data)
        {
            Node current=head;
            while(current!=null)
            {
                if(current.Data.Equals(data))
                {
                    return true;
                }
                current=current.Next;
            }
            return false;
        }

        public int GetSize()
        {
            return size;
        }

        public void Display()
        {
            Node current=head;
            while(current!=null)
            {
                System.Console.Write(current.Data+" -> ");
                current=current.Next;
            }
            System.Console.WriteLine("null");
        }

        public Node GetHead()
        {
            return head;
        }
    }
}
