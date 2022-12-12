class Program
{

    static int Get(string text)
    {
        bool IsItANumber = false;
        int x = 0;
        Console.WriteLine(text);

        do
        {
            IsItANumber = int.TryParse(Console.ReadLine(), out x);

        } while (!IsItANumber);

        return x;
    }

    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;

    }

    static int GetGD(int m, int h)
    {

        do
        {
            for (int i = m; i <= 1; i--)

                if (m % i == 0 && h % i == 0)
                {
                    int x = 0;
                    x = i;

                    return x;
                }
        } while (true);

        return m;
    }


    static void Main()
    {
        string text = "Enter 1st number:";
        int x = Get(text);
        text = "Enter 2nd number:";
        int y = Get(text);


        int z = GCD(x, y);
        Console.WriteLine($"\nGreatest common divisor: {z}");
    }
}
