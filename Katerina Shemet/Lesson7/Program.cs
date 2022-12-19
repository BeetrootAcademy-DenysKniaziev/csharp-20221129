//var str1 = "hello";
//var str2 = new string('a', 10);
//var str3 = new string(new char[] { 'a', 'b', 'c' });
//char c1 = 'a';

//Console.WriteLine(char.IsAscii(c1));
//Console.WriteLine(char.IsDigit('5'));
//Console.WriteLine(char.IsNumber('5'));
//Console.WriteLine(char.IsPunctuation(','));
//Console.WriteLine(char.IsLower('u'));
//Console.WriteLine(char.IsUpper('U'));

//int c2 = 2;
//Console.WriteLine((char)c2);

//string
//foreach(var c in "hello")
//{
//    Console.WriteLine(c);
//}

//Console.WriteLine("abc"=="abc");
//var str1 = "ab";
//Console.WriteLine($"{str1}c"=="abc");

//var str2 = Console.ReadLine();
//Console.WriteLine($"{str2}c"=="abc");

//var str3 = $"""
//           dddd
//           dd
//           """;
//Console.WriteLine(str3);

//var str4 = $"{4 + 5}";
//Console.WriteLine(str4);

using System.Text;

Console.WriteLine("abcd".CompareTo("abc"));
Console.WriteLine("abcde".Contains("ab"));
Console.WriteLine("ab"+"cde");

var str7 = new char[10];
"abcd".CopyTo(0, str7, 0, 4);
Console.WriteLine(str7);

Console.WriteLine("sss\"dd");
Console.WriteLine(@"""\");

var sb = new StringBuilder("Hello, ");
Console.WriteLine(sb.Capacity);
Console.WriteLine(sb.Length);

sb.Append("Denys");
Console.WriteLine(sb);