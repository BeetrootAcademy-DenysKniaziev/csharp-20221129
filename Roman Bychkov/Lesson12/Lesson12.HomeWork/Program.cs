class Program
{
    static void Main()
    {

    }
}
class Part
{
    int _count;
    double _weight;
    decimal _price;
    public decimal Price
    {
        get => _price; set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value can't be less than 0");
            _price = value;
        }
    }
    public string Model { get; set; }
    public double Weight
    {
        get => _weight; set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value can't be less than 0");
            _weight = value;
        }
    }

    public int Count
    {
        get => _count; set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Value can't be less than 0");
            _count = value;
        }
    }

    public bool Sale(int count)
    {
        if (Count < count)
            return false;
        Count -= count;
        return true;
    }
    public void Add(int count)
    {
        if (count < 0)
            throw new ArgumentException("Count can't be less than 0.");
        Count++;
    }
    protected Part(string name, decimal price, int count, double weight)
    {
        Model = name;
        Weight = weight;
        Price = price;
        Count = count;
    }
}

class Stock
{
    public Part[] Parts { get; set; }
    public Stock()
    {
        Parts = new Part[0];
    }
}

class Wheel : Part
{
    double _radius;
    public double Radius
    {
        get => _radius;
        set
        {
            if (value < 0)
                throw new ArgumentException("Radius can't be less than 0.");
            _radius = value;
        }
    }
    public Wheel(string name, decimal price, int count, double weight, double radius) : base(name, price, count, weight)
    {
        Radius = radius;
    }
}
class Engine : Part
{
    double _compression, _power;
    public double Compression
    {
        get => _compression;
        set
        {
            if (value < 0)
                throw new ArgumentException("Compression can't be less than 0.");
            _compression = value;
        }
    }
    public double Power
    {
        get => _power;
        set
        {
            if (value < 0)
                throw new ArgumentException("Power can't be less than 0.");
            _power = value;
        }
    }
    public Engine(string name, decimal price, int count, double weight, double compression, double power) : base(name, price, count, weight)
    { 
        Compression = compression;
        Power = power;
    }
}
class FuelTank: Part
{
    double _volume;
    public double Volume
    {
        get => _volume;
        set
        {
            if (value < 0)
                throw new ArgumentException("Volume can't be less than 0.");
            _volume = value;
        }
    }
    public FuelTank(string name, decimal price, int count, double weight, double volume) : base(name, price, count, weight)
    { 
        Volume = volume;
    }
}
