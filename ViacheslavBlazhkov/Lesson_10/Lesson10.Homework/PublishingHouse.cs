using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson10.Homework
{
    internal class PublishingHouse : Library
    {
        public PublishingHouse(string name, string city) : base(name, city) { }
        public PublishingHouse() : base() { }
        public static Book PublishBook(Book book, PublishingHouse pubHouse, double price)
		{
			return new Book(book.Title, book.Author, pubHouse, price);
		}
        public override string ToString()
        {
            return Name;
        }
    }
}
