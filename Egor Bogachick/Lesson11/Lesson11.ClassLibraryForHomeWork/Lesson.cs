using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    internal class Lesson
    {
        public string LessonName { get; set; }
        public string TimeSpan { get; set; }

        public Lesson(string lessonName, string timeSpan)
        {
            this.LessonName = lessonName;
            this.TimeSpan = timeSpan;
        }

    }
}
