using System.Text.RegularExpressions;

bool Compare(string str1, string str2)
{
    if(str1 == str2) return true;
    return false;
}

int Analyze(string str)
{
    var chars = str.ToCharArray();
    int digits = 0;
    int alphabet = 0;
    int others = 0;

    foreach(char c in chars)
    {
        if((int)Char.GetNumericValue(c) != -1)
        {
            digits++;
        }
        else if(Regex.IsMatch(c.ToString(), @"[a-z]+$") || Regex.IsMatch(c.ToString(), @"[а-я]+$") ||
            Regex.IsMatch(c.ToString(), @"[A-Z]+$") || Regex.IsMatch(c.ToString(), @"[А-Я]+$"))
        {
            alphabet++;
        }
        else
        {
            others++;
        }        
    }

    return digits + alphabet + others;
}

string Sort(string str)
{
    //variant 1
    //return string.Concat(str.OrderBy(x => x)); 

    // variant 2
    char[] chars = str.ToCharArray();
    Array.Sort(chars);
    return new String(chars);
}

char[] Duplicate(string str)
{
    string newStr = "";

    for (int i = 0; i < str.Length; i++)
    {
        for (int k = 0; k < str.Length; k++)
        {
            if (str[i] == str[k] && i != k && str[i] != ' ')
            {
                if (newStr.Length != 0 && newStr.Contains(str[i])) continue;
                newStr += str[i];
            }
                
        }
    }
    return newStr.ToCharArray();
}

// Results
Console.WriteLine($"Strings is compared: {Compare("string", "string2")}");
Console.WriteLine($"Count of symbols: {Analyze("72wAJ-роОВв=83j")}");
Console.WriteLine($"Sorted string: {Sort("ahvcd")}");

Console.Write("Duplicated symbols: ");
char[] chArray = Duplicate("alright, let's do it.");
for (int i = 0; i < chArray.Length; i++)
{
    Console.Write(chArray[i] + " ");
}

Console.WriteLine();