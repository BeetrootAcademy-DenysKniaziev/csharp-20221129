using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class DayOfWeek
    {
        private string _title;
        private Subject[] _subjects;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public Subject[] Subjects
        {
            get { return _subjects; }
            set { _subjects = value; }
        }

        public DayOfWeek(string title, Subject[] subjects)
        {
            _title = title;
            Subjects = subjects;
        }
    }
}
