using System;
public class NestedLLImplementation{
    static void Main()
    {
        Node head = new Node(10);
        head.Next = new Node(20);
        head.Next.Next = new Node(30);
        // Inner list for node 10
        head.Down = new Node(1);
        head.Down.Next = new Node(2);
        head.Down.Next.Next = new Node(3);

        // Inner list for node 20
        head.Next.Down = new Node(7);
        head.Next.Down.Next = new Node(8);
        Node.Display(head);
    }

}

