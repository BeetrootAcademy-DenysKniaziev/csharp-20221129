class Clothing : Product
{
    protected override Dictionary<byte, ushort> Items { get; } = new Dictionary<byte, ushort>();

    Season Season { get; set; }

    public Clothing(string name, decimal price, Season season, string color) : base(name, price, color)
    {
        Season = season;
    }
    public override ushort Count(byte size)
    {
        if (!Items.ContainsKey(size))
            return 0;
        return Items[size];
    }
    public bool AddSize(byte size, ushort count = 0)
    {
        if (!Items.TryAdd(size, count))
            return false;
        return true;
    }
    public bool RemoveSize(byte size)
    {
        if (Items.ContainsKey(size))
        {
            Items.Remove(size);
            return true;
        }
        return false;
    }
    public override bool AddCountToSize(ushort count, byte size)
    {
        if (Items.ContainsKey(size))
        {
            Items[size] += count;
            return true;
        }
        else
            return false;

    }
    public override bool DeleteCountFromSize(ushort count, byte size)
    {
        if (Items.ContainsKey(size) && Items[size] - count > 0)
        {
            Items[size] -= count;
            return true;
        }
        else
            return false;
    }
}