using System.Drawing;

static class Proram
{
    static ConsoleColor color;
    public static void Main()
    {
        while (true)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            color = ConsoleColor.Yellow;
            var snake = new Snake("map.txt", color);
            snake.ReadyToStart += Ready;
            snake.EndGame += End;
            snake.PrintSymbol += PrintSymbol;
            snake.BuildMap += CreateMap;
            snake.Start();
            while (snake.IsAlive)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        snake.DirectionSet(Snake.Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.DirectionSet(Snake.Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        snake.DirectionSet(Snake.Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.DirectionSet(Snake.Direction.Down);
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Home) ;
            Console.Clear();

        }


    }

    private static void End(Snake snake)
    {
        Console.ForegroundColor = snake.Color;
        Console.SetCursorPosition(snake.NextPoint.X, snake.NextPoint.Y);
        Console.Write("█");
        Thread.Sleep(2500);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.SetCursorPosition(snake.Map[0].Length / 2, snake.Map.Length / 2);
        Console.WriteLine($"You score: {snake.Score}. Press Home to play again.");
    }

    public static void Ready(Snake snake)
    {
        string[] info;
        if (File.Exists("3.txt") && File.Exists("2.txt") && File.Exists("1.txt"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] files = { "3.txt", "2.txt", "1.txt" };
            foreach (string file in files)
            {

                info = File.ReadAllLines(file);
                Console.SetCursorPosition(snake.Map[0].Length / 2, snake.Map.Length / 2);
                for (int i = 0; i < info.Length; i++)
                {
                    Console.SetCursorPosition(snake.Map[0].Length / 2 - files[0].Length, snake.Map.Length / 2 + i - files.Length);
                    Console.WriteLine(info[i]);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }

        }
        else
        {
            for (int i = 3; i > 0; i--)
            {
                Console.SetCursorPosition(snake.Map[0].Length / 2, snake.Map.Length / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
                Thread.Sleep(1000);
                Console.Clear();
            }

        }
        Console.ForegroundColor = color;
    }
    public static void PrintSymbol(Point point, char symbol, ConsoleColor color)
    {
        Console.SetCursorPosition(point.X, point.Y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
    public static void CreateMap(string[] Map)
    {
        Console.SetCursorPosition(0, 0);
        Console.SetWindowSize(Map[0].Length + 1, Map.Length + 1);
        foreach (string s in Map)
            Console.WriteLine(s);
    }

}