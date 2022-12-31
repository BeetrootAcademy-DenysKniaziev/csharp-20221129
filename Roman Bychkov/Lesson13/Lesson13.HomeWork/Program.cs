﻿class Program
{
    static void Main()
    {
        Console.WriteLine(float.MaxValue);
    }
}

class Clothing : Product
{
    Dictionary<float, uint> _items;

    Season Season { get; set; }

    public Clothing(string name, decimal price, Season season, string color) : base(name, price, color)
    {
        _items = new Dictionary<float, uint>();
        Season = season;
    }
    public void AddSize(float size, uint count = 0)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count can't be less then 0.");
        if (!_items.TryAdd(size, count))
            throw new InvalidOperationException("This size contains in the list.");
    }
    public bool RemoveSize(float size)
    {
        if (_items.ContainsKey(size))
        {
            _items.Remove(size);
            return true;
        }
        return false;
    }
    public bool AddCountToSize(float size, uint count)
    {
        if (_items.ContainsKey(size))
        {
            _items[size] += count;
            return true;
        }
        else
            throw new InvalidOperationException("This size contains in the list.");
        return false;
    }
    public bool DeleteCountFromSize(float size, uint count)
    {
        if (_items.ContainsKey(size))
        {
            _items[size] -= count;
            return true;
        }
        else
            throw new InvalidOperationException("This size contains in the list.");
        return false;
    }
}
abstract class Bag : Product
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
enum Season : short
{
    Winter = 1,
    Spring,
    Summer,
    Autumn
}



