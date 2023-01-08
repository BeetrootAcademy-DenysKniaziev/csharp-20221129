
abstract class Product : ISizeCount
{
    protected decimal _price;

    public string Name { get; set; }
    public string Color { get; set; }

    public abstract Dictionary<byte, ushort> Items { get; }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value can't be less than 0");
            _price = value;
        }
    }
    public Product(string name, decimal price, string color)
    {
        Name = name;
        Price = price;
        Color = color;

    }

    public override string ToString()
    {
        return $"{Name,10}  {Color,12} {Price,5:C2}";
    }

    public abstract ushort Count(byte size = 1);
    public abstract bool AddCountToSize(ushort count, byte size = 1);

    public abstract bool DeleteCountFromSize(ushort count, byte size = 1);
}