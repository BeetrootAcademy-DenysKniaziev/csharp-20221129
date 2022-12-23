using System;
using System.Diagnostics.Tracing;

bool Compare(string str1, string str2)
{
    if (str1 == str2)
    {
        return true;
    }
    return false;
}

(int chars, int digits, int specialCharacters) Analize(string str)
{
    int chars = 0;
    int digits = 0;
    int specialCharacters = 0;
    foreach (char word in str)
    {
        if (char.IsDigit(word))
        {
            digits++;
        }
        else if (char.IsLetter(word))
        {
            chars++;
        }
        else if (char.IsPunctuation(word))
        {
            specialCharacters++;
        }
    }
    return (chars,  digits, specialCharacters);
}

string Sort(string str)
{
    char[] arr = str.ToCharArray();
    for (int i = 0; i < arr.Length - 1; i++)
    {
        int index = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[j] < arr[index])
            {
                index = j;
            }
        }
        char temp = arr[index];
        arr[index] = arr[i];
        arr[i] = temp;
    }
    str = new string(arr);
    return str;
}

char[] Duplicate(string str)
{
    string temp = "";
    for (int i = 0; i < str.Length - 1; i++)
    {
        for (int j = i; j < str.Length - 1; j++)
        {
            if (str[j] != ' ' && str[i] == str[j])
            {
                temp += str[i];
            }
        }
    }
    char[] arr = temp.ToCharArray();
    return arr;
}