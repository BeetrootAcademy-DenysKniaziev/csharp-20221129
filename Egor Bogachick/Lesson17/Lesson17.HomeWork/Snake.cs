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

        public void Move(Directions direction, ref Pixel food)
        {
            Clear();
            Body.Enqueue(new Pixel(Head.X, Head.Y, bodyColor));
            if (food.X != Head.X || food.Y != Head.Y)
            {
                Body.Dequeue();  
            }
            else
            {
                food = Pixel.RandomFood(food);
            }

            switch (direction)
            { 
                case Directions.UP:
                    Head = new Pixel(Head.X, Head.Y - 1, headColor);
                    break;
                case Directions.DOWN:
                    Head = new Pixel(Head.X, Head.Y + 1, headColor);
                    break;
                case Directions.LEFT:
                    Head = new Pixel(Head.X - 1, Head.Y, headColor);
                    break;
                case Directions.RIGHT:
                    Head = new Pixel(Head.X + 1, Head.Y, headColor);
                    break;
            }
            Draw();
        }

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

        public void Clear()
        {
            Console.SetCursorPosition(Head.X, Head.Y);
            Console.Write(' ');

            foreach (var i in Body)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(' ');
            }
        }
    }
}
