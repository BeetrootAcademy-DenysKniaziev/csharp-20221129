using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.HomeWork
{
    public class Engine : IWorkable
    {
        public int Type { get; set; }
        public int Power { get; set; }
        public int Volume { get; set; }
        public bool IsWorking { get; set; } = true;

        public Engine(int type, int power, int volume)
        {
            this.Type = type;
            this.Power = power;
            this.Volume = volume;
        }
        public Engine(int type, int power, int volume, bool isWorking)
        {
            this.Type = type;
            this.Power = power;
            this.Volume = volume;
            this.IsWorking = isWorking;
        }

        public void Status()
        {
            if (IsWorking == false)
            {
                Console.WriteLine("Engine is broken");
            }
            else
            {
                Console.WriteLine("Engine works fine");
            }
        }
    }
}
