
//int[] FirstArr= new int[7] {7, 34, 76, 11, 23, 4, 17};

//Console.WriteLine();
//Console.Write("My 1st array members: \t");
//foreach (int i in FirstArr)
//{
//       Console.Write("\t{0}", i);
//}

////var arr = FirstArr[2];

//Index begin= new Index(2);
//Index end= new Index(2,true);

//var third = FirstArr[begin];

//var beforeLast = FirstArr[end];

//Console.WriteLine();
//Console.WriteLine($"Length - \"{FirstArr.Length}\", i{begin} - {third}, i{end} - {beforeLast}");


//var threeElements = FirstArr[0..3];

//var threeLast = FirstArr[^3..^0];

//foreach (int i in FirstArr[0..3])
//{
//    Console.Write("\t{0}", i);
//}

//Console.Write("\t\t");


//foreach (int i in FirstArr[^3..^0])
//{
//    Console.Write("\t{0}", i);
//}

//Range rng=new Range(begin, end);

//Console.WriteLine();

//foreach (int i in FirstArr[rng])
//{
//    Console.Write("\t{0}", i);
//}

//Console.WriteLine(); 

//Console.WriteLine($"Length - {FirstArr[rng].Length}");

//Console.WriteLine();


//var arr1 = new int[3, 5] { { 0, 1, 2, 3, 4 }, { 5, 6, 7, 8, 9 }, { 10, 11, 12, 13, 14 } };

//for (int i=0; i<arr1.GetLength(0); i++)
//{
//    for (int j = 0; j< arr1.GetLength(1); j++)
//    {
//        Console.Write($"{arr1[i, j]}\t");

//    }
//    Console.WriteLine();
//}

//var arr2 = new int[9, 11];

//    for (int i = 0; i < arr2.GetLength(0); i++)
//    {
//        for (int j = 0; j < arr2.GetLength(1); j++)
//        {
//        arr2[i,j]=i* arr2.GetLength(1)+j;

//        }
//}

//for (int i = 0; i < arr2.GetLength(0); i++)
//{
//    for (int j = 0; j < arr2.GetLength(1); j++)
//    {
//        Console.Write($"{arr2[i, j]} ".PadLeft(5, ' '));

//    }
//    Console.WriteLine();
//}



var arr4 = new int[4][];

arr4[0] = new[] { 1, 2, 3, 4 };
arr4[1] = new[] { 5, 6, 7};
arr4[2] = new[] { 8, 9, 10, 11, 12};
arr4[3] = new[] { 13, 14};


//foreach(var arr in arr4)
//{
//    foreach(var item in arr)
//    { 
//        Console.Write($"{item}".PadLeft(5, ' '));
//    }
//    Console.WriteLine();
//}

//Console.WriteLine();


//for (int i = 0; i < arr4.Length; i++)
//{
    
//    for (int j = 0; j < arr4[i].Length; j++)
//    {
        
//        Console.Write($"{arr4[i][j]}".PadRight(5, ' '));
//    }
//    Console.WriteLine();
//}

void PrintArray(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item}".PadRight(5, ' '));
    }
    Console.WriteLine();
    Console.WriteLine();
}


void EditArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = arr[i] * 2;
    }
}

PrintArray(arr4[2]);
EditArray(arr4[2]);
PrintArray(arr4[2]);