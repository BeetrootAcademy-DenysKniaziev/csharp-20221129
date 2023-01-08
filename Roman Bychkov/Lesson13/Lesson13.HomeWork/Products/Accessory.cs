class Accessory : Product
{
    public override Dictionary<byte, ushort> Items { get; } = new Dictionary<byte, ushort>(1);

    public Accessory(string name, decimal price, string color, Dictionary<byte, ushort> items) : base(name, price, color)
    {
        if (items != null)
            Items.Add(1, items[1]);
    }

    //public Accessory(string name, decimal price, string color) : base(name, price, color)
    //{

    //}

    public override ushort Count(byte size = 1)
    {
        return Items[1];
    }
    public override bool AddCountToSize(ushort count, byte size = 1)
    {
        Items[1] += count;
        return true;
    }
    public override bool DeleteCountFromSize(ushort count, byte size = 1)
    {
        if (Items[1] - count >= 0)
        {
            Items[1] -= count;
            return true;
        }
        else
            return false;
    }
}