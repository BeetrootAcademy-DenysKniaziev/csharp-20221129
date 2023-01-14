using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.HomeWork
{
    public class Wheel : IWorkable
    {
        public string Type { get; set; }
        public string  Date{ get; set; }
        public bool IsWorking { get; set; } = true;

        public Wheel(string type, string date)
        {
            this.Type = type;   
            this.Date = date;   
        }
        public Wheel(string type, string date, bool isWorking)
        {
            this.Type = type;
            this.Date = date;
            this.IsWorking = isWorking; 
        }
        public void Status()
        {
            if(IsWorking == false)
            {
                Console.WriteLine("Wheel is broken");
            }
            else
            {
                Console.WriteLine("Wheel works fine");
            }

        }
    }
}
