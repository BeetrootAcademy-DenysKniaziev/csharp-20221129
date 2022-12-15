using System;

// filling the array with numbers
int[,] array = new int[10, 10];
Random rand = new Random();
for (int i = 0; i < array.GetLength(0); i++)
{
    for (int k = 0; k < array.GetLength(1); k++)
    {
        array[i, k] = rand.Next(0, 100);
    }
}


void FirstVariant(int[,] array)
{
    double sum = 0;
    int count = 0;
    Console.WriteLine("Array: \n");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = 0; k < array.GetLength(1); k++)
        {
            if (k <= i)
            {
                sum += array[i, k];
                count++;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{array[i, k]}".PadLeft(2, ' ') + "  ");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    double avg = sum / count;
    Console.WriteLine($"\nAverage = {Math.Round(avg, 1)}\n\n");
}

void SecondVariant(int[,] array)
{
    double sum = 0;
    int count = 0;
    int x = 9;
    Console.WriteLine("Array: \n");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = 0; k < array.GetLength(1); k++)
        {
            if (k <= x)
            {
                sum += array[i, k];
                count++;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write($"{array[i, k]}".PadLeft(2, ' ') + "  ");
            Console.ResetColor();
            
        }
        x--;
        Console.WriteLine();
    }
    double avg = sum / count;
    Console.WriteLine($"\nAverage = {Math.Round(avg, 1)}\n\n");
}
void ThirdVariant(int[,] array)
{
    int x1 = 0;
    int x2 = 9;

    double sum = 0;
    int count = 0;

    Console.WriteLine("Array: \n");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int k = 0; k < array.GetLength(1); k++) 
        {
            if (k <= x2 && k >= x1) 
            {
                sum += array[i, k];
                count++;
                Console.ForegroundColor = ConsoleColor.Blue;

            }
            Console.Write($"{array[i, k]}".PadLeft(2, ' ') + "  ");
            Console.ResetColor();
        }

        if (i < 4)
        {
            x1++; x2--;
        }
        else if (i > 4) 
        {
            x1--; x2++;
        }   

        Console.WriteLine();
    }
    double avg = sum / count;
    Console.WriteLine($"\nAverage = {Math.Round(avg, 1)}\n\n");
}

FirstVariant(array);
SecondVariant(array);
ThirdVariant(array);