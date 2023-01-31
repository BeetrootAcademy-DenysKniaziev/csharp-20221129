using System.Drawing;

class Snake
{

    Direction _direction = Direction.Right;
    Direction _previousDirection = Direction.Left;

    public event Action<Snake> EndGame, ReadyToStart;
    public event Action<Point, char, ConsoleColor> PrintSymbol;
    public event Action<string[]> BuildMap;

    List<Point> _tail, _freeSpace, _portal;
    Point _foodPoint, _nextPoint;
    Timer _stateTimer;
    Random _random;

    public Point NextPoint => _nextPoint;
    public bool IsAlive { get; private set; } = true;

    public string[] Map { get; private set; }
    public short Score { get; private set; } = 0;
    public ConsoleColor Color { get; private set; }
    public void DirectionSet(Direction direction)
    {
        if (direction == Direction.Right && _previousDirection == Direction.Left
            || direction == Direction.Left && _previousDirection == Direction.Right
            || direction == Direction.Up && _previousDirection == Direction.Down
            || direction == Direction.Down && _previousDirection == Direction.Up)
            return;
        _direction = direction;
    }


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
    }
    void Run(object ob)
    {
        switch (_direction)
        {
            case Direction.Left:
                _nextPoint.X--;
                break;
            case Direction.Right:
                _nextPoint.X++;
                break;
            case Direction.Up:
                _nextPoint.Y--;
                break;
            case Direction.Down:
                _nextPoint.Y++;
                break;
        }

        _previousDirection = _direction;
        CheckCord();

        if (IsAlive == false)
            return;

        PrintSymbol?.Invoke(_nextPoint, '@', ConsoleColor.Red);
        ChangeTail();
        if (_tail.Count > 1)
            PrintSymbol?.Invoke(_tail[1], '0', ConsoleColor.DarkYellow);
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
        PrintSymbol?.Invoke(_nextPoint, '@', ConsoleColor.Red);
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
            IsAlive = false;
            _stateTimer.Dispose();
            PrintSymbol?.Invoke(_tail[0], '0', ConsoleColor.DarkYellow);
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
    public enum Direction
    {
        Left = 0,
        Right,
        Up,
        Down
    }

}