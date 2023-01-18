using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;

static class Snake
{

    static ConsoleKey Direction = ConsoleKey.RightArrow;
    static ConsoleKey PreviousDirection = ConsoleKey.LeftArrow;
    static List<Point> Tail = new List<Point>();
    static List<Point> FreeSpace = new List<Point>();
    static List<Point> Portal = new List<Point>();
    static string[] map;
    static short Score = 0;

    static short x, y;
    static Point FoodPoint = new Point();
    static Point NextPoint = new Point();

    static Timer stateTimer;
    static Random random = new Random();


    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        MapCreate();
        Thread.Sleep(1000);
        stateTimer = new Timer(Run, null, 0, 100);

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
        for (int i = 0; i < map.Length; i++)
        {
            Console.WriteLine(map[i]);
            for (int j = 0; j < map[i].Length; j++)
            {
                if ((map[i])[j] != '#' && (map[i])[j] != '|')
                {
                    FreeSpace.Add(new Point((short)j, (short)i));
                }
                if ((map[i])[j] == '|')
                {
                    Portal.Add(new Point((short)j, (short)i));
                }
            }


        }
        var freeField = FreeSpace[random.Next(0, FreeSpace.Count)];
        x = (short)freeField.X;
        y = (short)freeField.Y;

        Console.SetCursorPosition(freeField.X, freeField.Y);
        Console.Write("@");
        Food();
        Tail.Add(freeField);
        Thread.Sleep(1000);


    }
    static void CheckCord(ref short x, ref short y)
    {
        Point currentPoint = new Point(x, y);

        if (Portal.Contains(currentPoint))
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
            currentPoint = new Point(x, y);
        }
        if (!FreeSpace.Contains(currentPoint) || Tail.Contains(currentPoint))
        {
            Console.SetCursorPosition(currentPoint.X, currentPoint.Y);
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
            stateTimer.Dispose();
            Environment.Exit(0);

        }

        if (FoodPoint.X == x && FoodPoint.Y == y)
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
    static void Food()
    {
        var list = FreeSpace.Where(x => Tail.Contains(x) == false).ToList();
        list.Remove(new Point(x, y));
        var freePoint = list[random.Next(0, list.Count)];
        FoodPoint.X = (short)freePoint.X;
        FoodPoint.Y = (short)freePoint.Y;
        Console.SetCursorPosition(FoodPoint.X, FoodPoint.Y);
        Console.Write("$");
    }

}