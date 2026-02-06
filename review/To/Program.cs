

using System;
public class Node
{
    public int Data;
    public Node Next;
    public Node(int data)
    {
        Data=data;
        Next=null;
    }
}
public class LinkedList
{
    public Node Head;
    public void AddANode(int data)
    {
        Node newNode=new Node(data);
        if (Head==null)
        {
            Head=newNode;
            return;
        }
        Node temp=Head;
        while (temp.Next!=null)
        {
            temp=temp.Next;
        }
        temp.Next=newNode;
    }
    public void Display()
    {
        Node temp=Head;
        while (temp!=null)
        {
            Console.Write($"{temp.Data} - ");
            temp=temp.Next;
        }
        Console.WriteLine();
    }

    public Node Find(int value)
    {
        Node temp=Head;
        while (temp!=null)
        {
            if (temp.Data==value)
                return temp;
            temp=temp.Next;
        }
        return null;
    }
    public void DeleteNode(Node node)
    {
        if (node==null || node.Next==null)
        {
            return;
        }
        node.Data=node.Next.Data;
        node.Next=node.Next.Next;
    }
}


class Program
{
    public static void Main()
    {
        LinkedList list=new LinkedList();
        list.AddANode(10);
        list.AddANode(20);
        list.AddANode(30);
        list.AddANode(40);
        list.AddANode(50);
        Console.WriteLine("linked list is:-");
        list.Display();
        Node deleteNode=list.Find(30);
        list.DeleteNode(deleteNode);
        Console.WriteLine("linked list after deletion:-");
        list.Display();
        Console.ReadKey();
        Console.Clear();
    }
}
