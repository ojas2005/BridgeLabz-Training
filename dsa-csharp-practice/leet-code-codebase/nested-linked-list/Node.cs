using System;
public class Node{
    public int Data;
    public Node Next;
    public Node Down; //head of inner linked list
    public Node(int Data)
    {
        this.Data = Data;
        Next = null;
        Down = null;
    }

    public static void Display(Node head)
    {
        Node curr = head;
        while(curr!=null)
        {
            Console.Write(curr.Data+"->");
            Node down = curr.Down;
            while(down!=null)
            {
                Console.Write(down.Data+"->");
                down = down.Next;
            }
            curr=curr.Next;
            Console.WriteLine();
        }
        
    }
}