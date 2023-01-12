using System.Diagnostics.CodeAnalysis;

namespace Lesson14.Classwork
{
    struct Vector : IEquatable<Vector>
    {
        public enum Dimension
        {
            X,  
            Y
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int this[Dimension index]
        {
            get
            {
                return index switch
                {
                    Dimension.X => X,
                    Dimension.Y => Y,
                    _ => throw new IndexOutOfRangeException("Wrong index"),
                };
            }
            set
            {
                switch (index)
                {
                    case Dimension.X:
                        X = value;
                        break;
                    case Dimension.Y:
                        Y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Wrong index");
                }
            }
        }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Vector vector)
                return Equals(vector);

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            //return X.GetHashCode() ^ Y.GetHashCode() * 565635;
            var hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            return hash.ToHashCode();
        }

        public bool Equals(Vector other)
        {
            return this == other;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static explicit operator double(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector
            {
                X = 3,
                Y = 4
            };

            var v2 = new Vector(2, 7);

            Console.WriteLine(v1);
            Console.WriteLine(v2);

            var eq1 = v1 == v2;
            var eq2 = v1.Equals(v2);
            var v3 = v1 + v2;
            var v4 = v1 - v2;

            Console.WriteLine(v3);
            Console.WriteLine(v4);

            double length = (double)v1;
            Console.WriteLine("Length: " + length);

            v1[Vector.Dimension.X] = 10;
            v1[Vector.Dimension.Y] = 20;

            Console.WriteLine(v1);

            v2[Vector.Dimension.X] = 20;
            v2[Vector.Dimension.Y] = 10;

            Console.WriteLine(v1.GetHashCode() + " " + v2.GetHashCode());

        }
    }
}