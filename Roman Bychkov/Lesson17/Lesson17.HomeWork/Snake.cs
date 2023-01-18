using System.Drawing;

class Snake
{

    ConsoleKey _direction = ConsoleKey.RightArrow;
    ConsoleKey _previousDirection = ConsoleKey.LeftArrow;

    public event Action ReadyToStart;
    public event Action<Snake> EndGame;

    List<Point> _tail, _freeSpace, _portal;
    Point _foodPoint, _nextPoint;
    public Point NextPoint => _nextPoint;
    public string[] _map { get; private set; }
    short _score = 0;
    Timer _stateTimer;
    Random _random;
    ConsoleColor _color;


    public Snake(ConsoleColor color = ConsoleColor.White)
    {
        _color = color;
        _tail = new List<Point>();
        _freeSpace = new List<Point>();
        _portal = new List<Point>();
        _foodPoint = new Point();
        _nextPoint = new Point();
        _random = new Random();


    }

    public void Control()
    {
        ReadyToStart?.Invoke();
        MapCreate();
        Thread.Sleep(1000);

        _stateTimer = new Timer(Run, null, 0, 100);
        while (true)
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow when _previousDirection != ConsoleKey.RightArrow:
                    _direction = key;
                    break;
                case ConsoleKey.RightArrow when _previousDirection != ConsoleKey.LeftArrow:
                    _direction = key;
                    break;
                case ConsoleKey.UpArrow when _previousDirection != ConsoleKey.DownArrow:
                    _direction = key;
                    break;
                case ConsoleKey.DownArrow when _previousDirection != ConsoleKey.UpArrow:
                    _direction = key;
                    break;

            }
        }
    }
    void Run(object ob)
    {
        switch (_direction)
        {
            case ConsoleKey.LeftArrow:
                _nextPoint.X--;
                break;
            case ConsoleKey.RightArrow:
                _nextPoint.X++;
                break;
            case ConsoleKey.UpArrow:
                _nextPoint.Y--;
                break;
            case ConsoleKey.DownArrow:
                _nextPoint.Y++;
                break;

        }

        _previousDirection = _direction;
        CheckCord();

        Console.SetCursorPosition(_nextPoint.X, _nextPoint.Y);
        Console.Write("@");
        ChangeTail();

        _tail[0] = _nextPoint;
    }
    void ChangeTail()
    {
        for (int i = _tail.Count - 1; i > 0; i--)
        {
            Point temp = _tail[i - 1];
            _tail[i] = temp;
        }
        return;

    }
    void MapCreate()
    {
        Console.SetCursorPosition(0, 0);
        _map = new string[0];
        if (File.Exists("map.txt"))
            _map = File.ReadAllLines("map.txt");
        else
        {
            Console.WriteLine("Need map for start. Download: https://drive.google.com/drive/folders/1ahSweS9oAEXnJmbTU7F0NLZ-lebJ7LRF?usp=share_link");
            Environment.Exit(1);
        }
        for (int i = 0; i < _map.Length; i++)
        {
            Console.WriteLine(_map[i]);
            for (int j = 0; j < _map[i].Length; j++)
            {
                if ((_map[i])[j] != '#' && (_map[i])[j] != '|')
                {
                    _freeSpace.Add(new Point((short)j, (short)i));
                }
                if ((_map[i])[j] == '|')
                {
                    _portal.Add(new Point((short)j, (short)i));
                }
            }


        }
        Console.SetWindowSize(_map[0].Length + 2, _map.Length + 2);
        _nextPoint = _freeSpace[_random.Next(0, _freeSpace.Count)];

        Console.SetCursorPosition(_nextPoint.X, _nextPoint.Y);
        Console.Write("@");
        Food();
        _tail.Add(_nextPoint);
    }
    void CheckCord()
    {
        if (_portal.Contains(_nextPoint))
        {

            if (_nextPoint.Y == 0)
            {
                _nextPoint.Y = (short)(_map.Count() - 2);
            }
            if (_nextPoint.Y == _map.Count() - 1)
            {
                _nextPoint.Y = 1;
            }
            if (_nextPoint.X == 0)
            {
                _nextPoint.X = (short)(_map[0].Count() - 2);
            }
            if (_nextPoint.X == _map[0].Count() - 1)
            {
                _nextPoint.X = 1;
            }

        }
        if (!_freeSpace.Contains(_nextPoint) || _tail.Contains(_nextPoint))
        {
            EndGame?.Invoke(this);
            _stateTimer.Dispose();
            return;

            //Console.SetCursorPosition(_nextPoint.X, _nextPoint.Y);
            //Console.Write("█");

            //Console.Clear();
            //string[] end;
            //if (File.Exists("end.txt"))
            //{
            //    end = File.ReadAllLines("end.txt");
            //    foreach (string s in end)
            //        Console.WriteLine(s);
            //}
            //else
            //    Console.WriteLine("Game is over!");
            //Console.WriteLine($"Your score: {_score}");

            //Environment.Exit(0);

        }

        if (_foodPoint == _nextPoint)
        {
            _tail.Add(new Point());
            _score++;
            Food();
        }
        else
        {
            Console.SetCursorPosition(_tail[_tail.Count - 1].X, _tail[_tail.Count - 1].Y);
            Console.Write(" ");
        }


    }
    void Food()
    {
        var list = _freeSpace.Where(x => _tail.Contains(x) == false).ToList();
        list.Remove(_nextPoint);
        _foodPoint = list[_random.Next(0, list.Count)];
        Console.SetCursorPosition(_foodPoint.X, _foodPoint.Y);
        Console.Write("$");
    }

}