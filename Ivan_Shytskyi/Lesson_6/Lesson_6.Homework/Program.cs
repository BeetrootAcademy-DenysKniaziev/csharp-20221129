Console.WriteLine("Homework 6");
Console.WriteLine("sort algorithms");

void Print (int[] arr)
{
    foreach(var i in arr)
        Console.Write($"{i} ");
    Console.WriteLine();
}
void SortSelection(int[] arr)
{
    for (int i = 0; i < arr.Length-1; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[j] < arr[minIndex])
                minIndex = j;
        }
        int tmp = arr[minIndex];
        arr[minIndex] = arr[i];
        arr[i] = tmp;  
    }
}
void SortBubble(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int tmp = arr[j + 1];
                arr[j+1] = arr[j];
                arr[j] = tmp;
            }
        }
    }
}
void SortInsertion(int[] arr)
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

int[] array1 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
int[] array2 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
int[] array3 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
Console.WriteLine("Sort Selection:");
Print(array1);
SortSelection(array1);
Print(array1);

Console.WriteLine("Sort Bubble:");
Print(array2);
SortBubble(array2);
Print(array2);

Console.WriteLine("Sort Insertion:");
Print(array3);
SortInsertion(array3);
Print(array3);