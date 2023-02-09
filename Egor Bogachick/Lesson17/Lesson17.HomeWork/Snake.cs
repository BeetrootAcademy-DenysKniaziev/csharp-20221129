using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.HomeWork
{
    internal class Snake
    {
        private const ConsoleColor headColor = ConsoleColor.Magenta;
        private const char snakeChar = '*';
        //private const char headChar = ' ';
        private const ConsoleColor bodyColor = ConsoleColor.Cyan;
        //private const char bodyChar = '*';

        public Snake(int x, int y)
        {
            int bodyLength = 2;
            Head = new Pixel(x, y, headColor);

            for (int i = bodyLength - 1; i > 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i , y, bodyColor));
            }

            Draw();
        }

        public Pixel Head { get; private set; }
        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Draw() 
        {
            Console.ForegroundColor = headColor;
            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write(snakeChar);

            Console.ForegroundColor = bodyColor;
            foreach (var i in Body)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(snakeChar);
            }
        }
    }
}
