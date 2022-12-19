//create next methods:
//Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method
//Analyze that will return number of alphabetic chars in string, digits and another special characters
//Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')
//Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])

using System;
using System.Text;

namespace Homework
{
    public class Homework7
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Statment that string one is equal to string two is " + Compare("a", "aa"));
            Console.WriteLine();
            string text = " Krokodyl 144 .~~";
            var analyzeRes = Analyze(text);
            Console.WriteLine("Letters " + (analyzeRes).Item1 + "\nDigits " + (analyzeRes).Item2 + "\nOther " + (analyzeRes).Item3);
            Console.WriteLine("Sorted output: " + Sort("frtAb!!cc__b azy3xwvu  улш коацй tsrqpon74587:'mlkjihgfedcba")); //zyxwvutsrqponmlkjihgfedcba
            Console.WriteLine(Duplicate("frtAb!!cc__b azy3xwvu  улш коацй tsrqpon74587:'mlkjihgfedcba"));
        }

        //Method Compare
        static bool Compare(string a, string b) {
            if (a.Length == b.Length) {
                for (int i = 0; i < a.Length; i++) {
                    if (a[i] != b[i]) return false;
                }
            }
            else return false;
            return true;
        }

        //Method Analyze
        static (int, int, int) Analyze(string a) {
            int nC = 0, nD = 0;
            foreach (char c in a) {
                if (char.IsLetter(c)) nC++;
                if (char.IsDigit(c)) nD++;
            }
            return (nC, nD, a.Length - nC - nD);
        }

        //Method Sort
        static string Sort(string a) {
            string cleanA = "";
            foreach (var cA in a) if (char.IsLetter(cA)) cleanA += cA;
            var b = (cleanA.ToLower()).ToCharArray();
            string ext = "";
            foreach (char letter in sorting(b)) ext += letter;
            return ext;
        }
        //Function sorting for Sort method task
        static char[] sorting(char[] a) {
            var b = a;
            for (int i = 0; i < b.Length - 1; i++) {
                for (int j = 0; j < b.Length - 1 - i; j++) {
                    if (b[j] > b[j + 1]) (b[j], b[j + 1]) = (b[j + 1], b[j]);
                }
            }
            return b;
        }
        //Method Duplicate
        static char [] Duplicate(string a)
        {
            int bLanght = a.Length;
            string temp;
            string duplicates = "";

            for (; a.Length > 0;)  {
                temp = a[0].ToString();
                a = a.Replace(a[0].ToString(), "");
                if ((bLanght - a.Length) > 1) duplicates += temp;
                bLanght= a.Length;  
            }
            return duplicates.ToCharArray();
        }
    }
}