class Program
{

    static string Repeat(string X, int N)
    {
        if (N < 1) return " ";

        return X+Repeat(X, N-1);
    }
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter your text: ");
            string X = Console.ReadLine();
            Console.Write("\nEnter amount of Repeats: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(Repeat(X, N));
            Console.ReadLine();
        }
    }
}