using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.HomeWork
{
    public class Pixel
    {
        public const int width = 35;
        public const int height = 20;
        private const char borderChar = '#';
        private const ConsoleColor borderColor = ConsoleColor.Red;
        private const ConsoleColor foodColor = ConsoleColor.Green;
        private const char foodChar = '@';

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }

        public Pixel() { }
        public Pixel(int x, int y, ConsoleColor color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public static Pixel RandomFood(Pixel food)
        {
            Random random = new Random();
            food = new Pixel(random.Next(1, Pixel.width - 2), random.Next(1, Pixel.height - 2), foodColor);
            Console.ForegroundColor = foodColor;
            food.Draw(foodChar);
            return food;
        }

        public static void DrawBorder()
        {
            Console.ForegroundColor = borderColor;
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(borderChar);
                Console.SetCursorPosition(i, height - 1);
                Console.Write(borderChar);
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(borderChar);
                Console.SetCursorPosition(width - 1, i);
                Console.Write(borderChar);
            }
        }
        public void Draw(char c)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(c);
        }

    }
}
