using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.Homework
{
    internal class Library
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public Library(string name, string city)
        {
            _name = name;
            _city = city;
        }
        public Library()
        {
            _name = "Unknown";
            _city = "Unknown";
        }
    }
}
