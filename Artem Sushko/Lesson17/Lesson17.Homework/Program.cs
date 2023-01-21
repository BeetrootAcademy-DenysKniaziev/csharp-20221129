using static System.Console;

class Program
{
    public delegate void EventHandler(int x, int y, int z);
    static event EventHandler Event;

    static void Main(string[] args)
    {
        Event += Fail;

        int Width = 32;
        int Height = 16;
        Random rand = new Random();
        int Score = 0;
        Pixel Pixel = new Pixel();
        Pixel.X = Width / 2;
        Pixel.Y = Height / 2;
        Pixel.Colour = ConsoleColor.Red;
        string movement = "RIGHT";
        List<int> Xpos = new List<int>();
        List<int> Ypos = new List<int>();
        int targetX = rand.Next(1, Width - 1);
        int targetY = rand.Next(1, Height);


        while (true)
        {

            Console.ForegroundColor = ConsoleColor.White;
            DrawBorder(Width, Height);

            Console.ForegroundColor = ConsoleColor.Green;
            if (Pixel.X == Width - 1 || Pixel.X == 0 || Pixel.Y == Height || Pixel.Y == 0)
            {
                Event(Width, Height, Score);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            if (targetX == Pixel.X && targetY == Pixel.Y)
            {
                Score++;
                targetX = rand.Next(1, Width - 1);
                targetY = rand.Next(1, Height);
            }
            for (int i = 0; i < Xpos.Count(); i++)
            {
                Console.SetCursorPosition(Xpos[i], Ypos[i]);
                Console.Write('*');
                if (Xpos[i] == Pixel.X && Ypos[i] == Pixel.Y)
                {
                    Event(Width, Height, Score);
                }
            }

            Console.SetCursorPosition(Pixel.X, Pixel.Y);
            Console.ForegroundColor = Pixel.Colour;
            Console.Write('■');
            Console.SetCursorPosition(targetX, targetY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('■');

            Console.SetCursorPosition(0, Height + 1);
            Console.Write("Current Score: " + Score);
            Console.SetCursorPosition(0, Height + 3);
            Console.Write("Use WASD or ARROWS for control!");

            Console.CursorVisible = false;

            while (Console.KeyAvailable)
            {
                var select = Console.ReadKey(true);

                if ((select.Key.Equals(ConsoleKey.UpArrow) || select.Key.Equals(ConsoleKey.W)) && movement != "DOWN")
                {
                    movement = "UP";
                }
                if ((select.Key.Equals(ConsoleKey.DownArrow) || select.Key.Equals(ConsoleKey.S)) && movement != "UP")
                {
                    movement = "DOWN";
                }
                if ((select.Key.Equals(ConsoleKey.LeftArrow) || select.Key.Equals(ConsoleKey.A)) && movement != "RIGHT")
                {
                    movement = "LEFT";
                }
                if ((select.Key.Equals(ConsoleKey.RightArrow) || select.Key.Equals(ConsoleKey.D)) && movement != "LEFT")
                {
                    movement = "RIGHT";
                }

            }
            Xpos.Add(Pixel.X);
            Ypos.Add(Pixel.Y);
            switch (movement)
            {
                case "UP":
                    Pixel.Y--;
                    break;
                case "DOWN":
                    Pixel.Y++;
                    break;
                case "LEFT":
                    Pixel.X--;
                    break;
                case "RIGHT":
                    Pixel.X++;
                    break;
            }
            if (Xpos.Count() > Score)
            {
                Xpos.RemoveAt(0);
                Ypos.RemoveAt(0);
            }
            Thread.Sleep(250);
            Console.Clear();
        }

        static void Fail(int width, int height, int score)
        {
            Console.SetCursorPosition(width / 5, height / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(width / 5, height / 2 + 1);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }

    private static void DrawBorder(int width, int height)
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string('■', width));
        Console.SetCursorPosition(0, height);
        Console.Write(new string('■', width));

        for (int i = 1; i < height; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write('■');
            Console.SetCursorPosition(width - 1, i);
            Console.Write('■');
        }
    }

    class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Colour { get; set; }
    }
}