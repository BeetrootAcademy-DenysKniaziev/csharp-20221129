using System.Text;

public class WorkWithStrings
{
    static public bool MyEquals(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;
        for (int i = 0; i < s1.Length; i++)
            if (s1[i] != s2[i])
                return false;
        return true;
    }
    public static (int letter, int number, int another) Analyze(string s)
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
    public static char[] Duplicate(string str)
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
}