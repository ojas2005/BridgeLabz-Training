using System;

namespace BridgelabzTraining.keywords_and_operator.level_1
{
    internal class LibraryManagementSystem
    {
        static void Main(string[] args)
        {
            ReadingItem r1=new ReadingItem("Demo Book","Demo Author","ISBN280");

            if (r1 is ReadingItem)
            {
                r1.Show();
            }

            ReadingItem.ShowLibrary();
        }
    }
    public class ReadingItem
    {
        public static string storeName="Central Library";
        public readonly string bookCode;

        string bookTitle;
        string bookAuthor;
        public ReadingItem(string bookTitle,string bookAuthor,string bookCode)
        {
            this.bookTitle=bookTitle;
            this.bookAuthor=bookAuthor;
            this.bookCode=bookCode;
        }
        public static void ShowLibrary()
        {
            Console.WriteLine($"library name is {storeName}");
        }

        public void Show()
        {
            Console.WriteLine($"title is {bookTitle}");
            Console.WriteLine($"author is {bookAuthor}");
            Console.WriteLine($"isbn is {bookCode}");
        }
    }
}
