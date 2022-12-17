// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!!!");
//Task:

//Implement 3 sort algorithms:

//Selection
//Bubble
//Insertion

//Extra:
//Define enum SortAlgorithmType with all 3 algorithms types and create single function Sort that will accept array and SortAlgorithmType and use passed algorithm to sort array

//Define enum OrderBy with 2 values: Asc and Desc and update Sort method with this parameter that will change sort order


using System;
using System.Linq;
using System.Collections.Generic;

namespace Homework {
        public class Homework6
        {

        enum OrderBy { Asc, Desc }
        enum SortAlgorithmType { Selection, Bubble, Insertion}
        public static void Main(string[] args)
        {
            var a = new int[] { 5,7,2,5,-2,9,0,3};
            sorting(a, SortAlgorithmType.Selection, OrderBy.Desc);
            int[] sorting(int[] a, SortAlgorithmType sortType, OrderBy dir)
            {
                int d = 1;
                int[] b = a;
                int start = 1, end = b.Length-1;
                if (dir == OrderBy.Desc) { d = -1; start = b.Length - 1; end = 0; }

                //Bubble Asc & Desc
                if (sortType == SortAlgorithmType.Bubble) {
                    for (int i = 0; i < b.Length; i++) {
                        for (int j = start; ; j += d) {
                            if (dir == OrderBy.Desc && j <= end - i * d) break;
                            if (dir == OrderBy.Asc && j >= end - i * d) break;
                            if (b[j] > b[j + d]) (b[j], b[j + d]) = (b[j + d], b[j]);
                        }
                    }
                }

                //Insertion Asc & Desc
                if (sortType == SortAlgorithmType.Insertion) {
                    if (dir == OrderBy.Asc) {
                        for (int j = 1; j < b.Length; j++) {
                            for (int k = j; k>0; k--)  {
                                if (b[k] < b[k - 1]) (b[k], b[k - 1]) = (b[k - 1], b[k]);
                                else break;
                            }
                        }
                    }
                    if (dir == OrderBy.Desc)  {
                        for (int j = b.Length - 2; j >= 0; j--)   {
                            for (int k = j; k < b.Length-1; k++)  {
                                if (b[k] < b[k + 1]) (b[k], b[k + 1]) = (b[k + 1], b[k]);
                                else break;
                            }
                        }
                    }
                }

                //Selection Asc & Desc
                if (sortType == SortAlgorithmType.Selection) {
                    if (dir == OrderBy.Asc) {
                        for (int i = 0; i < b.Length; i++) {
                            int min = i;
                            for (int j = i; j < b.Length; j++) {
                                if (b[j] < b[min]) min = j; 
                            }
                            (b[min], b[i]) = (b[i], b[min]);
                        }
                    }
                    if (dir == OrderBy.Desc) {
                        for (int i = b.Length-1; i >= 0 ; i--) {
                            int min = i;
                            for (int j = i; j >=0; j--) {
                                if (b[j] < b[min]) min = j;
                            }
                            (b[min], b[i]) = (b[i], b[min]);
                        }

                    }
                }

                foreach (var n in b)
                Console.WriteLine(n);
                return b;
            }
        }
    }
}
