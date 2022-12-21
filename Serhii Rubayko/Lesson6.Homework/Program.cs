
class Sort

{
    static void Selections(int[]arr)
    {    
        for (int i=0; i< arr.Length - 1; i++)
        {
            int minIndx = i;
            for (int j=i+1; j< arr.Length; j++) 
            {
                if (arr[j] < arr[minIndx])
                    minIndx = j;           
            }
            int tmp = arr[minIndx];
            arr[minIndx] = arr[i];
            arr[i] = tmp;        
        }    
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item}".PadRight(5, ' '));
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static void BubbleSort(int[] arr)
    {

        for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr.Length-i-1; j++)
                if (arr[j] > arr[j+1])
                { 
                    int tmp = arr[j+1];
                    arr[j+1] = arr[j];
                    arr[j] = tmp;
                }
               
    }

    static void InsertionSort(int[] arr) 
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >=0&& arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j -= 1;
            }
            arr[j + 1] = key;
        }
      
    }




    static void Main()
    {

        int[] FirstArr = new int[7] { 7, 34, 76, 11, 23, 4, 17 };

        PrintArray(FirstArr);
        Selections(FirstArr);
        PrintArray(FirstArr);

        int[] Arr2 = new int[7] { 7, 34, 76, 11, 23, 4, 17 };

        PrintArray(Arr2);
        BubbleSort(Arr2);
        PrintArray(Arr2);

        int[] Arr3 = new int[7] { 7, 34, 76, 11, 23, 4, 17 };

        PrintArray(Arr3);
        InsertionSort(Arr3);
        PrintArray(Arr3);

    }

}



