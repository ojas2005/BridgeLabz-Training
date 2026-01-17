using BookShelf.Interfaces;

namespace BookShelf.DataStructures
{
    public class HashSet:IHashSet
    {
        private const int defaultCapacity=16;
        private const float loadFactor=0.75f;

        private SetEntry[] table;
        private int size;

        private class SetEntry
        {
            public object Data;
            public SetEntry Next;

            public SetEntry(object data)
            {
                this.Data=data;
                this.Next=null;
            }
        }

        public HashSet()
        {
            this.table=new SetEntry[defaultCapacity];
            this.size=0;
        }

        private int GetHashCode(object obj)
        {
            if(obj==null)
            {
                return 0;
            }

            int hash=obj.GetHashCode();
            return Math.Abs(hash)%table.Length;
        }

        public void Add(object data)
        {
            if(data==null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if(size>=table.Length*loadFactor)
            {
                Resize();
            }

            int index=GetHashCode(data);
            SetEntry entry=table[index];

            while(entry!=null)
            {
                if(entry.Data.Equals(data))
                {
                    return;
                }
                entry=entry.Next;
            }

            SetEntry newEntry=new SetEntry(data);
            newEntry.Next=table[index];
            table[index]=newEntry;
            size++;
        }

        public void Remove(object data)
        {
            if(data==null)
            {
                return;
            }

            int index=GetHashCode(data);
            SetEntry entry=table[index];

            if(entry!=null&&entry.Data.Equals(data))
            {
                table[index]=entry.Next;
                size--;
                return;
            }

            while(entry!=null)
            {
                if(entry.Next!=null&&entry.Next.Data.Equals(data))
                {
                    entry.Next=entry.Next.Next;
                    size--;
                    return;
                }
                entry=entry.Next;
            }
        }
        private void Resize()
        {
            int newCapacity = table.Length * 2;
            SetEntry[] newTable = new SetEntry[newCapacity];

            for(int i = 0; i < table.Length; i++)
            {
                SetEntry entry = table[i];
                while(entry != null)
                {
                    SetEntry next = entry.Next;

                    int newIndex = Math.Abs(entry.Data.GetHashCode()) % newCapacity;
                    entry.Next = newTable[newIndex];
                    newTable[newIndex] = entry;

                    entry = next;
                }
            }

            table = newTable;
        }

        public bool Contains(object data)
        {
            if(data==null)
            {
                return false;
            }

            int index=GetHashCode(data);
            SetEntry entry=table[index];

            while(entry!=null)
            {
                if(entry.Data.Equals(data))
                {
                    return true;
                }
                entry=entry.Next;
            }
            return false;
        }

        public int GetSize()
        {
            return size;
        }
    }
}
