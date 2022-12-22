Console.WriteLine("You live deep in forest in own house");
Console.WriteLine("Now you in bed");
Console.WriteLine("Pres 1 to stay in bed \t" + "Pres 2 to wake up and go to kitchen to find something to eat\t" + "Pres 3 to wake up and go brush your teeth");

int choice = int.Parse(Console.ReadLine());

bool finish = false;

while (finish == false)
{

    if (choice == 1)
    {
        Console.Clear();
        Console.WriteLine("you stayed asleep");
        finish = true;
    }
    else if (choice == 2)
    {
        Console.Clear();
        Console.WriteLine("You come to kitchen and find only dried meat ");
    }
    else if (choice == 3)
    {
        Console.Clear();
        Console.WriteLine("You come brush teeth,but you forgot to bring water yesterday");
        Console.WriteLine("Press K for go to kitchen to find something to eat\t" + "Press W for go get water from the well");

        int choice2 = int.Parse(Console.ReadLine());

        if (choice2 == 1)
        {
            Console.Clear();
            Console.WriteLine("You come to kitchen and find only dried meat");
        }

    }
}