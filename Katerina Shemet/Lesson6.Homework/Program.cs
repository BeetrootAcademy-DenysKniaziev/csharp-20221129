class Program
{
    static void Swap(ref int a1, ref int a2)
    {
        var temp = a1;
        a1 = a2;
        a2 = temp;
    }

    #region BubbleSort

    static int[] BubbleSort(int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    }
    #endregion


    #region Selection sort

    static int IndexOfMin(int[] array, int n)
    {
        int result = n;
        for (var i = n; i < array.Length; ++i)
        {
            if (array[i] < array[result])
            {
                result = i;
            }
        }

        return result;
    }


    static int[] SelectionSort(int[] array, int currentIndex = 0)
    {
        if (currentIndex == array.Length)
            return array;

        var index = IndexOfMin(array, currentIndex);
        if (index != currentIndex)
        {
            Swap(ref array[index], ref array[currentIndex]);
        }

        return SelectionSort(array, currentIndex + 1);
    }

    #endregion

    #region Insertion Sort

    static int[] InsertionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (array[j - 1] > array[j])
                {
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }

    #endregion

    static void Main(string[] args)
    {
        Console.Write("Enter the elements of the array:");
        var parts = Console.ReadLine().Split(new[] { "", ",", ";"," " }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(@"Сhoose a sorting method:

1- Bubble Sort
2- Selection Sort
3- Insertion Sort ");
        var choose = Convert.ToInt32(Console.ReadLine());

        switch(choose)
        {
            case 1:

                Console.WriteLine("Bubble Sort");
                var array1 = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    array1[i] = Convert.ToInt32(parts[i]);
                }
                Console.WriteLine("Sorted array: {0}", string.Join(",", BubbleSort(array1)));

                break;

                case 2:

                Console.WriteLine("Sort by selection");
                
                var array2 = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    array2[i] = Convert.ToInt32(parts[i]);
                }
                Console.WriteLine("Ordered array: {0}", string.Join(",", SelectionSort(array2)));

                break;

            case 3:

                Console.WriteLine("Sort by inserts");
               
                var array3 = new int[parts.Length];
                for (int i = 0; i < parts.Length; i++)
                {
                    array3[i] = Convert.ToInt32(parts[i]);
                }
                Console.WriteLine("Ordered array: {0}", string.Join(",", InsertionSort(array3)));

                break;
        }
   
    }
}
