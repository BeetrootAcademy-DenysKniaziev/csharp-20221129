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
    }
}
