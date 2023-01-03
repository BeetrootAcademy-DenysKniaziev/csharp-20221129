using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    internal class Car : IBreakable
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Wheel CarWheel { get; set; }
        public bool IsDriving { get; protected set; } = false;
        public bool IsBroken { get; set; } = false;

        public Car(string brand, string model, Engine carEngine, Wheel carWheel)
        {
            Brand = brand;
            Model = model;
            CarEngine = carEngine;
            CarWheel = carWheel;
        }

        public void Drive()
        {
            if (IsBroken) Break();
            else if(CarWheel.IsBroken) CarWheel.Break();
            else if (!CarEngine.IsStarted) CarEngine.StartEngine();
            else
            {
                IsDriving = true;
                Console.WriteLine("Car is driving!");
            }
        }
        public void Park()
        {
            IsDriving = false;
            Console.WriteLine("Car is stoped!");
            CarEngine.StopEngine();
            Console.WriteLine("Car is parking!");
        }

        public void Break()
        {
            IsBroken = true;
            Console.WriteLine("Car is crashed!");
        }
    }
}
