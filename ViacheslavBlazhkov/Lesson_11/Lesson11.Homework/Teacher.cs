using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class Teacher : Person
    {
        private Subject _subject;

        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
        }
        public Teacher(string firstName, string lastName, Subject subj) : base(firstName, lastName)
        {
            _subject = subj;
        }
    }
}
