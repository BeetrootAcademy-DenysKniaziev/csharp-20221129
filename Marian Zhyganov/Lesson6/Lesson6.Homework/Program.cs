Console.WriteLine("Selection sort:");
int[] SelectArr = { 10, 1, 2, 8, 3, 9, 4, 7, 5, 11, 6 };

for (int i = 0; i < SelectArr.Length; i++)
{
    Console.Write($" {SelectArr[i]}");

}
Console.WriteLine();
for (int i = 0; i < SelectArr.Length; i++)
{
    int minValue = i;
    for (int j = i + 1; j < SelectArr.Length; j++)
    {
        if (SelectArr[j] < SelectArr[minValue])
        {
            minValue = j;
        }
    }

    int tmp = SelectArr[minValue];
    SelectArr[minValue] = SelectArr[i];
    SelectArr[i] = tmp;

}

for (int i = 0; i < SelectArr.Length; i++)
{
    Console.Write($" {SelectArr[i]}");
}


Console.WriteLine("\nBubble sort");
int[] arr = { 800, 11, 50, 771, 649, 770, 240, 9 };

BabbleSort();
void BabbleSort()
{
    int temp;

    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;

            }

        }

    }
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($" {arr[i]}");
    }
}


Console.WriteLine("\nInsertion sort");
Insertion(arr);


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
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($" {arr[i]}");
    }
}




Console.ReadKey();