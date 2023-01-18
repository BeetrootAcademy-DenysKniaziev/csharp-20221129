using System.Drawing;
using System.Runtime.InteropServices;

class Program
{

    static ConsoleKey Direction = ConsoleKey.RightArrow;
    static ConsoleKey PreviousDirection = ConsoleKey.LeftArrow;
    static List<Point> Tail = new List<Point>();
    static string[] map;
    static short Score = 0;
    static Random random = new Random();
    static short x, y, xF,yF;
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        MapCreate();
        Thread.Sleep(1000);
        var stateTimer = new Timer(Run, null, 0, 100);

        while (true)
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow when PreviousDirection != ConsoleKey.RightArrow:
                    Direction = key;
                    break;
                case ConsoleKey.RightArrow when PreviousDirection != ConsoleKey.LeftArrow:
                    Direction = key;
                    break;
                case ConsoleKey.UpArrow when PreviousDirection != ConsoleKey.DownArrow:
                    Direction = key;
                    break;
                case ConsoleKey.DownArrow when PreviousDirection != ConsoleKey.UpArrow:
                    Direction = key;
                    break;

            }
        }
        Console.ReadLine();

    }


    static void Run(object ob)
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
            PreviousDirection = Direction;


            CheckCord(ref x, ref y);

            Console.SetCursorPosition(x, y);
            Console.Write("@");
            ChangeTail();

            Point temp = Tail[0];
            (temp.X, temp.Y) = (x, y);
            Tail[0] = temp;

        
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
    static void MapCreate()
    {

        map = new string[0];
        if (File.Exists("map.txt"))
            map = File.ReadAllLines("map.txt");
        else
        {
            Console.WriteLine("Need map for start. Download: https://drive.google.com/drive/folders/1ahSweS9oAEXnJmbTU7F0NLZ-lebJ7LRF?usp=share_link");
            Environment.Exit(1);
        }
        foreach (string s in map)
            Console.WriteLine(s);


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


        
    }
    static void CheckCord(ref short x, ref short y)
    {
        char[] readBuffer = new char[1];
        int readCount;

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

            if (y == 0)
            {
                y = (short)(map.Count() - 2);
            }
            if (y == map.Count() - 1)
            {
                y = 1;
            }
            if (x == 0)
            {
                x = (short)(map[0].Count() - 2);
            }
            if (x == map[0].Count() - 1)
            {
                x = 1;
            }
            CheckCord(ref x, ref y);

        }
        if (xF == x && yF == y)
        {
            Tail.Add(new Point());
            Score++;
            Food();
        }
        else
        {
            Console.SetCursorPosition(Tail[Tail.Count - 1].X, Tail[Tail.Count - 1].Y);
            Console.Write(" ");
        }


    }
    /// <summary>
    /// Random generate food
    /// </summary>
    static void Food()
    {
        while (true)
        {
            xF = (short)random.Next(1, map[0].Length - 3);
            yF = (short)random.Next(1, map.Count() - 3);

            char[] readBuffer = new char[1];
            int readCount;
            ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = xF, Y = yF }, out readCount);

            if (readBuffer[0] != '#' && readBuffer[0] != '@')
            {
                Console.SetCursorPosition(xF, yF);
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