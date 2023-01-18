using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    internal class Detail
    {
        public string Name { get; set; }
        public bool IsBroken { get; set; } = false;

        public Detail(string name) 
        {
            Name = name;
        }
    }
}
