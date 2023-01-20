using System.Drawing;

class Snake
{
    public string[] Map { get; private set; }
    public short Score { get; private set; } = 0;
    public ConsoleColor Color { get; private set; }
    public Point NextPoint => _nextPoint;

    ConsoleKey _direction = ConsoleKey.RightArrow;
    ConsoleKey _previousDirection = ConsoleKey.LeftArrow;

    public event Action<Snake> EndGame, ReadyToStart;
    public event Action<Point, char, ConsoleColor> PrintSymbol;
    public event Action<string[]> BuildMap;

    List<Point> _tail, _freeSpace, _portal;
    Point _foodPoint, _nextPoint;


    Timer _stateTimer;
    Random _random;

    bool _flag = true;


    public Snake(string mapDirection, ConsoleColor color = ConsoleColor.White)
    {
        Color = color;
        _tail = new List<Point>();
        _freeSpace = new List<Point>();
        _portal = new List<Point>();
        _foodPoint = new Point();
        _nextPoint = new Point();
        _random = new Random();

        Map = new string[0];
        if (File.Exists(mapDirection))
            Map = File.ReadAllLines(mapDirection);
        else
        {
            throw new Exception("Need map for start. Download: https://drive.google.com/drive/folders/137hROhQ4ymiy7wVu9EAMYV0CBLPp9o53?usp=share_link");
        }

    }

    public void Start()
    {
        ReadyToStart?.Invoke(this);
        CreateMap();
        Thread.Sleep(1000);

        _stateTimer = new Timer(Run, this, 0, 100);
        while (_flag)
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
        if (_flag == false)
            return;
        PrintSymbol?.Invoke(NextPoint, '@', ConsoleColor.Red);
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
    void CreateMap()
    {
        BuildMap?.Invoke(Map);
        for (int i = 0; i < Map.Length; i++)
        {

            for (int j = 0; j < Map[i].Length; j++)
            {
                if ((Map[i])[j] != '#' && (Map[i])[j] != '|')
                {
                    _freeSpace.Add(new Point((short)j, (short)i));
                }
                if ((Map[i])[j] == '|')
                {
                    _portal.Add(new Point((short)j, (short)i));
                }
            }
        }

        _nextPoint = _freeSpace[_random.Next(0, _freeSpace.Count)];
        PrintSymbol?.Invoke(NextPoint, '@', ConsoleColor.Red);
        Food();
        _tail.Add(_nextPoint);
    }
    void CheckCord()
    {
        if (_portal.Contains(_nextPoint))
        {

            if (_nextPoint.Y == 0)
            {
                _nextPoint.Y = (short)(Map.Count() - 2);
            }
            if (_nextPoint.Y == Map.Count() - 1)
            {
                _nextPoint.Y = 1;
            }
            if (_nextPoint.X == 0)
            {
                _nextPoint.X = (short)(Map[0].Count() - 2);
            }
            if (_nextPoint.X == Map[0].Count() - 1)
            {
                _nextPoint.X = 1;
            }

        }
        if (_foodPoint == _nextPoint)
        {
            _tail.Add(new Point());
            Score++;
            Food();
        }
        else
        {
            PrintSymbol?.Invoke(_tail[_tail.Count - 1], ' ', Color);
            _tail[_tail.Count - 1] = new Point(0, 0);
        }
        if (!_freeSpace.Contains(_nextPoint) || _tail.Contains(_nextPoint))
        {
            _flag = false;
            _stateTimer.Dispose();
            EndGame?.Invoke(this);
        }


    }
    void Food()
    {
        var list = _freeSpace.Where(x => _tail.Contains(x) == false).ToList();
        list.Remove(_nextPoint);
        _foodPoint = list[_random.Next(0, list.Count)];
        PrintSymbol?.Invoke(_foodPoint, '$', ConsoleColor.Green);

    }

}