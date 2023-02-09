using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.HomeWork
{
    public class Pixel
    {
        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }

        public Pixel(int x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }


    }
}
