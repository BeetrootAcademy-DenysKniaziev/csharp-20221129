class Program
{
    static int Maximum(int a, int b) => Math.Max(a, b);
     
    static int Maximum(int a, int b, int c)=> Math.Max(a,Math.Max (b, c));

    static int Maximum(int a, int b, int c, int d)
    {
        return Math.Max(Math.Max(a, d), Math.Max(b, c));
    }

    static int Minimum(int a, int b) => Math.Min(a, b);
    
    static int Minimum(int a, int b, int c) => Math.Min(a, Math.Min(b,c));
        

    static int Minimum(int a, int b, int c, int d)
    {
        return Math.Min(Math.Min(a, d), Math.Min(b, c));
    }

    static bool TrySumifOdd(int e, int f)
    {
        if ((e + f) % 2 != 0)
            return true;

        return false;
    }


    static bool Repeat(string s, int n)
    {
             
        for (int i = 1; i <= n; i++)
            Console.Write(s);
        return true;
               
    }


    static void Main()

    {

        var a = 10;
        var b = 100;
        var c = 148;
        var d = -15;
             
        int max = Maximum(a, b);
        int min = Minimum(a, b);

        int max1 = Maximum(a, b, c);
        int min1 = Minimum(a, b, c);

        int max2 = Maximum(a, b, c, d);
        int min2 = Minimum(a, b, c, d);

        Console.WriteLine($"Max of {a} and {b} is {max}, Min is {min}");

        Console.WriteLine($"Max of {a} ,{b} and {c} is {max1}, Min is {min1}");

        Console.WriteLine($"Max of {a} ,{b} ,{c} and {d} is {max2}, Min is {min2}");

        var e = 11;
        var f = 32;

        if (TrySumifOdd(e, f))
            Console.WriteLine($"Sum of {e} and {f} is Odd");

        else
            Console.WriteLine($"Sum of {e} and {f} is Even");

        string s = "ackofF";
        int n = 18;

        Repeat(s, n);



    }
}