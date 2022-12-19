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
            Console.WriteLine($"Bubble array is:");
            PrintSorting(BubbleAlgorithm(myArray));
            Console.WriteLine($"Insertion array is:");
            PrintSorting(InsertionAlgorithm(myArray));

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
                        myArray.Swap(i, j);
                    }
                }
            }            
            return myArray;
        }

        public static int[] BubbleAlgorithm(this int[] myArray)
        {
            for (int i = 0; i < myArray.Length -1; i++)
            {
                    if (myArray[i] > myArray[i + 1])
                    {
                    myArray.Swap(i, i + 1);
                }
            }            
           return myArray;
        }

        public static int[] InsertionAlgorithm(this int[] myArray)
        {
            for (int i = 1; i < myArray.Length; i++)
            {
                var j = i;

                while (myArray[i] < myArray[--j] && j > 0)
                {
                    myArray.Swap(i, j);
                }
            }
            return myArray;
        }

        public static void Swap(this int[] myArray, int index1, int index2)
        {
            var temp = myArray[index1];
            myArray[index1] = myArray[index2];
            myArray[index2] = temp;           
        }     
    }
}
