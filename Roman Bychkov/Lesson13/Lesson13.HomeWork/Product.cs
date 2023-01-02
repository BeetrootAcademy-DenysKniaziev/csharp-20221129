abstract class Product
{
    protected decimal _price;

    public string Name { get; set; }
    public string Color { get; set; }
    public abstract ushort Count(byte size = 1);
    protected abstract Dictionary<byte, ushort> Items { get; }
    public abstract bool AddCountToSize(ushort count, byte size = 1);
    public abstract bool DeleteCountFromSize(ushort count, byte size = 1);
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
    protected Product(string name, decimal price, string color)
    {
        Name = name;
        Price = price;
        Color = color;
    }
    public override string ToString()
    {
        return $"{Name} | {Color}";
    }
}