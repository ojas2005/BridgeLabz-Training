using System;
using System.Collections.Generic;


public class CustomHashMap<K,V> 
    {
        private class Entry
        {
            public K key;
            public V val;
            public Entry next;

            public Entry(K k,V v)
            {
                key=k;
                val=v;
                next=null;
            }
        }

        private Entry[] buckets; //initializing bucket array
        private int size; //current filled size of buckets
        private const int cap=16; //initital number of buckets
        public CustomHashMap()
        {
            buckets=new Entry[cap];
            size=0;
        }

        private int GetHash(K k) //to get the current key index
        {
            return Math.Abs(k.GetHashCode()%buckets.Length);
        }

        public void Insertion(K k,V v)
        {

            int index=GetHash(k); //storing value of index of current key
            Entry curr=buckets[index]; //finding the bucket number in which its stored
 
            //updating the value at give index if key already exists
            while(curr!=null)
            {
                if(curr.key.Equals(k))
                {
                    curr.val=v;
                    return;
                }
                curr=curr.next;
            }
            //if key doesnt exist then inserting a new value at the head of linked list.
            Entry ent=new Entry(k,v);
            ent.next=buckets[index];
            buckets[index]=ent;
            size++; //increasing the size of hashmap.
        }
        public V Get(K k) //retrieval method
        {
            int index=GetHash(k);
            Entry curr=buckets[index];
            while(curr!=null)
            {
                if(curr.key.Equals(k))
                    return curr.val;
                curr=curr.next;
            }

            Console.WriteLine($"Key {k} not found");
            return curr.val;
        }
        public void Remove(K k) //deletion method
        {
            int index=GetHash(k);
            if(buckets[index]==null)
                return;
            if(buckets[index].key.Equals(k))
            {
                buckets[index]=buckets[index].next;
                size--;
                return;
            }
            Entry curr=buckets[index];
            while(curr.next!=null)
            {
                if(curr.next.key.Equals(k))
                {
                    curr.next=curr.next.next;
                    size--;
                    return;
                }
                curr=curr.next;
            }
        }

    }

class Program
{
    static void Main(string[] args)
    {
        CustomHashMap<string, int> map=new CustomHashMap<string, int>();
        int choice;
        do
        {
            Console.WriteLine("hashmap menu");
            Console.WriteLine("press 1 to insert");
            Console.WriteLine("press 2 to get");
            Console.WriteLine("press 3 to remove");
            Console.WriteLine("press 4 to exit");
            Console.WriteLine(" ");
            choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("enter key: ");
                    string keyInsert=Console.ReadLine();
                    Console.WriteLine("enter value: ");
                    int valueInsert=Convert.ToInt32(Console.ReadLine());
                    map.Insertion(keyInsert, valueInsert);
                    Console.WriteLine("key-value pair inserted successfully.");
                    break;

                case 2:
                    Console.WriteLine("enter key to search: ");
                    string keyGet=Console.ReadLine();
                    try
                    {
                        int value=map.Get(keyGet);
                        Console.WriteLine($"value: {value}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("cant find the key");
                    }
                    break;
                case 3:
                    Console.WriteLine("enter key to remove: ");
                    string keyRemove=Console.ReadLine();

                    map.Remove(keyRemove);
                    Console.WriteLine("key removed");
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("please enter valid choice");
                    break;
            }

        }while (choice!=4);
    }
}
