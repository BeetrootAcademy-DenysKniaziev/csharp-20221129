
internal class Program
{
    static void Selection(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] > arr[maxIndex])
                {
                    maxIndex = j;
                }
            }
            int tmp = arr[maxIndex];
            arr[maxIndex] = arr[i];
            arr[i] = tmp;
        }
    }

    static void Bubble(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] < arr[j + 1])
                {
                    int tmp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }

    static void Insertion(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int max = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] < max)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = max;
        }
    }

    static void PrintArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
    }
    private static void Main(string[] args)
    {
        Console.Write("Enter the amount of elements: ");
        int x = int.Parse(Console.ReadLine());
        var arr = new[] { 33, 12, 4, 44, 8 };

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Enter {i + 1} element: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Selection(arr);
        Console.WriteLine("\tSORTED ARRAY BY SELLECTION");
        PrintArr(arr);

        Bubble(arr);
        Console.WriteLine("\tSORTED ARRAY BY BUBBLE");
        PrintArr(arr);

        Insertion(arr);
        Console.WriteLine("\tSORTED ARRAY BY INSERTION");
        PrintArr(arr);
    }
}