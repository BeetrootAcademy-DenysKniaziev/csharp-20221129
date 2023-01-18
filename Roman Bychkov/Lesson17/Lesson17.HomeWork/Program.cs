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
        snake.Control();
    }
    public static void Ready()
    {
        string[] info;
        if (File.Exists("3.txt") && File.Exists("2.txt") && File.Exists("1.txt"))
        {
            info = File.ReadAllLines("3.txt");
            foreach (string s in info)
                Console.WriteLine(s);
            Thread.Sleep(1000);
            Console.Clear();
            info = File.ReadAllLines("2.txt");
            foreach (string s in info)
                Console.WriteLine(s);
            Thread.Sleep(1000);
            Console.Clear();
            info = File.ReadAllLines("1.txt");
            foreach (string s in info)
                Console.WriteLine(s);
            Thread.Sleep(1000);
            Console.Clear();

        }
        else
        {
            for (int i = 3; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
                Thread.Sleep(1000);
                Console.Clear();
                Console.ForegroundColor = color;
            }
        }   

    }


}