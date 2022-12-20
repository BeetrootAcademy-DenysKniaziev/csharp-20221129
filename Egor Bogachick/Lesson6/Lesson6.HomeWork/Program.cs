// Selection Sort Algorithm

void selectionSort(int[] arr)
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
void bubbleSort(int[] arr)
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
void insertionSort(int[] arr)
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

static void printArray(int[] arr)
{
    for (int i = 0; i < arr.Length; ++i)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}

int[] arr = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
//selectionSort(arr);
//bubbleSort(arr);
insertionSort(arr);
printArray(arr);
