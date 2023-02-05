using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lesson_7_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compare("pizda", "pizda"));
            Console.WriteLine("The following string contains the following numbers of letters," +
                "digits and special symbols: " + Analyze("Pidarasiq"));
            Console.WriteLine(SortMethod("hooeta"));
        }


        static bool Compare(string str1, string str2)
        {
            if (str1 == str2) return true;
            return false;
        }

        static (int digits, int alphabet, int specialSymbol) Analyze (string exampleOne)
        {
            int alphabet = 0; int digit = 0; int specialSymbol = 0;
            char[] temp = exampleOne.ToCharArray();
            foreach (var item in temp)
            {
                if ((item >= 65 && item <= 90) || (item >= 97 && item <= 122))
                {
                    alphabet++;
                }
                else if ((item >= 48) && (item <= 57))
                {
                    digit++;
                }
                else
                {
                    specialSymbol++;
                }
            }
            return (alphabet, digit, specialSymbol);
        }
        
        static string SortMethod(string exampleTwo)
        {
            char[] temp = exampleTwo.ToCharArray();
            for (int i = 0; i < temp.Length - 1; i++)
            {
                for (int j = i + 1; j < temp.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        char value = temp[i];
                        temp[i] = temp[j];
                        temp[j] = value;
                    }
                }
            }
            exampleTwo = new string(temp);
            return exampleTwo;
        }

        static string Duplicate(string exampleThree)
        {
            char[] temp = exampleThree.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                char currentItem = Convert.ToChar(i);
                for (int j = 0; j < temp.Length; j++)
                {
                    if(temp.Equals == currentItem)
                    {

                    }
                } 
            }

            foreach (var item in temp)
            {
                if(item)
            }
        }
    }
}