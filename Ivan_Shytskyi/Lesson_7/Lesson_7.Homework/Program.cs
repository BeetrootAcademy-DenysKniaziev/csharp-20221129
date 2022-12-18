using System.Globalization;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Homework");
bool Compare(string str1, string str2)
{
    if (str1 == str2) return true;
    else return false;
}

bool Compare_1(string str1, string str2)
{
    if (str1.Length == str2.Length) return true;
    else return false;
}

static (int letter, int digit, int anather) Analyze(string str)
{
    int letter = 0;
    int digit = 0;
    int anather = 0; 
    var arr = str.ToCharArray();
    for (int i = 0; i < arr.Length; i++)
    {
        if (char.IsLetter(arr[i]))
            letter++;
        else if (char.IsDigit(arr[i]))
            digit++;
        else
            anather++;
    }
    return (letter, digit, anather);
}

string Sort(string str)
{
    str = str.ToLower();
    var arr = str.ToCharArray();
    for (int i = 1; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                char tmp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = tmp;
            }
        }
    }
    return new string(arr);
}

static char[] Duplicate(string str)
{
    string d = "";
    for (int i = 0; i < str.Length; i++)
    {
        d += str[i];
    }
    return d.ToCharArray();
}

string s1 = "Lqwer4+";
string s2 = "asdf";
bool b1 = Compare(s1, s2);
Console.WriteLine(b1);
Console.WriteLine(Compare_1(s1, s2));


Console.WriteLine(Analyze(s1));

string s3 = "Hello";
Console.WriteLine(s3);
s3 = Sort(s3);
Console.WriteLine(s3);

Console.WriteLine("Duplicate: ");
var c = Duplicate(s1);
foreach (var i in c)
    Console.Write($"{i} ");



