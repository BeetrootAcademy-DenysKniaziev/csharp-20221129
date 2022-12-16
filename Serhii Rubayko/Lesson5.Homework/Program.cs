class Program
{

    static int Factorial(int n)
    {
        var result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static int FactorialRec(int n)
    {
        if (n <= 1)
            return 1;

        return n * FactorialRec(n - 1);
    }

    static int Fibonachi(int n)
    {
        if (n == 0 || n == 1) return n;

        return Fibonachi(n - 1) + Fibonachi(n - 2);
    }

    static int GreatestCommonDivisor(int x, int y)
    {

        for (int i=0; )
        
        
        //if (x == 1 || y == 1) return 1;
        //else if (x%2==0&&y%2==0)
        //   return 2; 
            
        //    return 1;
        //else return 2;

    }




    static void Main()
    {

        var x = 4;
        var y = 2;

        Console.WriteLine($"Greater common divisor {x} & {y} is {GreatestCommonDivisor(x, y)}");

    
    
    
    
    }













}