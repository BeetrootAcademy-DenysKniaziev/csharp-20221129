using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_16.Homework
{
    internal class Candidate
    {
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public Candidate() { }
        public Candidate(string name)
        {
            Name = name;
        }
    }
}
