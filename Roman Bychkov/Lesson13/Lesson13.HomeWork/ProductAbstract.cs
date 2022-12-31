abstract class Product
{
    protected decimal _price;

    public string Name { get; set; }
    public string Color { get; set; }

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
}