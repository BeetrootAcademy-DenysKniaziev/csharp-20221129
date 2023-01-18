using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Homework
{
    enum TireType
    {
        Performance,
        Standart,
        AllSurface,
        OffRoad,
        Slick
    }
    internal class Wheel : Detail, IBreakable
    {
        public TireType TireType { get; set; }
        public double Diameter { get; set; }

        public Wheel(string name, TireType tireType, double diameter) : base(name) // name is some marking code
        {
            TireType = tireType;
            Diameter = diameter;
        }

        public void Break()
        {
            IsBroken = true;
            Console.WriteLine("Tire is gone flat!");
        }
    }
}
