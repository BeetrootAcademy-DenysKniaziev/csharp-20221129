using System.Runtime.InteropServices;

class Program
{
    static ConsoleKey Direction = ConsoleKey.RightArrow;
    static string[] map;
    static void Main()
    {
        map = MapCreate();

        MoveAsync();
        while (true)
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow when Direction!=ConsoleKey.RightArrow:
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

        short x = 10, y= 10;
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
            CheckCord(x, y);
            Console.Write("@");
            Thread.Sleep(100);
           


        }
    }
    static string[] MapCreate()
    {

        string[] map;
        if (File.Exists("map.txt"))
            map = File.ReadAllLines("map.txt");
        else
            throw new Exception("Need map for start");
        foreach (string s in map)
            Console.WriteLine(s);
        return map;
    }
    static void CheckCord(short x, short y)
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
            
            Environment.Exit(0);
        }
    }
    /// <summary>
    /// Random generate food 1 per 5 seconds
    /// </summary>
    static void Food(short x, short y)
    {
        while(true)
        {
            Thread.Sleep(4000);
            
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