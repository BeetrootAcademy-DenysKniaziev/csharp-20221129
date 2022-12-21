using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            myArray = myArray.InputData();

            Console.WriteLine($"Original array is:");
            PrintSorting(myArray);

            Console.WriteLine($"Bubble array is:");
            PrintSorting(BubbleAlgorithm(myArray));

            myArray = myArray.InputData();

            Console.WriteLine($"Original array is:");
            PrintSorting(myArray);

            Console.WriteLine($"Insertion array is:");
            PrintSorting(InsertionAlgorithm(myArray));
            Console.WriteLine();

            Console.WriteLine("Extra task");
            myArray = myArray.InputData();
            Console.WriteLine($"Original array is:");
            PrintSorting(myArray);

            SortAlgorithmType algorithmType = ChoiceAlgorithm($"Please choice algorithm of sorting: 1.{nameof(SortAlgorithmType.SelectionAlgorithm)}, 2.{nameof(SortAlgorithmType.BubbleAlgorithm)}, 3.{nameof(SortAlgorithmType.InsertionAlgorithm)}");

            OrderBy orderBy = ChoiceOrderType("Enter type if sort: 1.Asc, 2.Desc");

            PrintSorting(myArray.Sort(algorithmType, orderBy));
        }

        public static SortAlgorithmType ChoiceAlgorithm(string message)
        {
            SortAlgorithmType index;
            do
            {
                Console.WriteLine(message);

            } while (!Enum.TryParse(Console.ReadLine(), out index));
            return index;
        }

        public static OrderBy ChoiceOrderType(string message)
        {
            OrderBy index;
            do
            {
                Console.WriteLine(message);

            } while (!Enum.TryParse(Console.ReadLine(), out index));
            return index;
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
            for (int i = 0; i < myArray.Length -1; i++)
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
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 0; j < myArray.Length - i - 1; j++)
                {
                    if (myArray[j] > myArray[j + 1])
                    {
                        myArray.Swap(j, j + 1);
                    }
                }                
            }
            return myArray;
        }

        public static int[] InsertionAlgorithm(this int[] myArray)
        {
            for (int i = 1; i < myArray.Length; i++)
            {
                var val = myArray[i];
                var flag = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < myArray[j])
                    {
                        myArray[j + 1] = myArray[j];
                        j--;
                        myArray[j + 1] = val;
                    }
                    else flag = 1;
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
        
        public enum SortAlgorithmType
        {
            SelectionAlgorithm = 1,
            BubbleAlgorithm = 2,
            InsertionAlgorithm = 3,
        }

        public enum OrderBy
        {
            Asc = 1,
            Desc = 2
        }

        public static int[] Sort(this int[] myArray, SortAlgorithmType sortType, OrderBy orderBy)
        {
            switch(sortType)
            {
                case SortAlgorithmType.SelectionAlgorithm:
                    myArray = myArray.SelectionAlgorithm();
                    break;
                case SortAlgorithmType.BubbleAlgorithm:
                    myArray = myArray.BubbleAlgorithm();
                    break;
                case SortAlgorithmType.InsertionAlgorithm:
                    myArray = myArray.InsertionAlgorithm();
                    break;
            }

            if (orderBy == OrderBy.Desc)
            {
                 return myArray.Reverse().ToArray();
            }
            return myArray;
        }           
    }
}
