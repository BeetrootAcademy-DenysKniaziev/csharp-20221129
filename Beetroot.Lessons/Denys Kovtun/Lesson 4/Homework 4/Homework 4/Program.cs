class program
{
    /*
    static int ValueMax(int frist, int second)
    {
        return Math.Max(frist, second);
    }

    static int ValueMax(int frist, int second, int third)
    {
        return Math.Max(frist, Math.Max(second, third));
    }

    static int ValueMax(int frist, int second, int third, int fourth)
    {
        return Math.Max(Math.Max(frist, fourth), Math.Max(second, third));
    }


    static int ValueMin(int frist, int second)
    {
        return Math.Min(frist, second);
    }

    static int ValueMin(int frist, int second, int third)
    {
        return Math.Min(frist, Math.Min(second, third));
    }

    static int ValueMin(int frist, int second, int third, int fourth)
    {
        return Math.Min(Math.Min(frist, fourth), Math.Min(second, third));
    }
    

    static bool TrySumIfOdd(int first, int second)
    {
        int sum = 0;


        while (first <= second)
        {
            sum += first;

            first++;
        
        }


        if (sum % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;    
        } 
    }
    */

    //EXTRA
    static string Repeat(string x, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(x);
        }


        string b = "";

        return b;
    }


    static void Main()
    {
      string a = Console.ReadLine();
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine(Repeat(a, b));

    }


}