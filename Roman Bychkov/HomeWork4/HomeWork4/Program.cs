class Program
{
    static void Main()
    {
        int x1 = 0, x2 = 0, x3 = 0, x4=0, sum;

        Console.WriteLine("TrySumIfOdd: enter the value of x1 and x2");
        if (!int.TryParse(Console.ReadLine(), out x1) || !int.TryParse(Console.ReadLine(), out x2))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        Console.WriteLine($"TrySumIfOdd: {TrySumIfOdd(x1,x2,out sum)} Sum: {sum}");

        Console.WriteLine("TrySumIfOdd: enter the value of x1, x2, x3, x4");
        if (!int.TryParse(Console.ReadLine(), out x1) || !int.TryParse(Console.ReadLine(), out x2) || !int.TryParse(Console.ReadLine(), out x3) || !int.TryParse(Console.ReadLine(), out x4))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        Console.WriteLine($"MaxBetween first 2 paramatres: {MaxBetween(x1,x2)}");
        Console.WriteLine($"MaxBetween first 3 paramatres: {MaxBetween(x1, x2, x3)}");
        Console.WriteLine($"MaxBetween first 4 paramatres: {MaxBetween(x1, x2, x3, x4)}");

        Console.WriteLine($"MinBetween first 2 paramatres: {MinBetween(x1, x2)}");
        Console.WriteLine($"MinBetween first 3 paramatres: {MinBetween(x1, x2, x3)}");
        Console.WriteLine($"MinBetween first 4 paramatres: {MinBetween(x1, x2, x3, x4)}");


        Console.WriteLine("\nRepeat:");
        Console.WriteLine(Repeat("Three", 3));
        Console.WriteLine(Repeat("One", 1));
        Console.WriteLine(Repeat("Zero", 0));
        Console.WriteLine(Repeat("Negative", -1));
        Console.WriteLine(Repeat("Ten", 10));





    }
    #region MaxBetween
    static int MaxBetween(int x1, int x2)
    {
        return Math.Max(x1, x2);
    }
    static int MaxBetween(int x1, int x2, int x3)
    {
        return MaxBetween(Math.Max(x1,x2),x3);
    }

    static int MaxBetween(int x1, int x2, int x3, int x4)
    {
        return MaxBetween(Math.Max(x1, x2), x3, x4);
    }
    #endregion

    #region MinBetween
    static int MinBetween(int x1, int x2)
    {
        return Math.Min(x1, x2);
    }
    static int MinBetween(int x1, int x2, int x3)
    {
        return MinBetween(Math.Min(x1, x2), x3);
    }

    static int MinBetween(int x1, int x2, int x3, int x4)
    {
        return MinBetween(Math.Min(x1, x2), x3, x4);
    }
    #endregion

    static bool TrySumIfOdd(int x1, int x2, out int sum)
    {
        sum = x1 + x2;
        return sum%2!=0?true:false;
    }   

    static string Repeat (string X, int N)
    {
        if(N<1)
            return "";
        return X+Repeat(X, N-1);
    }
}