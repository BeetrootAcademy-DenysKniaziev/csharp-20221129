static class Proram
{
    static ConsoleColor color;
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        color = ConsoleColor.Yellow;
        var snake = new Snake(color);
        snake.ReadyToStart += Ready;
        snake.EndGame += End;
        snake.Control();
    }

    private static void End(Snake snake)
    {
        Console.SetCursorPosition(snake.NextPoint.X, snake.NextPoint.Y);
        Console.Write("█");
    }

    public static void Ready()
    {
        string[] info;
        if (File.Exists("3.txt") && File.Exists("2.txt") && File.Exists("1.txt"))
        {
            string[] files = { "3.txt", "2.txt", "1.txt" };
            foreach (string file in files)
            {

                info = File.ReadAllLines(file);
                Console.SetCursorPosition(50, 15);
                for (int i = 0; i < info.Length; i++)
                {
                    Console.SetCursorPosition(40, 10 + i);
                    Console.WriteLine(info[i]);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.ForegroundColor = color;
        }
        else
        {
            for (int i = 3; i > 0; i--)
            {
                Console.SetCursorPosition(40, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.ForegroundColor = color;
        }

    }


}