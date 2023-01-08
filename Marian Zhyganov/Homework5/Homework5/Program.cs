
Console.WriteLine("Task 1");

var firstNum = 0;
var secondNum = 0;
string stop;
do
{

    Console.Write("Please input first number: ");
    firstNum = int.Parse(Console.ReadLine());

    Console.Write("Please input second number: ");
    secondNum = int.Parse(Console.ReadLine());



    var MaxDivider = 1;

    for (int i = 1; i <= Math.Min(firstNum, secondNum); i++)
    {

        if (firstNum % i == 0 && secondNum % i == 0)
        {
            MaxDivider = i;
        }

    }
    Console.WriteLine(MaxDivider);



    Console.WriteLine("you wona stop?(Yes or No)");
    stop = Console.ReadLine();
} while (stop != "Yes");



Console.WriteLine("Task 2");

Console.Write("Please enter value: ");
int value = int.Parse(Console.ReadLine());

int res = 2;
int primeNum = 0;

Console.Write($"your prime number from the {value} :");
Console.Write($"{res}");

for (int i = 2; i <= value; i++)
{
    for (int j = 2; j < i; j++)
    {
        if (i % j != 0)
        {
            primeNum = i;
        }
        else
        {
            primeNum = 0;
            break;
        }
    }
    if (primeNum != 0)
    {
        Console.Write($",{primeNum}");
    }

    res += primeNum;
}

Console.WriteLine($"\nYour sum of prime numbers from the number {value} = [{res}] ");