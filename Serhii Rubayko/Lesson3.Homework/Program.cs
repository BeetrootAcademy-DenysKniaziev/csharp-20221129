#region Metod 1

int X1 = 10;
int Y1 = 12;
int S1 = X1;

for (int i1 = X1; i1 < Y1; i1++)
{
    X1++;
    S1 += X1;
}

Console.WriteLine(S1);

Console.ReadKey();
#endregion

#region Metod 1.5
Console.WriteLine("Input integer X(from - 100 to 100)");
string inputX = Console.ReadLine();

int X = Int16.Parse(inputX);


//string inputY;
Console.WriteLine("Input integer Y(from - 100 to 100)");

string inputY = Console.ReadLine();

int Y = Int16.Parse(inputY);

int Temp1 = X;
int Temp2 = Y;

if (X > Y)
{
    X = Temp2;
    Y = Temp1;
}

Console.WriteLine("{0} {1}", X, Y);

int S = X;

for (int i = X; i < Y; i++)
{

    X++;
    S += X;

}
Console.WriteLine("Sum of all numbers between " +
        "{0} and {1} is {2}", Temp1, Temp2, S);

Console.ReadKey();

#endregion

string input;
bool finished = false;
Console.WriteLine("Do you wanna play The Game (Y/N)");

while (!finished)
{
    input = Console.ReadLine();

    if (input == "Y")
    {
        Console.WriteLine("Lets begin!");

        Console.WriteLine("guess the number from 0 till 9");

        while (!finished)
        {
            input = Console.ReadLine();
            int Z = Int16.Parse(input);

            if (0 <= Z & Z <= 9)
            {
                Console.WriteLine("You Win!");
                finished = true;
                break;
            }
            else
                Console.WriteLine("Wrong input! Repeat:");
        }

    }
    else if (input == "N")
    {
        Console.WriteLine("Ok, Good Luck!");
        break;
    }
    else
        Console.WriteLine("Wrong input! Repeat:");
}

Console.ReadKey();