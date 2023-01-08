using System.Text;

Console.WriteLine($"MyEquals\nPass == Login {MyEquals("Pass", "Login"),5}");
Console.WriteLine($"Pass == Logi {MyEquals("Pass", "Logi"),5}");
Console.WriteLine($"Pass == Pass {MyEquals("Pass", "Pass"),5}\n");

while (true)
{
    Console.Write("Type a word: ");
    string str = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(str))
    {
        Console.WriteLine("invalid input");
        continue;
    }

    Console.WriteLine($"Sort: {Sort(str)}");
    Console.WriteLine("Duplicate: ");
    foreach (var i in Duplicate(str))
        Console.Write($"{i,2}");


    var analyze = Analyze(str);
    Console.WriteLine($"\nAnalyze: letter:{analyze.letter}, numberOf:{analyze.number}, another:{analyze.another}\n");
}


static bool MyEquals(string s1, string s2)
{
    if (s1.Length != s2.Length)
        return false;
    for (int i = 0; i < s1.Length; i++)
        if (s1[i] != s2[i])
            return false;
    return true;
}
static (int letter, int number, int another) Analyze(string s)
{
    int let = 0, num = 0, ano = 0;
    foreach (char c in s)
    {
        if (char.IsLetter(c))
            let++;
        else if (char.IsDigit(c))
            num++;
        else
            ano++;
    }
    return (let, num, ano);
}
static string Sort(string arr = "")
{
    arr = arr.ToLower();
    for (int i = 1; i < arr.Length; i++)
        for (int j = 0; j < arr.Length - i; j++)
        {
            if (arr[j].CompareTo(arr[j + 1]) > 0)
                arr = arr.Substring(0, j) + arr[j + 1] + arr[j] + arr.Substring(j + 2);
        }

    return arr;
}
static char[] Duplicate(string str)
{
    var ans = new StringBuilder();
    str = str.ToLower();
    for (int i = 0; i < str.Length; i++)
    {
        if (!ans.ToString().Contains(str[i]) && str.Substring(str.IndexOf(str[i]) + 1).Contains(str[i], StringComparison.InvariantCultureIgnoreCase) == true)
            ans.Append(str[i]);
    }
    return ans.ToString().ToArray();
}
