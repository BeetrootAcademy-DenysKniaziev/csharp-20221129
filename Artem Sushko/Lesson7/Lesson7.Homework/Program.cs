internal class Program
{
    static bool Compare(string str1, string str2)
    {
        if (str1 == str2)
            return true;

        return false;
    }

    static string Analyze(string str3)
    {
        var IsSymbol = 0;
        var IsLetter = 0;
        var IsDigit = 0;
        for (int i = 0; i < str3.Length; i++)
        {
            if (char.IsLetter(str3[i]))
            {
                IsLetter++;
            }
            else if (char.IsDigit(str3[i]))
            {
                IsDigit++;
            }
            else IsSymbol++;
        }
        string res = $"Amount of Letters is {IsLetter}\nAmount of Digits is {IsDigit}\nAmount of another special characters is {IsSymbol}";
        return res;
    }

    static string Sort(string str4)
    {
        char[] strchar = str4.ToCharArray();
        char tmp;
        for (int i = 0; i < strchar.Length - 1; i++)
        {
            for (int j = 0; j < strchar.Length - 1 - i; j++)
            {
                if (strchar[j] > strchar[j + 1])
                {
                    tmp = strchar[j + 1];
                    strchar[j + 1] = strchar[j];
                    strchar[j] = tmp;
                }
            }
        }
        String str5 = new string(strchar);
        return str5;
    }

    static string Duplicate(string str4)
    {
        string res = "";
        for (int i = 0; i < str4.Length; i++)
        {
            if (!res.Contains(str4[i]) && str4.Substring(i + 1).Contains(str4[i]))
            {
                res += str4[i];
            }
        }
        return res;
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Enter first string:");
        var str1 = Console.ReadLine();
        Console.WriteLine("Enter second string:");
        var str2 = Console.ReadLine();
        var res1 = Compare(str1, str2);
        Console.WriteLine("Strings are equal: " + res1);

        Console.WriteLine("\nEnter string:");
        var str3 = Console.ReadLine();
        var res2 = Analyze(str3);
        Console.WriteLine(res2);

        Console.WriteLine("\nEnter string:");
        var str4 = Console.ReadLine();
        var res3 = Sort(str4);
        Console.WriteLine("Sorted String in alphabetical order: " + res3);

        Console.WriteLine("\nEnter string:");
        var str5 = Console.ReadLine().ToLower();
        char[] res4 = Duplicate(str5).ToCharArray();

        Console.Write("Characters that are duplicated: ");
        for (int i = 0; i < res4.Length; i++)
        {
            Console.Write(res4[i] + " ");
        }
        Console.WriteLine();
    }
}