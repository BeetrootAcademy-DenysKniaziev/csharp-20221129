using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.HomeWork
{
    internal class SportCar : Car
    {

        public SportCar(string brand, string date) : base(brand, date)
        {
        }

        public SportCar(string brand, string date, Engine engine, Wheel wheel) : base(brand, date, engine, wheel)
        {
        }

        public override void Move()
        {
            Console.WriteLine("Moves at a speed of 120 km");
        }

        public override void Status()
        {
            if (Engine == null || Wheel == null)
            {
                Console.WriteLine("The car is missing parts");
            }
            else if (Engine.IsWorking == false)
            {
                Engine.Status();
            }
            else if (Wheel.IsWorking == false)
            {
                Wheel.Status();
            }
            else if (IsWorking == false)
            {
                Console.WriteLine("Sport car is not ready");
            }
            else
            {
                Console.WriteLine("Sport car works fine");
            }
        }
    }
}
