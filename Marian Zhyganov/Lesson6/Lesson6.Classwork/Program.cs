//var arr1 = new int[,] { { 1, 2 }, { 3, 4 } };
//foreach (var item in arr1)
//{
//    Console.WriteLine(item);
//}
//var arr2 = new int[,,] { { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };
//foreach (var item1 in arr2)
//{
//    Console.WriteLine(item1);
//}
//using System.Collections.Generic;

//var array1 = new[] { 1, 2, 3 };
//var array2 = new int[] { 1, 2, 3 };
//                                        //example        
//var array3 = new int[3] { 1, 2, 3 };
//int[] array4 =  { 1, 2, 3 };

//Console.WriteLine(array1[0]); //  first
//Console.WriteLine(array1[^1]); // last

//var index = new Index(1, true);
//Console.WriteLine(array1[index]);

//var range = new Range(1, 2);
//Console.WriteLine(array1[range]);

//var range1 = new Range(1, 2);
//var result = array1[range1];

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//var arr2 = new int[,,] { { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } } };

//foreach (var item in arr2)
//{
//    Console.WriteLine(item);

//}


//var arr1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
//for (var i = 0; i < arr1.GetLength(0); i++)
//{

//    for (int j = 0; j < arr1.GetLength(1); j++)
//    {
//        Console.WriteLine($"{arr1[i, j]}");
//    }
//    Console.WriteLine();
//}

var arr3 = new int[10, 10];
for (var i = 0; i < arr3.GetLength(0); i++)
{

    for (int j = 0; j < arr3.GetLength(1); j++)
    {
        arr3[i, j] = i * arr3.GetLength(1) + j;
    }


}
for (var i = 0; i < arr3.GetLength(0); i++)
{

    for (int j = 0; j < arr3.GetLength(1); j++)
    {
        Console.WriteLine($"{arr3[i, j]} ".PadLeft(3, '0'));
    }
    Console.WriteLine();

}
var arr4 = new int[3][];
arr4[0] = new[] { 1, 2, 3 };
arr4[1] = new[] { 1, 2 };
arr4[2] = new[] { 1, 2, 3 };

for (var i = 0; i < arr4.Length; i++)
{
    for (int j = 0; j < arr4[i].Length; j++)
    {
        int item = arr4[i][j];
        Console.WriteLine(item);
    }
}

//void PrintArray(int[] arr)
//{
//    foreach (var item in arr)
//    {
//        Console.WriteLine(item);
//    }
//    Console.WriteLine();
//}
//void EditArray(int[] arr)
//{
//    for (int i = 0; i < arr.Length; i++)
//    {
//        arr[i] = arr[i] * 2;
//    }
//}

//void ChangeArrayRef(ref int[] arr)
//{
//    arr = new int[] { 0, -1, -2 };
//}

//PrintArray(array2);

