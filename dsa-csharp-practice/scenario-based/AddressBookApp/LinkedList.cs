namespace AddressBookApp
{
    public class LinkedList
    {
        private LinkedListNode head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(ContactPerson data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void Insert(int index, ContactPerson data)
        {
            if (index < 0 || index > count)
                return;

            LinkedListNode newNode = new LinkedListNode(data);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                LinkedListNode current = GetNodeAt(index - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                return;

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                LinkedListNode current = GetNodeAt(index - 1);
                current.Next = current.Next.Next;
            }
            count--;
        }

        public ContactPerson GetAt(int index)
        {
            if (index < 0 || index >= count)
                return null;

            LinkedListNode current = GetNodeAt(index);
            return current.Data;
        }

        private LinkedListNode GetNodeAt(int index)
        {
            LinkedListNode current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public int IndexOf(ContactPerson data)
        {
            LinkedListNode current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public ContactPerson[] ToArray()
        {
            ContactPerson[] arr = new ContactPerson[count];
            LinkedListNode current = head;
            int index = 0;
            while (current != null)
            {
                arr[index] = current.Data;
                current = current.Next;
                index++;
            }
            return arr;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }
    }
}
