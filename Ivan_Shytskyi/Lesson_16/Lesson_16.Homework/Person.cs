using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_16.Homework
{
    public abstract class Person
    {
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected int Age { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
