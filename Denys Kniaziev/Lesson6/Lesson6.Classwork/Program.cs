var array1 = new[] { 1f, 2, 3 };
var array2 = new int[] { 1, 2, 3 };
var array3 = new int[3] { 1, 2, 3 };
int[] array4 = { 1, 2, 3 };
var array5 = new int[3];

//Console.WriteLine(array1[0]);
//Console.WriteLine(array1[^1]);

//var index = new Index(1, true);
//Console.WriteLine(array1[index]);

//var range = new Range(^2, ^0);

//var result = array1[range];

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

var arr1 = new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };
var arr2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

//foreach (var item in arr1)
//{
//    Console.WriteLine(item);
//}

//for (int i = 0; i < arr2.GetLength(0); i++)
//{
//    for (int j = 0; j < arr2.GetLength(1); j++)
//    {
//        Console.Write($"{arr2[i, j]} ");
//    }
//    Console.WriteLine();
//}

//var arr3 = new int[10, 10];
//for (int i = 0; i < arr3.GetLength(0); i++)
//{
//    for (int j = 0; j < arr3.GetLength(1); j++)
//    {
//        arr3[i, j] = i * arr3.GetLength(1) + j;
//    }
//}

//for (int i = 0; i < arr3.GetLength(0); i++)
//{
//    for (int j = 0; j < arr3.GetLength(1); j++)
//    {
//        Console.Write($"{arr3[i, j]} ".PadLeft(3, '0'));
//    }
//    Console.WriteLine();
//}

var arr4 = new int[3][];

arr4[0] = new[] { 1, 2, 3 };
arr4[1] = new[] { 1, 2, 3, 4 };
arr4[2] = new[] { 1, 2 };

//for (int i = 0; i < arr4.Length; i++)
//{
//    for (int j = 0; j < arr4[i].Length; j++)
//    {
//        int item = arr4[i][j];
//        Console.WriteLine(item);
//    }
//}

void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write(item);
    }
    Console.WriteLine();
}

void EditArray(int[] arr)
{
    var range = arr[0..2];
    for (int i = 0; i < range.Length; i++)
    {
        range[i] = range[i] * 2;
    }
}

int[] EditArray2(int[] arr)
{
    var copy = new int[arr.Length];
    for (int i = 0; i < copy.Length; i++)
    {
        copy[i] = arr[i] * 2;
    }
    return copy;
}

int[] CopyArray(int[] arr)
{
    var copy = new int[arr.Length * 3];
    arr.CopyTo(copy, 0);
    arr.CopyTo(copy, 3);
    arr.CopyTo(copy, 6);
    return copy;
}

int[] CopyArray2(int[] arr)
{
    var copy = new int[arr.Length];
    Array.Copy(arr, copy, arr.Length);
    return copy;
}

void ChangeArrayRef(ref int[] arr)
{
    arr = new int[] { 0, -1, -2 };
}

//PrintArray(array2);
//EditArray(array2);
//PrintArray(array2);
//ChangeArrayRef(ref array2);
//PrintArray(array2);

var res = BubbleSort(new[] {5, 1, 7, 8, 2, 0, 9 });
PrintArray(res);

int[] BubbleSort(int[] originArr)
{
    var arr = new int[originArr.Length];
    originArr.CopyTo(arr, 0);

    int tmp;

    for (int i = 1; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);      
            }
        }
    }

    return arr;
}

var type = SortType.Bubble;

enum SortType
{
    Bubble,
    Selection,
    Insertion
}