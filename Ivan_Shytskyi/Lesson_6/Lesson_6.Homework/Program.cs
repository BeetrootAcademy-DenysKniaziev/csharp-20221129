Console.WriteLine("Homework 6");
Console.WriteLine("sort algorithms");

void PrintSingleDimensional(int[] arr)
{
    foreach(var i in arr)
        Console.Write($"{i} ");
    Console.WriteLine();
}

void PrintMultidimensional(int[,] a)
{
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            Console.Write($"{a[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] NewArray()
{
    int[,] a = new int[5, 5];
    Random rnd = new Random();
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            a[i, j] = rnd.Next(0, 9);
        }
    }
    return a;
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

int[] Sort(int[] arr, Algorithm Alg)
{
    switch (Alg)
    {
        case Algorithm.SortSelection:
            SortSelection(arr);
            break;
        case Algorithm.SortBubble:
            SortBubble(arr);
            break;
        case Algorithm.SortInsertio:
            SortInsertion(arr);
            break;
    }
    return arr;
}

int FindAverageOne(int[,] a)
{
    int sum = 0;
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            if (j <= i)
                sum += a[i, j];
            else
                continue;
        }
    }
    sum = sum / 2;
    return sum;
}

int FindAverageTwo(int[,] b)
{
    int sum4 = 0;
    for (int i = 0; i < b.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1) - i; j++)
        {
            sum4 += b[i, j];
        }
    }
    sum4 = sum4 / 2;
    return sum4;
}

int FindAverageThree(int[,] c)
{
    int sum5 = 0;
    int sum1 = 0;
    int sum2 = 0;
    int x = 5 / 2 + 1;
    for (int i = 0; i < c.GetLength(0); i++)
    {
        int y = i;
        if (y < x)
        {

            for (int j = 0 + y; j < c.GetLength(1) - y; j++)
            {
                sum1 += c[i, j];
            }
        }
        else
        {
            int k = 1;
            if (i == c.GetLength(0) - 1)
            {
                k--;
                for (int j = 0 + k; j < c.GetLength(1) - k; j++)
                    sum2 += c[y, j];
            }
            else
            {
                for (int j = 0 + k; j < c.GetLength(1) - k; j++)
                    sum2 += c[y, j];
            }
            k--;
        }
        sum5 = (sum1 + sum2) / 2;
    }
    return sum5;
}

// TASK:

int[] array0 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
int[] array1 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
int[] array2 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
int[] array3 = new int[] { 9, 5, 6, 1, 7, 3, 4, 2, 8 };
Console.WriteLine("Sort Selection:");
PrintSingleDimensional(array1);
SortSelection(array1);
PrintSingleDimensional(array1);
Console.WriteLine();

Console.WriteLine("Sort Bubble:");
PrintSingleDimensional(array2);
SortBubble(array2);
PrintSingleDimensional(array2);
Console.WriteLine();

Console.WriteLine("Sort Insertion:");
PrintSingleDimensional(array3);
SortInsertion(array3);
PrintSingleDimensional(array3);
Console.WriteLine();

// EXTRA TASK:
// 1

Console.WriteLine("single function Sort:");
PrintSingleDimensional(array0);
int[] arr = Sort(array0, Algorithm.SortSelection);
PrintSingleDimensional(arr);
Console.WriteLine();

// FOR FUN:
// 1

int[,] a = NewArray();
PrintMultidimensional(a);
int average = FindAverageOne(a);
Console.WriteLine($"average = {average}");
Console.WriteLine();

// 2

int[,] b = NewArray();
PrintMultidimensional(b);
int average2 = FindAverageTwo(b);
Console.WriteLine($"average = {average2}");
Console.WriteLine();

// 3

int[,] c = NewArray();
PrintMultidimensional(c);
int average3 = FindAverageThree(c);
Console.WriteLine($"average = {average3}");
Console.WriteLine();

enum Algorithm
{
    SortSelection,
    SortBubble,
    SortInsertio
}
