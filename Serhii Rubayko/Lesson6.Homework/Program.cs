
int[] FirstArr= new int[7] {7, 34, 76, 11, 23, 4, 17};

Console.WriteLine();
Console.Write("My 1st array members: \t");
foreach (int i in FirstArr)
{
       Console.Write("\t{0}", i);
}

//var arr = FirstArr[2];

Index begin= new Index(2);
Index end= new Index(2,true);

var third = FirstArr[begin];

var beforeLast = FirstArr[end];

Console.WriteLine();
Console.WriteLine($"Length - \"{FirstArr.Length}\", i{begin} - {third}, i{end} - {beforeLast}");


var threeElements = FirstArr[0..3];

var threeLast = FirstArr[^3..^0];

foreach (int i in FirstArr[0..3])
{
    Console.Write("\t{0}", i);
}

Console.Write("\t\t");


foreach (int i in FirstArr[^3..^0])
{
    Console.Write("\t{0}", i);
}

Range rng=new Range(begin, end);

Console.WriteLine();

foreach (int i in FirstArr[rng])
{
    Console.Write("\t{0}", i);
}

Console.WriteLine(); 

Console.WriteLine($"Length - {FirstArr[rng].Length}");


Console.WriteLine();


