using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.HomeWork
{
    public static class Game
    {
        public static void CheckStatus(Snake snake)
        {
            if (snake.Head.X == Pixel.width - 1 || snake.Head.X == 0 || snake.Head.Y == 0 || snake.Head.Y == Pixel.height - 1)
            {
                Console.SetCursorPosition(Pixel.width + 2, Pixel.height / 2);
                Console.Write("Game Over");
                Console.SetCursorPosition(0, Pixel.height + 1);
                Environment.Exit(0);
            }
            foreach (var c in snake.Body)
            {
                if (snake.Head.X == c.X && snake.Head.Y == c.Y)
                {
                    Console.SetCursorPosition(Pixel.width + 2, Pixel.height / 2);
                    Console.Write("Game Over");
                    Console.SetCursorPosition(0, Pixel.height + 1);
                    Environment.Exit(0);
                }
            }
            if (snake.Body.Count == (Pixel.height - 1 * Pixel.width - 1) - 2)
            {
                Console.SetCursorPosition(Pixel.width + 2, Pixel.height / 2);
                Console.Write("Congratulations! You win!!!");
                Console.SetCursorPosition(0, Pixel.height + 1);
                Environment.Exit(0);
            }
        }

        public static void Score(Snake snake)
        {
            int score = snake.Body.Count - 1;
            Console.SetCursorPosition(Pixel.width + 2, 3);
            Console.Write($"Score: {score}");
        }
    }

}
