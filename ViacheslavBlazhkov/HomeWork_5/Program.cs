class HomeWork_5
{
    // Task 1 ------------------------------------------
    static int MaxValue(params int[] numbers)
    {
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max) max = numbers[i];
        }
        return max;
    }

    // Task 2 ------------------------------------------
    static int MinValue(params int[] numbers)
    {
        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min) min = numbers[i];
        }
        return min;
    }

    // Task 3 ------------------------------------------
    static bool TrySumIfOdd(int first, int second, out int sum)
    {
        sum = first + second;
        if (sum % 2 != 0) return true;
        else return false;
    }

    // Task 4 ------------------------------------------
    static int MaxValue(int first, int second, int third)
    {
        int max = first;
        if (first > second && first > third) max = first;
        else if (second > third) max = second;
        else max = third;
        return max;
    }
    static int MaxValue(int first, int second, int third, int fourth)
    {
        int max = first;
        if (first > second && first > third && first > fourth) max = first;
        else if (second > third && second > fourth) max = second;
        else if (third > fourth) max = third;
        else max = fourth;
        return max;
    }
    static int MinValue(int first, int second, int third)
    {
        int min = first;
        if (first < second && first < third) min = first;
        else if (second < third) min = second;
        else min = third;
        return min;
    }

    static int MinValue(int first, int second, int third, int fourth)
    {
        int min = first;
        if (first < second && first < third && first < fourth) min = first;
        else if (second < third && second < fourth) min = second;
        else if (third < fourth) min = third;
        else min = fourth;
        return min;
    }

    // Extra Task ---------------------------------------------
    static string Repeat(string text, int count)
    {
        string newStr = text;
        for (int i = 0; i < count; i++)
        {
            newStr += text;
        }
        return newStr;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("1. Max value: " + MaxValue(2, 3, 6, 1, 2, 8, 4, 9, 2, 4));
        Console.WriteLine("2. Min value: " + MinValue(2, 3, 6, 1, 2, 8, 4, 9, 2, 4));
        int sum;
        Console.WriteLine("3. " + TrySumIfOdd(1, 2, out sum) + ", Sum: " + sum);
        Console.WriteLine("4. Max value: " + MaxValue(2, 3, 6));
        Console.WriteLine("   Max value: " + MaxValue(5, 3, 4, 3));
        Console.WriteLine("   Min value: " + MinValue(5, 3, 4));
        Console.WriteLine("   Min value: " + MinValue(5, 3, 4, 4));
        Console.WriteLine("5. " + Repeat("Cat", 4));
    }
}