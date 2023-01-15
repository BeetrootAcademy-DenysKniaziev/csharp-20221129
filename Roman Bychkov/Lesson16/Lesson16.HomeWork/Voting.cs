using System.Collections;

internal class Voting : IVote, IEnumerable<KeyValuePair<Option, int>>
{
    private Dictionary<Option, int> _options;
    public string Name { get; set; }
    public Voting(string name)
    {
        Name = name;
        _options = new Dictionary<Option, int>();
    }
    public void AddOption(string name)
    {
        _options.Add(new Option(name), 0);
    }
    public void RemoveOption(string name)
    {
        _options.Remove(new Option(name));
    }

    public void MakeVote(Option option)
    {
        if (_options.ContainsKey(option))
            _options[option]++;
    }
    public IEnumerator<KeyValuePair<Option, int>> GetEnumerator()
    {
        return _options.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
struct Option
{
    private string _name;
    private DateTime _date;

    public Option(string name)
    {
        _name = name;
        _date = DateTime.Now;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(_name, _date);
    }
    public override bool Equals(object? obj)
    {
        if (obj is Option ob)
            return ob._name == _name && ob._date == _date;
        return false;
    }
}