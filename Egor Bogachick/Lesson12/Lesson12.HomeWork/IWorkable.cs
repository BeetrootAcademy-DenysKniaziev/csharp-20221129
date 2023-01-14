using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.HomeWork
{
    internal interface IWorkable
    {
        bool IsWorking { get; set; }
        void Status();
    }
}
