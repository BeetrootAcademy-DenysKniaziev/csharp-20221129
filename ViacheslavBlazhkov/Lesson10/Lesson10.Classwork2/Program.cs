class Location
{
    public double X { get; set; }
    public double Y { get; set; }
}

class Galaxy
{
    public string Name { get; set; }

    public string Description { get; set; }

    public Location Location { get; set; }

    public void Collapse()
    {
        Console.WriteLine($"Galaxy {Name} has been collapsed");
    }
}

class Planet
{
    public string Name { get; set; }

    public double Temperature { get; set; }

    public double Gravity { get; set; }

    public int LocalYear { get; set; }

    public Galaxy Galaxy { get; set; }

    public Planet ParentPlanet { get; set; }

    public void PassOneYear()
    {
        LocalYear++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var g1 = new Galaxy
        {
            Name = "G1",
            Description = "G1 GALAXY",
            Location = new Location
            {
                X = 100,
                Y = 400
            }
        };

        var p1 = new Planet
        {
            Name = "Earth",
            Gravity = 10,
            LocalYear = 2022,
            Temperature = 21,
            Galaxy = g1
        };

        var p2 = new Planet
        {
            Name = "Moon",
            Gravity = p1.Gravity / 6,
            LocalYear = p1.LocalYear * 100,
            Temperature = -30,
            Galaxy = g1,
            ParentPlanet = p1
        };

        p1.PassOneYear();
        g1.Collapse();
    }
}