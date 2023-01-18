using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    internal class Mechanic : Person
    {
        public Mechanic(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public void RepairCar(Car car)
        { 
            car.IsBroken = true;
            Console.WriteLine("Car was repaired!");
        }
        public void RepairDetail(Detail detail)
        {
            detail.IsBroken = true;
            Console.WriteLine("Detail was repaired!");
        }
    }
}
