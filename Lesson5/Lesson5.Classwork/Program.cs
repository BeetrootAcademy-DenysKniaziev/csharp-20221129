
class Program
{

    static void PrintHello()
    {
        Console.WriteLine("Hello");
    }

    static void PrintHello(string name)
    {
        Console.WriteLine($"Heloo, {name}");
    }

    static void Main()
    {
        PrintHello();
        PrintHello("Piter");
    }
}