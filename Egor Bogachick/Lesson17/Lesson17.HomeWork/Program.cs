using static System.Console;

namespace Lesson17.HomeWork
{
    internal class Program
    {
        public delegate void EventHandler(Snake snake);
        static event EventHandler Event;
        static void Main(string[] args)
        {
            CursorVisible = false;
            Directions direction = Directions.RIGHT;

            Pixel food = new Pixel();
            food = Pixel.RandomFood(food);
            Pixel.DrawBorder();
            Snake snake = new Snake(Pixel.width / 2, Pixel.height / 2);
            
            Event += Game.Score;
            Event += Game.CheckStatus;
            
            while (true)
            {
                while (Console.KeyAvailable)
                {
                    var action = Console.ReadKey();
                    switch (action.Key)
                    {
                        case ConsoleKey.DownArrow when direction != Directions.UP:
                            direction = Directions.DOWN;
                            break;
                        case ConsoleKey.UpArrow when direction != Directions.DOWN:
                            direction = Directions.UP;
                            break;
                        case ConsoleKey.LeftArrow when direction != Directions.RIGHT:
                            direction = Directions.LEFT;
                            break;
                        case ConsoleKey.RightArrow when direction != Directions.LEFT:
                            direction = Directions.RIGHT;
                            break;
                    }
                }
                snake.Move(direction, ref food);
                Event(snake);
                Thread.Sleep(200);
            }
        }
    }
}

