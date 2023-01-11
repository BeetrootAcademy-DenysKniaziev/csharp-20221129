class Program
{
    static void Main()
    {
        var t1 = new Timer(60, 500, 30);
        Console.WriteLine(t1.ToString());

        var t2 = new Timer(10, 10, 33);
        Console.WriteLine(t2.ToString());

        Timer t4 = t2 - t1;
        Console.WriteLine(t4.ToString());


        int seconds = new Timer();
        t2 = seconds;
        Console.WriteLine($"{seconds} seconds {t2.ToString()}");

        Timer t3 = new Timer() with { Hours = 10 };


        Console.WriteLine(t3.ToString());

        Console.WriteLine(new Timer() >= new Timer() { Seconds = 55 });


    }

    struct Timer
    {
        public int _seconds = 0, _minutes = 0, _hours = 0;
        public int Seconds
        {
            get => _seconds;
            set
            {
                Minutes += value / 60;
                _seconds = value % 60;
            }
        }
        public int Minutes
        {
            get => _minutes;
            set
            {
                Hours += value / 60;
                _minutes = value % 60;
            }
        }
        public int Hours { get => _hours; set => _hours = value; }

        public Timer(int seconds, int minutes, int hours)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        public Timer() : this(DateTime.Now.Second, DateTime.Now.Minute, DateTime.Now.Hour)
        {
        }

        public static Timer operator +(Timer p1, Timer p2)
        {
            return new Timer(p1.Seconds + p2.Seconds, p1.Minutes + p2.Minutes, p1.Hours + p2.Hours);
        }
        public static Timer operator -(Timer p1, Timer p2)
        {
            int a = p1, b = p2;
            return a - b;
        }
        public static bool operator >(Timer p1, Timer p2)
        {
            int a = p1, b = p2;
            return a > b;
        }
        public static bool operator <(Timer p1, Timer p2)
        {
            int a = p1, b = p2;
            return a < b;
        }
        public static bool operator ==(Timer p1, Timer p2)
        {
            int a = p1, b = p2;
            return a == b;
        }
        public static bool operator !=(Timer p1, Timer p2)
        {
            int a = p1, b = p2;
            return a != b;
        }




        public static implicit operator int(Timer t)
        {
            return t.Seconds + t.Minutes * 60 + t.Hours * 3600;
        }
        public static implicit operator Timer(int seconds)
        {
            return new Timer(seconds % 60, seconds / 60 % 60, seconds / 3600);
        }


        public override string ToString()
        {
            return $"Hours: {Hours} Minutes: {Minutes} Seconds: {Seconds}";
        }
    }
}