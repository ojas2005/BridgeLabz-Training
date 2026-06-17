namespace AddressBookApp
{
    public class LinkedListNode
    {
        public ContactPerson Data;
        public LinkedListNode Next;

        public LinkedListNode(ContactPerson data)
        {
            Data = data;
            Next = null;
        }
    }
}
