namespace AddressBookApp
{
    public class HashMapEntry
    {
        public string Key;
        public ContactDirectory Value;

        public HashMapEntry(string key, ContactDirectory value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashMap
    {
        private HashMapEntry[] entries;
        private int size;
        private int capacity;

        public HashMap(int capacity = 10)
        {
            this.capacity = capacity;
            this.entries = new HashMapEntry[capacity];
            this.size = 0;
        }

        private int Hash(string key)
        {
            int hashCode = key.GetHashCode();
            return hashCode % capacity;
        }

        public void Put(string key, ContactDirectory value)
        {
            if (size >= capacity)
            {
                Resize();
            }

            int index = Hash(key);
            while (entries[index] != null && entries[index].Key != key)
            {
                index = (index + 1) % capacity;
            }

            if (entries[index] == null)
            {
                size++;
            }

            entries[index] = new HashMapEntry(key, value);
        }

        public ContactDirectory Get(string key)
        {
            int index = Hash(key);
            int startIndex = index;

            while (entries[index] != null)
            {
                if (entries[index].Key == key)
                {
                    return entries[index].Value;
                }
                index = (index + 1) % capacity;
                if (index == startIndex)
                    break;
            }

            return null;
        }

        public bool ContainsKey(string key)
        {
            return Get(key) != null;
        }

        public int Size
        {
            get { return size; }
        }

        public string[] GetAllKeys()
        {
            string[] keys = new string[size];
            int index = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (entries[i] != null)
                {
                    keys[index++] = entries[i].Key;
                }
            }
            return keys;
        }

        public ContactDirectory[] GetAllValues()
        {
            ContactDirectory[] values = new ContactDirectory[size];
            int index = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (entries[i] != null)
                {
                    values[index++] = entries[i].Value;
                }
            }
            return values;
        }

        private void Resize()
        {
            int oldCapacity = capacity;
            capacity = capacity * 2;
            HashMapEntry[] oldEntries = entries;
            entries = new HashMapEntry[capacity];
            size = 0;

            for (int i = 0; i < oldCapacity; i++)
            {
                if (oldEntries[i] != null)
                {
                    Put(oldEntries[i].Key, oldEntries[i].Value);
                }
            }
        }
    }
}
