void sort(int[] arr, SortType sortType)
{
    // Selection Sort Algorithm
    if (sortType == SortType.Selection)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int index = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[index])
                {
                    index = j;
                }

            }
            int temp = arr[index];
            arr[index] = arr[i];
            arr[i] = temp;
        }
    }
    //Bubble Sort Algorithm
    else if (sortType == SortType.Buble)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }

        }
    }
    //Insertion Sort
    else if (sortType == SortType.Insertion)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }
    else
    {
        Console.WriteLine("\nSort type is incorrect\n");
    }
}

static void printArray(int[] arr)
{
    for (int i = 0; i < arr.Length; ++i)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}

int[] arr = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
printArray(arr);
sort(arr, SortType.Buble);
//sort(arr, SortType.Insertion);
//sort(arr, SortType.Selection);
printArray(arr);

enum SortType
{
    Selection,
    Buble,
    Insertion
}

