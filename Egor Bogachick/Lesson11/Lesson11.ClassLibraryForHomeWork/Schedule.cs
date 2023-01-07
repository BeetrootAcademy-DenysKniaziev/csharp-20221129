using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    internal class Schedule
    {
        public string Day { get; set; }
        public Lesson[] Lessons { get; set; } = Array.Empty<Lesson>();

        public Schedule()
        {
            Lessons = Array.Empty<Lesson>();
        }

        public Schedule(string day)
        {
            this.Day = day;
            Lessons = Array.Empty<Lesson>();
        }
        public Schedule(string day, Lesson[] lessons)
        {
            this.Day = day;
            this.Lessons = lessons;
        }

        public void AddNewLesson(ref Lesson[] Lessons)
        {
            Lesson student = new Lesson();
            student.AddLesson();
            Array.Resize(ref Lessons, Lessons.Length + 1);
            Lessons[^1] = (student);
        }
    }
}

