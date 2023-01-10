namespace Lesson14.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Target target = new Target();
            Console.WriteLine($"Target X: {target.Position.X}  Target Y: {target.Position.Y}");

            Vector newposition = target.Position;
            newposition.X = 10;
            newposition.Y = 25;
            target.Position = newposition;
            Console.WriteLine($"Target X: {target.Position.X}  Target Y: {target.Position.Y}");


            Vector v1 = new Vector(10, 25);
            Vector v2 = new Vector(5, 20);

            var sum = v1 + v2;
            Console.WriteLine(sum.Value);

            bool boo = v1 < v2;
            Console.WriteLine(boo);
            boo = v1 > v2;
            Console.WriteLine(boo);

            sum = v1 + 6;
            Console.WriteLine(sum.Value);
        }
    }


    class Target
    {
        public Vector Position { get; set; }
    }

    struct Vector
    {
        public int Value = 0;

        public int X, Y;

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector { Value = a.X + b.X + a.Y + b.Y };
        }

        public static bool operator >(Vector a, Vector b)
        {
            return a.X + a.Y > b.X + b.Y;
        }
        public static bool operator <(Vector a, Vector b)
        {
            return a.X + a.Y < b.X + b.Y;
        }

        public static Vector operator +(Vector a, int val)
        {
            return new Vector { Value = a.X + a.Y + val };
        }
    }
}