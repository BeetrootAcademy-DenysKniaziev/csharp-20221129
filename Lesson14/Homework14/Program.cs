using System.Data.Common;
using System.Drawing;

namespace Homework14;

public struct Point : IEquatable<Point>
{
    int _x, _y;
    //bool _isChecked;
    public int Level { get; set; }
    public int X { get { return _x; } set { _x = value; } }
    public int Y { get { return _y; } set { _y = value; } }
    public Color PColor { get; set; }

    public static bool operator ==(Point p1, Point p2)
    {
        decimal rDiv, gDiv, bDiv;
        rDiv = Math.Abs(p1[0] - p2[0]);
        gDiv = Math.Abs(p1[1] - p2[1]);
        bDiv = Math.Abs(p1[2] - p2[2]);
        if (rDiv + gDiv + bDiv > 60) return false;
        return true;
    }
    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    public bool Equals(Point other)
    {
        return this == other;
    }

    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => PColor.R,
                1 => PColor.G,
                2 => PColor.B,
                3 => PColor.A,
                _ => throw new InvalidOperationException("No atribute of this type"),
            };

        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {

        Console.SetWindowSize(200, 60);
        Picture Pic1 = new(), Pic2 = new(), Pic3 = new();
        Pic1.LoadBitmap(AppDomain.CurrentDomain.BaseDirectory + "sword1s.jfif");
        Console.WriteLine(Pic1.ToString());

        Pic2.LoadBitmap(AppDomain.CurrentDomain.BaseDirectory + "bow2.jfif");
        Console.WriteLine(Pic2.ToString());

        Pic3.LoadBitmap("drag3.jfif");
        Console.WriteLine(Pic3.ToString());
    }
}