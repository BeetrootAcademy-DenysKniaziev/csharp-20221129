
class Program
{
    //Finding Greatest Common Division

    // Common method 
    static int GreComDiv(int x, int y)
    {
        if (x==0) return y;
        while (y != 0)
        {
            int tmp1;
            if (x > y)
            {
                tmp1 = x % y;
            }
            else
            {
                tmp1 = y % x;
            }
            x = y;
            y = tmp1;
        }
        return x;

    }
    // Recursive method
    static int GreComDivRec(int x, int y)
    {
        if (y == 0) return x;
        return GreComDivRec(y, x % y);
    }

    //Finding Sum of all the primes below or equal to number

    // Is it Prime nuber checking
    static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // Common method 
    static int PrimeNumSum(int z)
    {
        int result = 2;
        for (int tmp = 3; tmp <= z; tmp++)
        {
           if (!IsPrime(tmp)) continue;
               result += tmp;
        }

        return result;
    }
    // Recursive method
    static int PrimeSumRec(int z)
    {
        if (z<=2) return z;
        for (int i=2; i<z; i++)
        {
          if (z % i == 0)
             return PrimeSumRec(z - 1);
        }
        return z+PrimeSumRec(z-1);
    }

    static void Main()
    {
        var x = 154;
        var y = 81;
        var z = 100;

        Console.WriteLine($"Greater common divisor {x} & {y} is " +
            $"{GreComDiv(x, y)} - from common meth  ({GreComDivRec(x, y)} - from recurs meth)");

        Console.WriteLine();
             
        Console.WriteLine($"Sum of all the primes below or equal {z} is" +
            $" {PrimeNumSum(z)} - from common meth  ({PrimeSumRec(z)} - from recurs meth)");
    }
}