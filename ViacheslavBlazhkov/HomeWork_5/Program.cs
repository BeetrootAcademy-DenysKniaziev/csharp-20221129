//Task 1------------------------------------------------------ -
static int LargestMultiple(int firstValue, int secondValue)
{
    if (firstValue < 1 || secondValue < 1)
    {
        Console.Write("Incorect input, ");
        return -1;
    }

    int min = Math.Min(firstValue, secondValue);
    for (int i = min; ; i--)
    {
        if (firstValue % i == 0 && secondValue % i == 0) return i;
    }
}
Console.WriteLine(LargestMultiple(0, 15));

// Task 2 -------------------------------------------------------
static bool PrimesSum(int number)
{
    for (int i = 2; i < number; i++)
    {
        if (number % i == 0 && number != i)
        {
            return false;
        }
    }
    return true;
}

static void Diapason(int numb)
{
    int sum = 0;
    for (int i = 2; i <= numb; i++)
    {
        if (PrimesSum(i) == true)
        {
            sum += i;
        }
    }
    Console.WriteLine(sum);
}
Diapason(11);

// Extra Task ---------------------------------------------------
