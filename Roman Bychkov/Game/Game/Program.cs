using System.Runtime.InteropServices;

class Program
{
    static ConsoleKey Direction = ConsoleKey.RightArrow;
    static string[] map;
    static short Width, Length, Score = 0;

    static void Main()
    {
        (Width, Length) = MapCreate();
        MoveAsync();
      
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
        }

        Console.ReadLine();
    }
    static async Task MoveAsync()
    {
        await Task.Run(() => Move());
    }
  
    static void Move()
    {

        Food();
        short x = (short)new Random().Next(2, Width), y = (short)new Random().Next(2, Length);
        Thread.Sleep(500);

        while (true)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(" ");
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

            Console.SetCursorPosition(x, y);
            if (CheckCord(x, y) == true)
                Food();
            Console.SetCursorPosition(x, y);
            Console.Write("@");
            Thread.Sleep(100);



        }
    }
    static (short Width, short Length) MapCreate()
    {

        string[] map;
        if (File.Exists("map.txt"))
            map = File.ReadAllLines("map.txt");
        else
            throw new Exception("Need map for start");
        foreach (string s in map)
            Console.WriteLine(s);
        char[] readBuffer = new char[1];
        int readCount;
        short x = 0, y = 0;

        //Get width and length of the map
        while (true)
        {
            ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);
            if (readBuffer[0] != '#')
            {
                x--;
                break;
            }
            x++;
        }
        while (true)
        {
            ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);
            if (readBuffer[0] != '#')
            {
                y--;
                break;
            }
            y++;
        }
        return (x, y);
    }
    static bool CheckCord(short x, short y)
    {
        char[] readBuffer = new char[1];
        int readCount;
        ReadConsoleOutputCharacter(GetStdHandle(-11), readBuffer, 1, new COORD() { X = x, Y = y }, out readCount);

        if (readBuffer[0] == '#')
        {
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
            Environment.Exit(0);
        }
        if (readBuffer[0] == '$')
        {
            Score++;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Random generate food 1 per 5 seconds
    /// </summary>
    static void Food()
    {
        while (true)
        {
            short x = (short)new Random().Next(2, Width), y = (short)new Random().Next(2, Length);

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