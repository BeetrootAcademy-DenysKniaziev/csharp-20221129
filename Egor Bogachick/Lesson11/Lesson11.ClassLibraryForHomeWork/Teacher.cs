using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Teacher(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;   
        }

        public Teacher(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age; 
        }

        public void ChangeTeacherInfo(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            Console.WriteLine("Teacher has been changed");
        }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName: " + LastName + ", Age: " + Age;
        }
    }
}
