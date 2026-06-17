using System;

namespace LibraryApp
{
    internal abstract class LibraryItem
    {
        private int id;
        private string title;
        private string author;

        public int Id { get { return id; } }
        public string Title { get { return title; } }
        public string Author { get { return author; } }

        public void SetId(int i) { id = i; }
        public void SetTitle(string t) { title = t; }
        public void SetAuthor(string a) { author = a; }

        public void PrintDetails()
        {
            Console.WriteLine(title + " by " + author);
        }

        public abstract int GetDays();
    }
}
