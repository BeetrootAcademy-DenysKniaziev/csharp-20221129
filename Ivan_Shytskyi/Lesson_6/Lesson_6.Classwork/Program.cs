Console.WriteLine("Lesson_6");

var array1 = new[] { 9, 2, 3, 1, 0, 6 };
//var array2 = new int[] {1,2,3};
// int[] array3 =  { 1, 2, 3, 4};
//var array4 = new int[3];

//Console.WriteLine(array1[0]);
//Console.WriteLine(array1[^1]);
//var index = new Index(1, true);
//Console.WriteLine(array1[index]);
var range = new Range(0, 2);
var result = array1[range];
//foreach(var i in result)
//{
//    Console.WriteLine(i);
//}
//var range1 = new Range(^2, ^0);
//var result1 = array1[range1];
//foreach (var j in result1)
//{
//    Console.WriteLine(j);
//}

////var arr1 = new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };
//var arr1 = new int[2, 3] { {1,2,3}, {4,5,6} };
//for (int i = 0; i< arr1.GetLength(0); i++)
//{
//    for (int j = 0; j < arr1.GetLength(1); j++)
//    {
//        Console.Write($"{arr1[i,j]}");
//    }
//    Console.WriteLine();
//}

//var arr2 = new int[10, 10];
//for (int i = 0; i < arr2.GetLength(0); i++)
//{
//    for (int j = 0; j < arr2.GetLength(1); j++)
//    {
//        arr2[i,j] = i * arr2.GetLength(1) + j;
//    }
//}
//for (int i = 0; i < arr2.GetLength(0); i++)
//{
//    for (int j = 0; j <arr2.GetLength(1); j++)
//    {
//        Console.Write($"{arr2[i,j]}".PadLeft(3,' '));
//    }
//    Console.WriteLine();
//}

//var arr3 = new int[3][];
//for (int i = 0; i < arr3.GetLength(0); i++)
//{
//    arr3[i] = new int[]{1,2,3};
//}
//var arr4 =  new int[3][]; 
//arr4[0] = new int[] {1,2,3 };
//arr4[1] = new int[] {4,5 };
//arr4[2] = new int[] {6,7,8,9};
//for (int i = 0; i < arr4.Length; i++)
//{
//    for (int j = 0; j < arr4[i].Length; j++)
//    {
//       int item = arr4[i][j];
//        Console.Write(item);
//    }
//    Console.WriteLine();
//}


//int[] Copy(int[] arr)
//{
//   var copy = new int[array1.Length * 3];
//   array1.CopyTo(copy,0);
//    array1.CopyTo(copy, 3);
//    array1.CopyTo(copy, 6);
//    return copy;    
//}

int[] BubelSort(int[] arr)
{
    var copy = new int[array1.Length];
    arr.CopyTo(copy, 0);

    int tmp;
    for (int i = 1; i < copy.Length; i++)
    {
        for (int j = 0; j < copy.Length - i; j++)
        {
            if (copy[j] > copy[j + 1])
            {
                (copy[j], copy[j + 1]) = (copy[j + 1], copy[j]); //tuple
                //tmp = copy[j + 1];
                //copy[j+1] = copy[j];
                //copy[j] = tmp;
            }
        }
    }
    return copy;
}

foreach (var i in array1)
{
    Console.Write(i);
}
Console.WriteLine();
var a = BubelSort(array1);
foreach (var i in a)
{
    Console.Write(i);
}




