using BookShelf.Interfaces;

namespace BookShelf.DataStructures
{
    public class HashMap:IHashMap
    {
        private const int INITIAL_CAPACITY=16;
        private const float LOAD_FACTOR=0.75f;

        private Entry[] table;
        private int size;

        private class Entry
        {
            public string Key;
            public ILinkedList Value;
            public Entry Next;

            public Entry(string key,ILinkedList value)
            {
                this.Key=key;
                this.Value=value;
                this.Next=null;
            }
        }

        public HashMap()
        {
            this.table=new Entry[INITIAL_CAPACITY];
            this.size=0;
        }
        public List<string> GetKeys()
        {
            List<string> keys = new List<string>();

            for(int i = 0; i < table.Length; i++)
            {
                Entry current = table[i];
                while(current != null)
                {
                    keys.Add((string)current.Key);
                    current = current.Next;
                }
            }
            return keys;
        }


        private int GetHashCode(string key)
        {
            if(key==null)
            {
                return 0;
            }

            int hash=0;
            for(int i=0;i<key.Length;i++)
            {
                hash=hash*31+key[i];
            }
            return Math.Abs(hash)%table.Length;
        }

        public void Put(string key,ILinkedList value)
        {
            if(key==null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if(size>=table.Length*LOAD_FACTOR)
            {
                Resize();
            }

            int index=GetHashCode(key);
            Entry entry=table[index];

            while(entry!=null)
            {
                if(entry.Key==key)
                {
                    entry.Value=value;
                    return;
                }
                entry=entry.Next;
            }

            Entry newEntry=new Entry(key,value);
            newEntry.Next=table[index];
            table[index]=newEntry;
            size++;
        }

        public ILinkedList Get(string key)
        {
            if(key==null)
            {
                return null;
            }

            int index=GetHashCode(key);
            Entry entry=table[index];

            while(entry!=null)
            {
                if(entry.Key==key)
                {
                    return entry.Value;
                }
                entry=entry.Next;
            }

            return null;
        }

        public void Remove(string key)
        {
            if(key==null)
            {
                return;
            }

            int index=GetHashCode(key);
            Entry entry=table[index];

            if(entry!=null&&entry.Key==key)
            {
                table[index]=entry.Next;
                size--;
                return;
            }

            while(entry!=null)
            {
                if(entry.Next!=null&&entry.Next.Key==key)
                {
                    entry.Next=entry.Next.Next;
                    size--;
                    return;
                }
                entry=entry.Next;
            }
        }

        public bool ContainsKey(string key)
        {
            return Get(key)!=null;
        }

        public int GetSize()
        {
            return size;
        }

        public void DisplayAllEntries()
        {
            System.Console.WriteLine("\n=== HashMap Contents ===");
            for(int i=0;i<table.Length;i++)
            {
                if(table[i]!=null)
                {
                    Entry entry=table[i];
                    while(entry!=null)
                    {
                        System.Console.WriteLine($"Genre: {entry.Key}");
                        entry=entry.Next;
                    }
                }
            }
        }

        private void Resize()
        {
            Entry[] oldTable=table;
            table=new Entry[oldTable.Length*2];
            size=0;

            for(int i=0;i<oldTable.Length;i++)
            {
                Entry entry=oldTable[i];
                while(entry!=null)
                {
                    Put(entry.Key,entry.Value);
                    entry=entry.Next;
                }
            }
        }
    }
}
