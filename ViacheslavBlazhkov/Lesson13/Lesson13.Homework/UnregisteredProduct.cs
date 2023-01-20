using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13.Homework
{
    abstract class UnregisteredProduct
    {
        public string Name { get; set; }

        public UnregisteredProduct(string name)
        { 
            Name = name; 
        }
    }
}
