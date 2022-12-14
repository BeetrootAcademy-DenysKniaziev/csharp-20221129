class Program
{
    static void Main(string[] args)
    {
        MaxValue(100, 200);
    }


    static void MaxValue(int num01, int num02)
    {
        int result = Math.Max(num01, num02);
        Console.WriteLine($"The result is {result}");
    }
}