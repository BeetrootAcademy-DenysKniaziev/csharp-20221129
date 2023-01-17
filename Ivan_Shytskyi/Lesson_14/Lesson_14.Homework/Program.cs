namespace Lesson_14.Homework
{
    struct FallTime : IEquatable<FallTime>
    {
        public const double G = 9.8;
        public double Time { get; set; }
        public FallTime(double h)
        {
            Time = Math.Sqrt((2 * h) / G);
        }
        public override bool Equals(object obj)
        {
            if (obj is FallTime fallTime)
                return Equals(fallTime);
            else
                return base.Equals(obj);
        }
        public bool Equals(FallTime other)
        {
            return this == other;
        }
        public static bool operator ==(FallTime a, FallTime b)
        {
            return a.Time == b.Time;
        }
        public static bool operator !=(FallTime a, FallTime b)
        {
            return a.Time != b.Time;
        }
        public static double operator +(FallTime a, FallTime b)
        {
            return new FallTime(a.Time + b.Time);
        }
        public static double operator -(FallTime a, FallTime b)
        {
            return a.Time - b.Time;
        }
        public static implicit operator double(FallTime fallTime)
        {
            return fallTime.Time;
        }
        public override string ToString()
        {
            return $"{Time:f4}";
        }
        public static double operator *(FallTime a, FallTime b)
        {
            return a.Time * b.Time;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FallTime ft1 = new FallTime(10.5);
            FallTime ft2 = new FallTime(20);
            FallTime ft3 = new FallTime(10.5);
            var eq = ft1.Equals(ft3);
            Console.WriteLine(eq);
            var eq1 = (ft1 == ft2);
            Console.WriteLine(eq1);
            var p = ft1 * ft2;
            Console.WriteLine($"{ft1} * {ft2} = {p:f4}");
        }
    }
}