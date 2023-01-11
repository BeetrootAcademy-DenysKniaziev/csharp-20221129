using System.Drawing;
using System.Runtime.InteropServices;

class Program
{

    static ConsoleKey Direction = ConsoleKey.RightArrow;
    static List<Point> Tail = new List<Point>();
    static string[] map;
    static short Score = 0;
    static Random random = new Random();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        map = MapCreate();
        RunAsync();

        while (true)
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow when Direction != ConsoleKey.RightArrow:
                    Direction = key;
                    break;
                case ConsoleKey.RightArrow when Direction != ConsoleKey.LeftArrow:
                    Direction = key;
                    break;
                case ConsoleKey.UpArrow when Direction != ConsoleKey.DownArrow:
                    Direction = key;
                    break;
                case ConsoleKey.DownArrow when Direction != ConsoleKey.UpArrow:
                    Direction = key;
                    break;

            }
            Thread.Sleep(150);
        }
        Console.ReadLine();

    }
    static async Task RunAsync()
    {
        await Task.Run(() => Run());
    }

    static void Run()
    {
        short x, y;
        while (true)
        {
            x = (short)random.Next(1, map[0].Length - 3);
            y = (short)random.Next(1, map.Count() - 3);

            char[] readBuffer = new char[1];
            int readCount;
            ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);

            if (readBuffer[0] != '#')
            {
                Console.SetCursorPosition(x, y);
                Console.Write("@");
                break;
            }
        }
        Food();
        Tail.Add(new Point(x, y));

        Thread.Sleep(2000);

        while (true)
        {
            switch (Direction)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;

            }
            Console.SetCursorPosition(Tail[Tail.Count - 1].X, Tail[Tail.Count - 1].Y);
            Console.Write(" ");

            CheckCord(ref x, ref y, Direction);

            Console.SetCursorPosition(x, y);
            Console.Write("@");
            ChangeTail();

            Point temp = Tail[0];
            (temp.X, temp.Y) = (x, y);
            Tail[0] = temp;

            Thread.Sleep(150);
        }
    }
    static void ChangeTail()
    {
        for (int i = Tail.Count - 1; i > 0; i--)
        {
            Point temp = Tail[i - 1];
            Tail[i] = temp;
        }
        return;

    }
    static string[] MapCreate()
    {

        string[] map = new string[0];
        if (File.Exists("map.txt"))
            map = File.ReadAllLines("map.txt");
        else
        {
            Console.WriteLine("Need map for start. Download: https://drive.google.com/drive/folders/1ahSweS9oAEXnJmbTU7F0NLZ-lebJ7LRF?usp=share_link");
            Environment.Exit(1);
        }
        foreach (string s in map)
            Console.WriteLine(s);
        char[] readBuffer = new char[1];
        int readCount;
        short x = 0, y = 0;

        return map;
    }
    static void CheckCord(ref short X, ref short Y, ConsoleKey key)
    {
        char[] readBuffer = new char[1];
        int readCount;
        short x = X, y = Y;
        ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);

        if (readBuffer[0] == '#' || readBuffer[0] == '@')
        {
            Console.SetCursorPosition(x, y);
            Console.Write("█");
            Thread.Sleep(2000);
            Console.Clear();
            string[] end;
            if (File.Exists("end.txt"))
            {
                end = File.ReadAllLines("end.txt");
                foreach (string s in end)
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("Game is over!");
            Console.WriteLine($"Your score: {Score}");
            Thread.Sleep(10000);
            Environment.Exit(0);
            
        }
        if (readBuffer[0] == '|')
        {

            if (Y == 0)
            {
                Y = (short)(map.Count() - 2);
            }
            if (Y == map.Count() - 1)
            {
                Y = 1;
            }
            if (X == 0)
            {
                X = (short)(map[0].Count() - 2);
            }
            if (X == map[0].Count() - 1)
            {
                X = 1;
            }
           

        }
        if (readBuffer[0] == '$')
        {


            if (Tail.Count == 1)
            {
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        x++;
                        break;
                    case ConsoleKey.RightArrow:
                        x--;
                        break;
                    case ConsoleKey.UpArrow:
                        y++;
                        break;
                    case ConsoleKey.DownArrow:
                        y--;
                        break;
                }
                Point point = new Point(x, y);
                Tail.Add(point);
            }
            else
            {
                int i = Tail.Count - 2;
                if (Tail[i].X > Tail[i + 1].X)
                {
                    Point temp = Tail[i + 1];
                    (temp.X, temp.Y) = (temp.X - 1, temp.Y);
                    Tail.Add(temp);
                }
                if (Tail[i].X < Tail[i + 1].X)
                {
                    Point temp = Tail[i + 1];
                    (temp.X, temp.Y) = (temp.X + 1, temp.Y);
                    Tail.Add(temp);
                }

                if (Tail[i].Y > Tail[i + 1].Y)
                {
                    Point temp = Tail[i + 1];
                    (temp.X, temp.Y) = (temp.X, temp.Y - 1);
                    Tail.Add(temp);
                }
                if (Tail[i].Y < Tail[i + 1].Y)
                {
                    Point temp = Tail[i + 1];
                    (temp.X, temp.Y) = (temp.X, temp.Y + 1);
                    Tail.Add(temp);
                }
            }
            Score++;
            Food();
          
        }
      

    }
    /// <summary>
    /// Random generate food
    /// </summary>
    static void Food()
    {
        while (true)
        {
            short x = (short)random.Next(1, map[0].Length - 3);
            short y = (short)random.Next(1, map.Count() - 3);

            char[] readBuffer = new char[1];
            int readCount;
            ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);

            if (readBuffer[0] != '#' && readBuffer[0] != '@')
            {
                Console.SetCursorPosition(x, y);
                Console.Write("$");
                return;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct COORD
    {
        public short X;
        public short Y;
    }

    // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutputCharacter.html
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool ReadConsoleOutputCharacter(
        IntPtr hConsoleOutput,
        [Out] char[] lpCharacter,
        int nLength,
        COORD dwReadCoord,
        out int lpNumberOfCharsRead
        );

    // http://pinvoke.net/default.aspx/kernel32/GetStdHandle.html
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(
        int nStdHandle
        );
}