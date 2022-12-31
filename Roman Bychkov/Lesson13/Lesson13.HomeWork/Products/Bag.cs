class Bag : ProductAbstract
{
    public uint Count { get; set; }
    public float Volume { get; set; }
    public Bag(string name, decimal price, float volume, uint count, string color) : base(name, price, color)
    {
        Count = count;
        if (volume < 0)
            throw new ArgumentOutOfRangeException(nameof(volume), "Volume can't be less then 0");
        Volume = volume;
    }
}