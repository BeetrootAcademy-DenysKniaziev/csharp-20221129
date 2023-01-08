using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.Homework
{
    internal class Person
    {
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private int _birthYear;
        public int BirthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }

        public Person()
        {
            _fullName = "Unknown";
            _country = "Unknown";
            _birthYear = -1;
        }
        public Person(string fullName, string country, int birthYear)
        {
            _fullName = fullName;
            _country = country;
            _birthYear = birthYear;
        }
    }
}
