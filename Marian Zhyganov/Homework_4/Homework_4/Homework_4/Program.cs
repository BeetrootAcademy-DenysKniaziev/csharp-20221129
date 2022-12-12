class Program
{
    static int MaxValue(int x, int y)
    {

        return Math.Max(x, y);
    }
    static int MinValue(int x, int y)
    {
        return Math.Min(x, y);
    }

    static int MaxValue(int x, int y, int z)
    {
        return Math.Max(x, Math.Max(y, z));
    }
    static int MinValue(int x, int y, int z)
    {
        return Math.Min(x, Math.Min(y, z));
    }

    static bool TrySumIfOdd(int x, int y, out int sum)
    {
        sum = x + y;
        if (sum % 2 != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main()
    {
        string userinput;
        do
        {
            Console.Write("Please enter first number: ");
            var x = int.Parse(Console.ReadLine());
            Console.Write("Please enter second number: ");
            var y = int.Parse(Console.ReadLine());
            Console.Write("Please enter third number: ");
            var z = int.Parse(Console.ReadLine());
            var sum = x + y;

            Console.WriteLine("Task: 1. Max(two params(first|second))");
            Console.WriteLine(MaxValue(x, y));

            Console.WriteLine("Task: 2. Min(two params(first|second))");
            Console.WriteLine(MinValue(x, y));

            Console.WriteLine("Task: 3. Odd(first|second)");
            Console.WriteLine(TrySumIfOdd(x, y, out sum));

            Console.WriteLine("Task: 4. Max(three params(first|second|third))");
            Console.WriteLine(MaxValue(x, y, z));

            Console.WriteLine("Task: 4. Min(three params(first|second|third))");
            Console.WriteLine(MinValue(x, y, z));

            Console.WriteLine(" Maybe you wona stop (Y/N)");
            userinput = Console.ReadLine();

        } while (userinput != "Y");

    }
}

