class Writer
{
    public string Name { get; set; }
    public Location Location { get; set; }
}
class Location
{
    public string Country { get; set; }
    public string City { get; set; }
}
class Book
{
    public string Name { get; set; }
    public Writer NameOfWriter { get; set; }
    public int NumberOfPage { get; set; }
}
class Library
{
    public string Name { get; set; }
    public Location Location { get; set; }
    public int NumberOfBooks { get; set; }
    public Book Book { get; set; }
}
