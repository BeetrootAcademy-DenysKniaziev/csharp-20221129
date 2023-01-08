class Program
{
    static void Main()
    {

        while (true)
        {
            int x = 0, y = 0;
            Console.WriteLine("Enter x and y to find the greatest divisor: ");
            if (!int.TryParse(Console.ReadLine(), out x)||!int.TryParse(Console.ReadLine(), out y) || x <= 0 || y <= 0)
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            Console.WriteLine($"{x} and {y} greatest common divisor \t DV1: {DivisiorV1(x, y)} \t DV2: {DivisiorV2(x, y)} \t DRec: {DivisiorRec(x, y)}\n");

            Console.WriteLine("Enter the number: ");
            if (!int.TryParse(Console.ReadLine(), out x) || x < 0)
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            Console.WriteLine($"Sum of the primes below or equal to {x} SUM = {SumOfPrimes(x)} \t SUMrec = {SumOfPrimesRec(x)}\n");
        }
    }


    static int DivisiorV1(int x, int y)
    {
        int max = 1;
        for (int i = 2; i <= Math.Max(x, y); i++)
        {
            if (i > Math.Min(x, y))
                return max;
            if (x % i == 0 && y % i == 0)
                max = i;
        }
        return max;
    }
    static int DivisiorV2(int x, int y) //Алгоритм Евкліда
    {
        int a = Math.Max(x, y);
        int b = Math.Min(x, y);
        while (a % b != 0)
        {
            (a, b) = (b, a % b);
        }
        return b;
    }
    static int DivisiorRec(int x, int y)
    {
        (x, y) = (Math.Max(x, y), Math.Min(x, y));
        if (x % y == 0)
            return y;
        else
            return DivisiorRec(x % y, y);
    }
    static int SumOfPrimes(int number)
    {
        int sum = 0;
        for (int i = 2; i <= number; i++)
            if (IsPrime(i))
                sum += i;
        return sum;
    }
    static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static int SumOfPrimesRec(int number, int from = 2)
    {
        if (from > number)
            return 0;

        if (IsPrime(from))
            return from + SumOfPrimesRec(number, from + 1);
        else
            return SumOfPrimesRec(number, from + 1);
    }
}