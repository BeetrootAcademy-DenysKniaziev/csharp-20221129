using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    internal class Engine : Detail, IBreakable
    {
        public string Type { get; set; } // V6, V10, W12 and others
        public double Volume { get; set; }
        public int HorsePower { get; set; }
        public bool IsStarted { get; private set; } = false;

        public Engine(string name, string type, double volume, int horsePower) : base(name) 
        {
            Type = type;
            Volume = volume;
            HorsePower = horsePower;
        }

        public void StartEngine() 
        {
            if (IsBroken)
            {
                Console.WriteLine("Engine is broken, repair it!");
                return;
            }
            IsStarted = true;
            Console.WriteLine("Engine is started!");
        }
        public void StopEngine()
        {
            IsStarted = false;
            Console.WriteLine("Engine is stoped!");
        }

        public void Break()
        {
            IsBroken = true;
            Console.WriteLine("Engine is gone flamed!");
        }
    }
}
