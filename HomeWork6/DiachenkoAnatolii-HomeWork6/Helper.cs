using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiachenkoAnatolii_HomeWork6
{
    public static class Helper
    {
        public static int[] InputData(this int[] myArray)
        {
            var value = new Random();

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = value.Next(100);
            }
            return myArray;
        }

        public static void RunSorting(this int[] myArray)
        {
            Console.WriteLine($"Original array is:");
            PrintSorting(myArray);
            Console.WriteLine($"Selection array is:");
            PrintSorting(SelectionAlgorithm(myArray));
            //PrintSorting(BubbleAlgorithm(myArray));
            //PrintSorting(InsertionAlgorithm(myArray));

        }

        public static void PrintSorting(this int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write($"{myArray[i]} ");
            }
            Console.WriteLine();
        }

        public static int[] SelectionAlgorithm(this int[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {

                for (int j = i + 1; j < myArray.Length; j++)
                {
                    if (myArray[i] > myArray[j])
                    {
                        var temp = myArray[j];
                        myArray[j] = myArray[i];    
                        myArray[i] = temp;
                    }
                }
            }            
            return myArray;
        }

        public static int[] BubbleAlgorithm(this int[] myArray)
        {
            return new int[10];
        }

        public static int[] InsertionAlgorithm(this int[] myArray)
        {
            return new int[10];
        }
    }
}
