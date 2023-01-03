using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    internal class SportCar : Car
    {
        public SportCar(string brand, string model, Engine carEngine, Wheel carWheel) : base(brand, model, carEngine, carWheel)
        {
        }

        public void Drift()
        {
            if (IsBroken)
            {
                Console.WriteLine("Car is broken, repair it!");
                return;
            }
            if (IsDriving == false) this.Drive();
            Console.WriteLine("Car is drifting now. Car and its wheels have bigger chance to be breake!");
        }
    }
}
