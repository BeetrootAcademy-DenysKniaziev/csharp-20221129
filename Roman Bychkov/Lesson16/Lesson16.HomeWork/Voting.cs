using System.Collections;

internal class Voting : IVote, IEnumerable<KeyValuePair<Option, int>>
{
    private Dictionary<Option, int> _options;
    public string Name { get; set; }
    public DateTime DateOfCreate { get; }
    public Voting(string name, DateTime? dayOfCreate)
    {
        Name = name;
        DateOfCreate = dayOfCreate is null ? DateTime.Today : dayOfCreate.Value;
        _options = new Dictionary<Option, int>();
    }
    public void AddOption(string name)
    {
        if (!_options.ContainsKey(new Option(name)))
            _options.Add(new Option(name), 0);
        else
            Console.WriteLine("This option already exist.");
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
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, DateOfCreate.Year, DateOfCreate.Month, DateOfCreate.Day);
    }
    public override bool Equals(object? obj)
    {
        if (obj is Voting ob)
            return ob.Name == Name && ob.DateOfCreate.Year == DateOfCreate.Year
                && ob.DateOfCreate.Month == DateOfCreate.Month && ob.DateOfCreate.Day == DateOfCreate.Day;
        return false;
    }
}
struct Option
{
    //Can be more fields
    private string _name;
    public Option(string name)
    {
        _name = name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(_name);
    }
    public override bool Equals(object? obj)
    {
        if (obj is Option ob)
            return ob._name == _name;
        return false;
    }
    public override string ToString()
    {
        return _name;
    }
}