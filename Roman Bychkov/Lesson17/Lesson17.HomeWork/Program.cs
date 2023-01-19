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
            var snake = new Snake(color);
            snake.ReadyToStart += Ready;
            snake.EndGame += End;
            snake.Start();
            Console.Clear();
        }
       
        
    }

    private static void End(Snake snake)
    {
        Console.SetCursorPosition(snake.NextPoint.X, snake.NextPoint.Y);
        Console.Write("█");
        Thread.Sleep(2500);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.SetCursorPosition(snake.Map[0].Length / 2, snake.Map.Length / 2);
        Console.WriteLine($"You score: {snake.Score}. Press any key to play again.");
        Thread.Sleep(1500);
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


}