using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        MaxValue(20, 40, 39, 51);
        MinValue(36, 28, 125, 30);
        TrySumIfOdd(2, 5, out int sum, out bool numberIsOdd);

    }

    #region First Task
    static void MaxValue(int num01, int num02, int num03, int num04)
    {
        int firstCalculation = Math.Max(num01, num02);
        int SecondCalculation = Math.Max(num03, num04);
        int result = Math.Max(firstCalculation, SecondCalculation);
        Console.WriteLine($"Maximum value among these numbers is: {result}");
    }
    #endregion

    #region Second Task
    static void MinValue(int num01, int num02, int num03, int num04)
    {
        int firstCalculation = Math.Min(num01, num02);
        int SecondCalculation = Math.Min(num03, num04);
        int result = Math.Min(firstCalculation, SecondCalculation);
        Console.WriteLine($"Minimum value among these numbers is: {result}");
    }
    #endregion

    #region Third Task

    //Didn't manage to finish this one :(
    static bool TrySumIfOdd(int num1, int num2, out int sum, out bool numberIsOdd)
    {
        if ((num1 + num2) % 2 != 0)
        {
            sum = num1 + num2;
            numberIsOdd = false;
            return false;
        }
        else
        {
            sum = num1 + num2;
            numberIsOdd = true;
            return true;
        }
    }

    #endregion
 
}