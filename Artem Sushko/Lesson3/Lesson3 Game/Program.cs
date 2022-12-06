Console.Write("Enter your name: ");
string name = Console.ReadLine();
bool finish = false;


while (!finish)
{
    Console.Clear();
    Console.Write($"{name}, do you want to travel?(CHOOSE: Y(Yes) or N(No): ");
    string ans = Console.ReadLine();
    if (ans == "Y")
    {
        while (true)
        {

            Console.Clear();
            Console.Write($"{name}, where do you want to go? (F(Forest) or M(Mountains)): ");
            string choice = Console.ReadLine();
            if (choice == "F")
            {
                while (true)
                {

                    Console.Clear();
                    Console.Write($"{name} select the way! (CHOOSE: L(Left) or R(Right)): ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "L")
                    {
                        Console.WriteLine($"{name}, you have found a bandit camp! Unlucky. GAME IS OVER!!!");
                        finish = true;
                        break;
                    }
                    else if (choice2 == "R")
                    {
                        Console.WriteLine($"{name}, you have found a beautiful place! Enjoy and have a rest:)");
                        finish = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input");
                    }
                    
                    Console.ReadLine();
                }
                break;
            }
            else if (choice == "M")
            {
                while (true)
                {

                    Console.Clear();
                    Console.Write($"{name} select the way! (CHOOSE: L(Left) or R(Right)): ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "L")
                    {
                        Console.WriteLine($"{name}, you have found a beautiful mountain river! Enjoy and have a rest:)");
                        finish = true;
                        break;
                    }
                    else if (choice2 == "R")
                    {
                        Console.WriteLine($"{name}, you have met a mountain Lion! Unlucky. GAME IS OVER!!!");
                        finish = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input");
                    }
                    Console.ReadLine();
                }
                break;

            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
            Console.ReadLine();
            
        }
    }
    else if (ans == "N")
    {
        Console.WriteLine($"OK, {name}, stay home. BYE!");
        break;
    }
    else 
    { 
        Console.WriteLine("Wrong Input");
    }
    Console.ReadLine();
    
}
Console.WriteLine("Come again!");

