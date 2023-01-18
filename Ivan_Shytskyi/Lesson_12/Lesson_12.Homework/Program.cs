class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }
    public virtual void Profesion()
    {
        Console.WriteLine();
    }
}
class Employer : Person
{
    public Employer(string first, string last) : base(first, last) { }
    public override void Profesion()
    {
        Console.WriteLine("I'm a manager");
    }
    public void HowLongToRepair()
    {
        Console.WriteLine($"one weeks");
    }
}
class Employee : Person, Inspection
{
    public Employee(string first, string last) : base(first, last) { }
    public override void Profesion()
    {
        Console.WriteLine($"I'm a mechanic");
    }
    public void InspectionOfTheCar()
    {
        Console.WriteLine($"This car is broken");
    }
}
class Servis
{
    public string ServisName { get; set; }
    public int Rating { get; set; }
    public Person Employer { get; set; }
    public Person Employee { get; set; }

    public Servis(string servisName, int rating, Person employer, Person employee)
    {
        ServisName = servisName;
        Rating = rating;
        Employer = employer;
        Employee = employee;
    }
    public void OpenOrClose()
    {
        DateTime dt = new DateTime();
        dt = DateTime.Now;
        TimeOnly t = new TimeOnly(9, 0);
        TimeOnly t1 = new TimeOnly(17, 0);
        TimeOnly t0 = new TimeOnly();
        t0 = TimeOnly.FromDateTime(dt);
        Console.WriteLine($"Time work Servis: {t} - {t1}");
        if (t0 > t && t0 < t1)
            Console.WriteLine("Servis is open");
        else
            Console.WriteLine("Servis is close");
    }
}
abstract class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public abstract void Broken();
}
class Engine : Vehicle
{
    public override void Broken()
    {
        Console.WriteLine("Yes, this engine is broken");
    }
}
class Wheel : Vehicle
{
    public override void Broken()
    {
        Console.WriteLine("Yes, this wheel is broken");
    }
}
public interface Inspection
{
    public void InspectionOfTheCar();
}
