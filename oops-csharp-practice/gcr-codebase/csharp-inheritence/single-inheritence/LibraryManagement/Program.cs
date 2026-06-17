using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.single_inheritence.LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Clean Code", 2008);
            Book authorBook = new Author(
                "Harry Potter",
                1999,
                "Jk Rowling",
                "Novelist"
            );


            Console.WriteLine(book);
            Console.WriteLine(authorBook);
        }
    }
}
