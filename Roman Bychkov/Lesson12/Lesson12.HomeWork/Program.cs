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
    public Part[] Parts { get; private set; }
    public decimal Balance { get; set; }
    public Stock(decimal balance = 0)
    {
        Balance = balance;
        Parts = new Part[0];
    }

    public bool Sale(Part part, int count)
    {
        if (Parts.Contains(part) && part.Count >= count)
        {
            Balance += count * part.Price;
            part.Count -= count;
            return true;
        }
        return false;
    }
    public void AddPart(Part newPart)
    {
        if (!Parts.Contains(newPart))
        {
            var newParts = new Part[Parts.Length + 1];
            Array.Copy(Parts, newParts, Parts.Length);
            Parts = newParts;
            Parts[Parts.Length - 1] = newPart;
        }
    }
}

class Wheel : Part
{
    double _radius;
    string Type { get; set; }
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
    public Wheel(string name, decimal price, int count, double weight, double radius, string type) : base(name, price, count, weight)
    {
        Radius = radius;
        Type = type;
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
class FuelTank : Part
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
