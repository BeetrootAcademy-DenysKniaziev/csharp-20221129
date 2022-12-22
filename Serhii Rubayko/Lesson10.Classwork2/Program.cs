class Location
{
    public double X { get; set;}

    public double Y { get; set;}    


}






class Galaxy
{
    public string Name { get; set; }

    public Location Location { get; set; }

    public void Collapse()
    {
        Console.WriteLine($"Galaxy{Name} has been collapsed");
    }
}




class Planet
{
    public string Name { get; set; }

    public string Description { get; set; }

    public double Temperature { get; set; }

    public double Gravity { get; set; }

    public int LocalYear { get; set; }

    public Galaxy Galaxy { get; set; }

    public Planet ParentPlanet { get; set; }

    public void PassOneYear ()
    {
        LocalYear++;

    }
}


