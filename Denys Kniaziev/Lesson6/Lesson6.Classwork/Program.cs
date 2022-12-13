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

for (int i = 0; i < arr4.Length; i++)
{
    for (int j = 0; j < arr4[i].Length; j++)
    {
        int item = arr4[i][j];
        Console.WriteLine(item);
    }
}