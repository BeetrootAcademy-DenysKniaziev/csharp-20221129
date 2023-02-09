using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.HomeWork
{
    public class Pixel
    {
        private const int width = 35;
        private const int height = 20;
        private const char borderChar = '#';
        private const ConsoleColor borderColor = ConsoleColor.Red;

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }

        public Pixel(int x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public static void DrawBorder()
        {
            Console.ForegroundColor = borderColor;
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(borderChar);
                Console.SetCursorPosition(i, height);
                Console.Write(borderChar);
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(borderChar);
                Console.SetCursorPosition(width, i);
                Console.Write(borderChar);
            }
        }

    }
}
