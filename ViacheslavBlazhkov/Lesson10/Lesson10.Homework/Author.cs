using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.Homework
{
    internal class Author : Person
    {
        public Author() : base() { }
        public Author(string fullName, string country, int birthYear) : base(fullName, country, birthYear) { }

        public static Book WriteBook(string title, Author author)
		{
			return new Book(title, author);
		}
        public override string ToString()
        {
			return FullName;
        }
    }
}
