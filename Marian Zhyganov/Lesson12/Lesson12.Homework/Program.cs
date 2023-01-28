using System.Reflection;



public class Detail
{

    public string NameDetail { get; set; }

    public virtual void Charact()
    {
        Console.WriteLine($"Name Deatail: ");
    }
}

public class Wheel : Detail
{
    public string NameDetail { get; set; }
    private string _wheelSize { get; set; }
    public string WheelSize
    {
        get => _wheelSize;
        set => _wheelSize = value;
    }

    public override void Charact()
    {
        Console.WriteLine($"Name Deatail: {NameDetail}  size {_wheelSize}");
    }
}
public class Disk : Detail
{
    public string NameDetail { get; set; }
    private string _diskSize { get; set; }
    public string DiskSize
    {
        get => _diskSize;
        set => _diskSize = value;
    }

    public override void Charact()
    {
        Console.WriteLine($"Name Deatail: {NameDetail}  size {_diskSize}");
    }
}

public class Engine : Detail
{

    public string NameDetail { get; set; }
    private string _volume { get; set; }
    public string Volume
    {
        get => _volume;
        set => _volume = value;
    }
    public virtual void Charact()
    {
        Console.WriteLine($"Name Deatail: {NameDetail} volume {_volume}");
    }
}

public class Car
{
    public string Model { get; set; }
    public Wheel Wheel { get; set; }
    public Disk Disk { get; set; }
    public Engine Engine { get; set; }

    public virtual void Charact()
    {
        Console.WriteLine($"Name Car: {Model}  ");
    }
}


class Program
{
    static void Main()
    {

        var c1 = new Car()
        {
            Model = "BMW",
        };
        var w1 = new Wheel()
        {
            NameDetail = "Wheel",
            WheelSize = "14"
        };
        var d1 = new Disk()
        {
            NameDetail = "Disk",
            DiskSize = "14"
        };
        var e1 = new Engine()
        {
            NameDetail = "Engine",
            Volume = "v8"
        };

        c1.Charact();
        w1.Charact();
        d1.Charact();
        e1.Charact();

    }
}