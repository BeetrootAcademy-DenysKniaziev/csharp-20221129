namespace Lesson14.HomeWork
{
    struct Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = x;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Vector operator +(Vector a, int value)
        {
            return new Vector(a.X + value, a.Y + value, a.Z + value);
        }

        public static Vector operator -(Vector a, int value)
        {
            return new Vector(a.X - value, a.Y - value, a.Z - value);
        }

        public static bool  operator >(Vector a, Vector b)
        {
            return a.X > b.X && b.Y > b.Y && a.Z > a.Z;
        }

        public static bool operator <(Vector a, Vector b)
        {
            return a.X < b.X && b.Y < b.Y && a.Z < a.Z;

        }

        public static explicit operator double(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
        }

        public static bool IsAdjacent(Vector a, Vector b)//соприкасаются или нет
        {
            return a.X == b.X || b.Y == b.Y || a.Z == a.Z;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}, lenght: {Math.Round((double)this, 2)}";
        }
    } 

    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(3, 2, 1);

            Console.WriteLine(v1 < v2);
            Console.WriteLine(v1 > v2);
            Console.WriteLine(v1 + v2);
            Console.WriteLine(v1 - v2);
            Console.WriteLine(v1 * v2);
            Console.WriteLine(v1 / v2);
            Console.WriteLine(v1 + 4);
            Console.WriteLine(v1.ToString());

            Console.WriteLine(Vector.IsAdjacent(v1, v2));
        } 
    }
}