using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.Homework
{
    internal class Book
    {
		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private Author _author;
		public Author Author
		{
			get { return _author; }
			set { _author = value; }
		}

		private PublishingHouse _publishingHouse;
		public PublishingHouse PublishingHouse
		{
			get { return _publishingHouse; }
			set { _publishingHouse = value; }
		}

		private double _price;
		public double Price
		{
			get { return _price; }
			set { _price = value; }
		}

		public Book(string title, Author author) // when author write new book
		{
			_title = title;
			_author = author;
		}
        public Book(string title, Author author, PublishingHouse pubHouse, double price) // when pubHouse publish new book
        {
            _title = title;
            _author = author;
			_publishingHouse = pubHouse;
			_price = price;
        }
    }
}
