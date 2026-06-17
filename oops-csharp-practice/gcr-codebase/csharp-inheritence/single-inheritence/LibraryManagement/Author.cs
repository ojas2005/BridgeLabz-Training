using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgelabzTraining.inheritence.single_inheritence.LibraryManagement
{
    internal class Author : Book
    {
        string Name;
        string Bio;
        public Author(string title, int publicationYear, string name, string bio)
            : base(title, publicationYear)
        {
            this.Name = name;
            this.Bio = bio;
        }


        public override string ToString()
        {
            return base.ToString() + $" , Author Name : {Name} , Bio : {Bio}";
        }
    }
}
