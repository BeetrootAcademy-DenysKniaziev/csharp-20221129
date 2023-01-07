using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    internal class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class Class { get; set; }

        public Teacher(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;   
        }
        public Teacher(string firstName, string lastName, Class Class)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Class = Class;
        }

        public void ChangeTeacherInfo(string firstName, string lastName, Class Class)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Class = Class;
            Console.WriteLine("Teacher has been changed");
        }
    
    
    }
}
