using System.Text;

Console.WriteLine("Lesson_7");
Console.WriteLine("Classwork");
// CHAR

//var str1 = "hello";
//var str2 = new string('a', 10);
//var str3 = new string(new char[] { 'a', 'b', 'c' });

//char c1 = 'a';

//Console.WriteLine(char.IsAscii('a'));
//Console.WriteLine(char.IsDigit('5'));
//Console.WriteLine(char.IsNumber('5'));
//Console.WriteLine(char.IsPunctuation(','));
//Console.WriteLine(char.IsUpper('U'));
//Console.WriteLine(char.IsLower('u'));

//int c2  = 2;
//Console.WriteLine(((char)c2));

//strings
//foreach (var c in "hello")
//{
//    Console.WriteLine(c);
//}

//Console.WriteLine((object)"abc" == (object)"abc");

//var str1 = "ab";
//Console.WriteLine((object)$"{str1}c" == (object)"abc");

//var str2 = Console.ReadLine();
//Console.WriteLine((object)$"{str2}c" == (object)"abc");

//var str3 = $""" 
//           |jjdsf
//           |gjdh
//           |gjdh
//           |gjdh
//           |
//           """;
//Console.WriteLine(str3);

//var str4 = $"{4 + 5}";
//Console.WriteLine(str4);

//Console.WriteLine("abdcd".CompareTo("abc"));
//Console.WriteLine("abcde".Contains("bcd"));
//Console.WriteLine(new String("abcde".Concat("bcd").ToArray()));
//Console.WriteLine("abcde" + "bcd");

//var str3 = new char[10];
//"abcde".CopyTo(0, str3, 0, 4);

//Console.WriteLine(str3);

//Console.WriteLine("dsdsd\nfdfdfd");
//Console.WriteLine("dsdsd\tfdfdfd");
//Console.WriteLine("dsdsd\0fdfdfd");
//Console.WriteLine("dsdsd\"\"fdfdfd");
//Console.WriteLine(@$"d\sd\sd""{4 + 5}""fdfdfd");
//Console.WriteLine(""""d\sd\sd"""fdfdfd"""");

//Console.WriteLine("abc".IndexOf('b'));
//Console.WriteLine("abc".StartsWith('a'));

//var words = "hello, to all my team".Split(new char[] { ' ', ',', '.' });
//foreach (var word in words)
//{
//    Console.WriteLine(word);
//}

//var word2 = "hello, to all my team".Trim('m');
//Console.WriteLine(word2);


//var word3 = word2.Remove(word2.Length - 3);
//Console.WriteLine(word3);

//var word4 = "hello, to all my team".Insert(6, "WHAT?");
//Console.WriteLine(word4);

//var word5 = "hello, to all my team".Replace("ll", "LL");
//Console.WriteLine(word5);

//var word6 = "hello, to all my team".ToUpper();
//Console.WriteLine(word6);

//var word7 = "hello, to all my team".ToLower();
//var arr = word7.ToArray();
//arr[4] = char.ToUpper(arr[4]);
//word7 = new string(arr);

//Console.WriteLine(word7);
//var word8 = word7.Substring(0, 3);

//Console.WriteLine("AbC".Equals("abc", StringComparison.InvariantCultureIgnoreCase));
//Console.WriteLine("AbC".ToUpper() == "abc".ToUpper());

//var str1 = string.Format("Hello, {0}!\n{1}", "Ivan", "Hello!");
//Console.WriteLine(str1);

//var str2 = string.Format("{0:C2}, {1:D6}, {2:F4}", 2.7, 1366656, 545.458878);
//Console.WriteLine(str2);

//var str3 = $"{5.993:C2}, {45:D6}, {2.889898989:F4}";
//Console.WriteLine(str3);

var sb = new StringBuilder();

for (int i = 0; i < 1000; i++)
{
    sb.Append((char)i);
}

sb.Remove(10, 10);

Console.WriteLine(sb.Length);

(int p1, int p2, string p3) Analize(string str)
{
    var t = 5;
    return (p1: t, p2: 5, p3: "dfdfdy");
}