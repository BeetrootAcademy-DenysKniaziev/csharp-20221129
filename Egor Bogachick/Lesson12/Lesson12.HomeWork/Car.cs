using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.HomeWork
{
    public class Car : IWorkable, IMovable
    {
        public string Brand { get; set; }
        public string Date { get; set; }
        public Engine Engine { get; set; }
        public Wheel Wheel { get; set; }
        public bool IsWorking { get; set; } = true;

        public Car(string brand, string date)
        {
            this.Brand = brand;
            this.Date = date;
        }
        public Car(string brand, string date, Engine engine, Wheel wheel)
        {
            this.Brand = brand;
            this.Date = date;
            this.Engine = engine;
            this.Wheel = wheel;
        }
        public virtual void Move()
        {
            Console.WriteLine("Moves at a speed of 60 km");
        }

        public virtual void Status()
        {
            if (Engine == null || Wheel == null)
            {
                Console.WriteLine("The car is missing parts");
            }
            else if(Engine.IsWorking == false )
            {
                Engine.Status();
            }
            else if (Wheel.IsWorking == false)
            {
                Wheel.Status();
            }
            else if (IsWorking == false)
            {
                Console.WriteLine("Car is not ready");
            }
            else
            {
                Console.WriteLine("Car works fine");
            }
        }
    }
}
