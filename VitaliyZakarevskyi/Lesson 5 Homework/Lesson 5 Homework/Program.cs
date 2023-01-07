
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {

        
        Console.WriteLine(GCD(200, 100));
        Console.WriteLine(PrimeNumber(154));

    }

    static int GCD(int value1, int value2)
    {
        int temp = 0;
        for (int i = Math.Min(value1, value2); i > 0; i--)
        {
            if (value1 % i == 0 && value2 % i == 0)
            {
                temp = i;
                break;
                
            }
            
        }
        return temp;

    }
        static int PrimeNumber(int value1)
    {
        int sum = 0;
            for (int i = 2; i <= value1; i++)
            {
                if (value1 % i == 0)
                {
                    sum += i;
                }
                
            }
        return sum;
    }    
}