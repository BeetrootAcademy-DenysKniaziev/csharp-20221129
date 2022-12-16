using System;

class Program
{
    static void sortStrings(String[] arr, int n)
    {
        String temp;

        for (int j = 0; j < n - 1; j++)
        {
            for (int i = j + 1; i < n; i++)
            {
                if (arr[j].CompareTo(arr[i]) > 0)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }

static bool stringCompare(String strng1, String strng2)
{
    char[] charArray1 = strng1.ToCharArray();
    char[] charArray2 = strng2.ToCharArray();

    if(charArray1.Length != charArray2.Length)
    {
        return false;
    }

    for (int i = 0; i < charArray1.Length; i++)
    {
            if (charArray1[i]!=charArray2[i])
            {
                return false;
            }
    }
        return true;
}

    static void stringAnalyze(String str)
    {
        int alp, digit, splch, i, l;
        alp = digit = splch = i = 0;
        
        l = str.Length;

        while (i < l)
        {
            if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
            {
                alp++;
            }
            else if (str[i] >= '0' && str[i] <= '9')
            {
                digit++;
            }
            else
            {
                splch++;
            }

            i++;
        }

        Console.Write("Number of Alphabets in the string is : {0}\n", alp);
        Console.Write("Number of Digits in the string is : {0}\n", digit);
        Console.Write("Number of Special characters in the string is : {0}\n", splch);
    }

    static string StringDuplicate(string stroka)
    {
       string duplicates="";

        for (int i = 0; i < stroka.Length; i++)
        {
            if (stroka.IndexOf(stroka[i]) != stroka.LastIndexOf(stroka[i]) && !duplicates.Contains(stroka[i]))
            {
                duplicates += stroka[i];
            }
        }

        return duplicates;
    }


   static void Main(String[] args)
    {
        Console.WriteLine("*********************************");

        String[] arr = {"h", "e",
                        "l", "l", "o"};
        int n = arr.Length;
        Console.WriteLine("String inputed : ");
        for (int i = 0; i < n; i++)
            Console.Write(arr[i]);
        
        
        sortStrings(arr, n);
        Console.WriteLine("\nStrings in sorted order are : ");
        for (int i = 0; i < n; i++)
            Console.Write(arr[i]);


        Console.WriteLine("\n*********************************");


        Console.WriteLine("Enter 1st string: ");
    String str1 = Console.ReadLine();

    Console.WriteLine("Enter 2nd string: ");
    String str2 = Console.ReadLine();

   bool b = stringCompare(str1, str2);
        if(b)
            {
            Console.WriteLine("Strings are equal!");
            }
                else
                    {
            Console.WriteLine("Strings are not equal!");
                    }

        Console.WriteLine("*********************************");

        Console.WriteLine("Input the string : ");
        String st = Console.ReadLine();

        stringAnalyze(st);

        Console.WriteLine("*********************************");
        Console.WriteLine("Enter string: ");
        String s = Console.ReadLine();

        string res = StringDuplicate(s);
        Console.WriteLine($"Duplicates: {res}");
         
    }

}