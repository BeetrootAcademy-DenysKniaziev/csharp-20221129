class Program
{
    public static void Main(string[] args)
    {
        SortAlgorithmType algorithmType = new SortAlgorithmType();
        int choose = 0;
        while (true)
        {
            Console.WriteLine("SelectionSort - 1\nBubbleSort - 2\nInsertionSort - 3");
            if (!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            if(Enum.IsDefined(typeof(DayOfWeek), choose))
            {
                Console.WriteLine("true");
            }
            algorithmType = (SortAlgorithmType)choose;

            Console.WriteLine(algorithmType);


            switch (algorithmType)
            {
                case SortAlgorithmType.Selection:
                    break;
                case SortAlgorithmType.Insertion:
                    break;
                case SortAlgorithmType.Bubble:
                    break;
            }

        }
    }


    static void SelectionSort(int[] mass)
    {
        int min;
        for (int i = 0; i < mass.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < mass.Length; j++)
            {
                if (mass[min] > mass[j])
                    min = j;
            }
            (mass[i], mass[min]) = (mass[min], mass[i]);
        }
    }
    static void BubbleSort(int[] mass)
    {
        for (int i = 1; i < mass.Length; i++)
            for (int j = 0; j < mass.Length - i; j++)
            {
                if (mass[j] > mass[j + 1])
                    (mass[j], mass[j + 1]) = (mass[j + 1], mass[j]);
            }
    }
    static void InsertionSort(int[] mass)
    {
        for (int i = 1; i < mass.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (mass[j - 1] > mass[j])
                    (mass[j], mass[j - 1]) = (mass[j - 1], mass[j]);
                else
                    break;
            }
        }
    }

    static void Sort(int[] mass, SortAlgorithmType type, OrderBy orderBy)
    {
        switch (type)
        {
            case SortAlgorithmType.Selection:
                SelectionSort(mass);
                break;
            case SortAlgorithmType.Bubble:
                SelectionSort(mass);
                break;
            case SortAlgorithmType.Insertion:
                SelectionSort(mass);
                break;
            default:
                break;
        }

    }

    enum SortAlgorithmType : int
    {
        Selection = 1,
        Bubble = 2,
        Insertion = 3
    }

    enum OrderBy
    {
        Asc = 1,
        Desc
    }
}