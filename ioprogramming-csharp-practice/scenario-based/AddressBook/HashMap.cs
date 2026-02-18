using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApp
{
    public class HashMap
    {
        private Dictionary<string, ContactDirectory> entries=new Dictionary<string, ContactDirectory>();

        public void Put(string key, ContactDirectory value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("key cannot be empty");

                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                entries[key]=value;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        public ContactDirectory Get(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("key cannot be empty");

                if (entries.TryGetValue(key, out var value))
                    return value;

                return null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return null;
            }
        }

        public bool ContainsKey(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return false;

                return entries.ContainsKey(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error in checking key: {ex.Message}");
                return false;
            }
        }

        public int Size
        {
            get { return entries.Count; }
        }

        public string[] GetAllKeys()
        {
            return entries.Keys.ToArray();
        }

        public ContactDirectory[] GetAllValues()
        {
            return entries.Values.ToArray();
        }

        public void Clear()
        {
            entries.Clear();
        }

        public bool Remove(string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                    return false;

                return entries.Remove(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error in removing key: {ex.Message}");
                return false;
            }
        }
    }
}
