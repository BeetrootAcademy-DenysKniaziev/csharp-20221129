using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson20.FromLesson13
{
    public abstract class Person : IShowable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public int Age { get; set; }
        public string Adress { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, int age, string adress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Adress = adress;
        }
        public abstract void Luck();
        public abstract void Info();
    }
}
