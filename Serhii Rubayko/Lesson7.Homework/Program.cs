using System.Text;

class String
{
    static bool SringEqual(string word1, string word2)
    {
        if (word1 == word2)
            return true;
        return false;
    }

    static int NumberofChars(string sentence)
    {
        int tmp = 0;

        foreach (var ch in sentence)
        {
            if (ch == ' ') continue;

            tmp++;
        }

        return tmp;

    }
    static int NumberofRunes(string sentence)
    {

        int count = 0;

        foreach (Rune rune in sentence.EnumerateRunes())
        {
            if (Rune.IsLetter(rune))
            {
                count++;
            }

        }
        return count;
    }

    static string SortChar(string word)
    {
               
        char[] chars = word.ToLower().ToCharArray();

        
        for (int i = 1; i < chars.Length; i++)
        {
            char key = chars[i];
            int j = i - 1;
            while (j >= 0 && chars[j] > key)
            {
                chars[j + 1] = chars[j];
                j -= 1;
            }
            chars[j + 1] = key;
        }

        return new string(chars).Trim();

    }

    static char [] StringToArray(string s)
    {
       char[] chars = s.ToCharArray();
        return chars;
    }

    static void PrintArray(char[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"'{item}'".PadRight(3, ' '));
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine(1);

        var c = "alfa";
        var d = "alfa";

        Console.WriteLine($"Words '{c}' and '{d}' equal - {SringEqual(c, d)}");

        Console.WriteLine();
        Console.WriteLine(2);

        var sentence1 = "One two three - rat on the tree... 1, 2, 3, 4, 5, once I caught a fish alive...";

        //int A = NumberofChars(sentence1);

        Console.WriteLine($"Sentence '{sentence1}' contain <{NumberofChars(sentence1)}> chars");
        
        Console.WriteLine();
        Console.WriteLine(3);

        var word = "Enjoy the silence";
                
        Console.WriteLine($"Letters of the '{word}' in alphabetical order is '{SortChar(word)}'");

        Console.WriteLine();
        Console.WriteLine(4);

        var s = "How match is the fish";

        Console.WriteLine($"String '{s}' transform to array \n");
        PrintArray(StringToArray(s));
    }

}

