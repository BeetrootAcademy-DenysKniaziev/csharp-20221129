class Clothing : Product
{
    public override Dictionary<byte, ushort> Items { get; }

    public Clothing(string name, decimal price, string color, Dictionary<byte, ushort> items) : base(name, price, color)
    {
       Items = items ?? new Dictionary<byte, ushort>();
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
    //public bool RemoveSize(byte size)
    //{
    //    if (Items.ContainsKey(size))
    //    {
    //        Items.Remove(size);
    //        return true;
    //    }
    //    return false;
    //}
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
        if (Items.ContainsKey(size) && Items[size] - count >= 0)
        {
            Items[size] -= count;
            return true;
        }
        else
            return false;
    }
}