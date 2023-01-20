using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Homework
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string PhoneNumber { get; set; }

        public Person(string fname, string lname, string numb)
        {
            FirstName = fname;
            LastName = lname;
            PhoneNumber = numb;
        }
    }
}
