class Detail
{
    public virtual void Material()
    {
        Console.WriteLine("Detail's material:\n");
    }
}

interface IBuyable
{
    public bool IsAvailable { get; }
    void Buy();
}


class Engine : Detail, IBuyable
{
    public string _material;
    public string _volume;
    public string _weight;

    public string Volume
    {
        get => $"Volume of the Engine is {_volume} liters.";
        set => _volume = value;
    }
    public string Weight
    {
        get => $"Weight of the Engine is {_weight} kg.";
        set => _weight = value;
    }

    public override void Material()
    {

        Console.WriteLine($"Engine's material is {_material}");
    }
    public bool IsAvailable => false;
    public void Buy()
    {
        Console.WriteLine($"Availability to buy: {IsAvailable}");
    }
}

class Wheel : Detail, IBuyable
{
    string _radius;
    public string Radius
    {
        get => $"Radius of the Wheel is {_radius} inch.";
        set => _radius = value;
    }
    public string _material;

    public override void Material()
    {
        Console.WriteLine($"Wheel's material is {_material}");
    }
    
    
    public bool IsAvailable => true;
    public void Buy()
    {
        Console.WriteLine($"Availability to buy: {IsAvailable}");
    }
}

class Seats : Detail, IBuyable
{
    public string _amountOfSeats;
    public string _material;
    public override void Material()
    {
        Console.WriteLine($"Seat's material is {_material}");
    }
    public string AmountOfSeats
    {
        get => $"Amount of seats is {_amountOfSeats}";
        set => _amountOfSeats = value;
    }
    public bool IsAvailable => true;
    public void Buy()
    {
        Console.WriteLine($"Availability to buy: {IsAvailable}");
    }
}

class Vehicle
{
    public string Name { get; set; }
    public Engine Engine { get; set; }
    public Wheel Wheel { get; set; }
    public Seats Seats { get; set; }
}


class Program
{
    static void Main()
    {
        Vehicle v1 = new Vehicle
        {
            Name = "Ford",
            Engine = new Engine()
            {
                Volume = "3",
                Weight = "3000",
                _material = "Steel",

            },
            Wheel = new Wheel()
            {
                Radius = "22",
                _material = "Gum",
            },
            Seats = new Seats()
            {
                AmountOfSeats = "4",
                _material = "Leather"
            },

        };
        Detail detail = new Detail();
        Detail Engine = new Engine();
        Detail Wheel = new Wheel();
        Detail Seats = new Seats();

        detail.Material();
        Engine.Material();
        Wheel.Material();
        Seats.Material();

        Seats s = new Seats();
        Engine e = new Engine();
        Console.WriteLine(e.Volume);
        s._material = "Leather";
        Console.WriteLine(v1.Seats._amountOfSeats);
        Console.WriteLine(v1.Engine.Weight);
    }
}