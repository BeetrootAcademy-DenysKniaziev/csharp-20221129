using System.Text.RegularExpressions;
bool Compare(string str1, string str2)
{
    if (str1 == str2)
    {
        return true;
    }
    else
    {
        return false;
    }
}
string Analyze(string str)
{
    var chars = str.ToCharArray();
    int digits = 0;
    int alphabet = 0;
    int others = 0;

    foreach (char c in chars)
    {
        if ((int)Char.GetNumericValue(c) != -1)
        {
            digits++;
        }
        else if (Regex.IsMatch(c.ToString(), @"[a-z]+$") || Regex.IsMatch(c.ToString(), @"[а-я]+$"))
        {
            alphabet++;
        }
        else
        {
            others++;
        }
    }
    string g = $"Digits:{digits}; Alphabets:{alphabet}; others:{others}";
    return g;
}
string Sort(string str)
{

    char[] chars = str.ToCharArray();
    Array.Sort(chars);
    return new String(chars);
}
char[] Duplicate(string stroka)
{
    string newStr = "";

    for (int i = 0; i < stroka.Length; i++)
    {
        for (int k = 0; k < stroka.Length; k++)
        {
            if (stroka[i] == stroka[k] && i != k && stroka[i] != ' ')
            {
                if (newStr.Length != 0 && newStr.Contains(stroka[i])) continue;
                newStr += stroka[i];
            }

        }
    }
    return newStr.ToCharArray();
}
