public struct Vector2
{
    public double x, y;

    public Vector2(double x, double y)
    {
        this.x = x; this.y = y;
    }

 

    public static Vector2 operator +(Vector2 first, Vector2 second)
    {
        return new Vector2(first.x + second.x, first.y + second.y);
    }



    public static implicit operator Vector3(Vector2 v2)
    {
        return new Vector3(v2.x, v2.y, 0);
    }


    public static explicit operator Vector2(Vector3 v3)
    {
        return new Vector2(v3.x, v3.y);
    }

}

public struct Vector3
{
    public double x, y, z;

    public Vector3(double x, double y, double z)
    {
        this.x = x; this.y = y; this.z = z;
    }


    public static Vector3 operator +(Vector3 first, Vector3 second)
    {
        return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
    }

}

class Program
{
    static void Main()
    {
        var v2 = new Vector2(1, 2);
        var v3 = new Vector3(3, 4, 5);

        var res1 = v2 + v3;
  
        Console.WriteLine($"{res1.GetType().Name} : {res1.x}, {res1.y}, {res1.z}");
    }
}
