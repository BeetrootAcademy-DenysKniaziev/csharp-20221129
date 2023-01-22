class Location
{
    public string County { get; set; }
    public string City { get; set; }
    public string NameStreet { get; set; }
    public string NumberStreet { get; set; }



}
class Library : Location
{
    public string LibraryName { get; set; }
    public Location Location { get; set; }
    public void infoAboutLibrary()
    {
        Console.WriteLine($"" +
            $"Name: {LibraryName}" +
            $"Contry: {County}" +
            $"City: {City}" +
            $"Name Street: {NameStreet}" +
            $"Nuber Street: {NumberStreet}");
    }
}
class Subject
{
    public string SubjectName { get; set; }
}
class Book : Subject
{
    public string BookName { get; set; }
    public string Autor { get; set; }
    public string NumberOfPage { get; set; }
    public Subject Subject { get; set; }

    public void infoAboutBook()
    {
        Console.WriteLine($"" +
            $"Book title: {BookName}\n" +
            $"Book autor: {Autor}\n" +
            $"Volume of the book: {NumberOfPage} page\n" +
            $"The subject of the book : {SubjectName}");
    }


}


class Program
{
    static void Main()
    {
        var l_1 = new Library
        {
            LibraryName = "Some Library :)\n",

            County = "USA\n",
            City = "New York\n",
            NameStreet = "Times Square\n",
            NumberStreet = "7/3"

        };
        var b_1 = new Book
        {
            BookName = "Project Ukraine. Famous stories of our state",
            Autor = "Danylo Yanevskyi",
            NumberOfPage = "287",
            SubjectName = "History"
        };

        l_1.infoAboutLibrary(); 
        b_1.infoAboutBook();

        Console.ReadKey();
    }
}