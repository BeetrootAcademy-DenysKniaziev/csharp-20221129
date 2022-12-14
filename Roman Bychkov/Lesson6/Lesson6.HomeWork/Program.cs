class Program
{
    enum SortAlgorithmType
    {
        Selection = 1,
        Bubble,
        Insertion
    }

    enum OrderBy
    {
        Asc = 1,
        Desc
    }
    public static void Main(string[] args)
    {
        SortAlgorithmType algorithmType = new SortAlgorithmType();
        OrderBy orderBy = new OrderBy();
        int choice = 0;
        int[] arr = new int[10];

        while (true)
        {

            Console.WriteLine("SelectionSort - 1\nBubbleSort - 2\nInsertionSort - 3");
            if (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(SortAlgorithmType), choice))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            algorithmType = (SortAlgorithmType)choice;


            Console.WriteLine("\nAsc - 1\nDesc - 2");
            if (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(OrderBy), choice))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            orderBy = (OrderBy)choice;


            Console.WriteLine("\nBefore:");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(1, 15);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
            Sort(arr, algorithmType, orderBy);

        }
    }


    static int[] SelectionSort(int[] arr1, OrderBy orderBy)
    {
        int[] arr = new int[arr1.Length];
        arr1.CopyTo(arr, 0);

        int min;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if ((arr[min] > arr[j] && orderBy == OrderBy.Asc) || (arr[min] < arr[j] && orderBy == OrderBy.Desc))
                    min = j;
            }
            (arr[i], arr[min]) = (arr[min], arr[i]);
        }

        return arr;
    }
    static int[] BubbleSort(int[] arr1, OrderBy orderBy)
    {
        int[] arr = new int[arr1.Length];
        arr1.CopyTo(arr, 0);

        for (int i = 1; i < arr.Length; i++)
            for (int j = 0; j < arr.Length - i; j++)
            {
                if ((arr[j] > arr[j + 1] && orderBy == OrderBy.Asc) || (arr[j] < arr[j + 1] && orderBy == OrderBy.Desc))
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }

        return arr;
    }
    static int[] InsertionSort(int[] arr1, OrderBy orderBy)
    {
        int[] arr = new int[arr1.Length];
        arr1.CopyTo(arr, 0);

        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (arr[j - 1] > arr[j] && orderBy == OrderBy.Asc || arr[j - 1] < arr[j] && orderBy == OrderBy.Desc)
                    (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                else
                    break;
            }
        }

        return arr;
    }

    static void Sort(int[] arr, SortAlgorithmType type, OrderBy orderBy)
    {
        int[] result = new int[arr.Length];
        switch (type)
        {
            case SortAlgorithmType.Selection:
                result = SelectionSort(arr, orderBy);
                break;
            case SortAlgorithmType.Bubble:
                result = BubbleSort(arr, orderBy);
                break;
            case SortAlgorithmType.Insertion:
                result = InsertionSort(arr, orderBy);
                break;
        }
        Console.WriteLine("Result:");
        foreach (int i in result)
            Console.Write($"{i} ");
        Console.WriteLine("\n");
    }

}