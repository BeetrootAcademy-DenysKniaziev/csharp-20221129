// Asc Sort -------------------------------------------
#region
void SelectionAsc(int[] array)
{
	int length = array.Length;

    for (int i = 0; i < length - 1; i++)
    {
        int min_idx = i;
        for (int j = i + 1; j < length; j++)
            if (array[j] < array[min_idx]) min_idx = j;

        int temp = array[min_idx];
        array[min_idx] = array[i];
        array[i] = temp;
    }
}
void BubbleAsc(int[] array)
{
    int length = array.Length;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length-1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j+1];
                array[j+1] = temp;
            }
        }
    }
}
void InsertionAsc(int[] array)
{
    int length = array.Length;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (array[i] < array[j])
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
#endregion

// Desc Sort ----------------------------------------------
#region
void SelectionDesc(int[] array)
{
    int length = array.Length;

    for (int i = 0; i < length - 1; i++)
    {
        int max_idx = i;
        for (int j = i + 1; j < length; j++)
            if (array[j] > array[max_idx]) max_idx = j;

        int temp = array[max_idx];
        array[max_idx] = array[i];
        array[i] = temp;
    }
}
void BubbleDesc(int[] array)
{
    int length = array.Length;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length - 1; j++)
        {
            if (array[j] < array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}
void InsertionDesc(int[] array)
{
    int length = array.Length;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (array[i] > array[j])
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
#endregion

void printArray(int[] array)
{
    int length = array.Length;
    for (int i = 0; i < length; i++)
        Console.Write(array[i] + " ");
    Console.WriteLine();
}

int[] arr = { 8, 3, 4, 9, 10, 2, 5, 3 };

// Choosing type and order ------------------------------------------
var type = SortAlgorithmType.Insertion;
var order = OrderBy.Desc;

#region if else
if (type == SortAlgorithmType.Selection && order == OrderBy.Asc)
{
    SelectionAsc(arr);
    Console.WriteLine("Selection Asc Sort: ");
    printArray(arr);
}
else if (type == SortAlgorithmType.Selection && order == OrderBy.Desc)
{
    SelectionDesc(arr);
    Console.WriteLine("Selection Desc Sort: ");
    printArray(arr);
}

else if (type == SortAlgorithmType.Bubble && order == OrderBy.Asc)
{
    BubbleAsc(arr);
    Console.WriteLine("Selection Asc Sort: ");
    printArray(arr);
}
else if (type == SortAlgorithmType.Bubble && order == OrderBy.Desc)
{
    BubbleDesc(arr);
    Console.WriteLine("Selection Desc Sort: ");
    printArray(arr);
}

else if (type == SortAlgorithmType.Insertion && order == OrderBy.Asc)
{
    InsertionAsc(arr);
    Console.WriteLine("Insertion Asc Sort: ");
    printArray(arr);
}
else if (type == SortAlgorithmType.Insertion && order == OrderBy.Desc)
{
    InsertionDesc(arr);
    Console.WriteLine("Insertion Desc Sort: ");
    printArray(arr);
}
#endregion

enum SortAlgorithmType
{
    Selection,
    Bubble,
    Insertion
}
enum OrderBy
{
    Asc, 
    Desc
}
