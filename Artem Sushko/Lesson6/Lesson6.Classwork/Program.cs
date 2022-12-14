internal class Program
{
    private static void Main(string[] args)
    {
        var arr = new int[10, 10];

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = i * 10 + j;
            }
        }

        First(arr);
        Second(arr);
        Third(arr);

        static void First(int[,] arr)
        {
            int amountnumbers = 0;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    sum += arr[i, j];
                    amountnumbers++;
                }
            }
            int res = sum / amountnumbers;
            Console.WriteLine($"Sum of numbers by First triangle: {res}");
        }
        
        static void Second(int[,] arr)
        {
            int amountnumbers = 0;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0) - i; j++)
                {
                    sum += arr[i, j];
                    amountnumbers++;
                }
            }
            int res = sum / amountnumbers;
            Console.WriteLine($"\nSum of numbers by Second triangle: {res}");
        }

        static void Third(int[,] arr)
        {
            int amountnumbers = 0;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i <= (arr.GetLength(0) / 2) - 1)
                {
                    for (int j = i; j < arr.GetLength(0) - i; j++)
                    {
                        sum += arr[i, j];
                        amountnumbers++;
                    }
                }
                else
                {
                    for (int j = i; j >= arr.GetLength(0) - i - 1; j--)
                    {
                        sum += arr[i, j];
                        amountnumbers++;
                    }
                }
            }
            int res = sum / amountnumbers;
            Console.WriteLine($"\nSum of numbers by Third triangle: {res}");
        }
    }
}