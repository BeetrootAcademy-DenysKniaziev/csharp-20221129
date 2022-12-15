Console.Write("Please enter user name: ");
string username = Console.ReadLine();
bool end = false;
Console.WriteLine($"Hello {username}, welcome to the rpg game");

Console.WriteLine("Which hero will you choose. Chooose frome the options ");
Console.WriteLine("For exemple\"1 or 2 or 3 or 4\"");
Console.WriteLine("1. Swordsman");
Console.WriteLine("2. Bowman");
Console.WriteLine("3. Wizard");
Console.WriteLine("4. Tank");


while (!end)
{
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Wow you chose Swordman");
            end = true;
            Console.WriteLine($"Okey Swordman {username},now choose your  weapon");
            Console.WriteLine("1: Double sword.");
            Console.WriteLine("2: Small daggers");
            Console.WriteLine("3: Great sword");
            Console.WriteLine("4: Rapier");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Good choice!");
                    Console.WriteLine("Double sword gives you " +
                        "agility - 15%;" +
                        "power - 20%");
                    break;
                case "2":
                    Console.WriteLine("Good choice!");
                    Console.WriteLine("Small dagger gives you " +
                        "agility - 50%" +
                        "power - 10%");
                    break;
                case "3":
                    Console.WriteLine("Good choice!");
                    Console.WriteLine("Great sword gives you " +
                        "agility - 5%" +
                        "power - 50%");
                    break;
                case "4":
                    Console.WriteLine("Good choice!");
                    Console.WriteLine("Rapier gives you " +
                        "agility - 35%" +
                        "power - 15%");
                    break;
                default:
                    Console.WriteLine("Your choose is wrong, please repeat your version");
                    continue;
                    break;
            }
            Console.WriteLine($"Okey Swordman {username},now choose your armor");
            Console.WriteLine("1: Wooden armore");
            Console.WriteLine("2: Iron armore");
            Console.WriteLine("3: Titanium armore");
            Console.WriteLine("4: Demon armore");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Wooden armore gives you" +
                        "armore - 10%");
                    break;
                case "2":
                    Console.WriteLine("Iron armore gives you " +
                        "armore - 25%");
                    break;
                case "3":
                    Console.WriteLine("Titanium armore gives you " +
                        "armore - 50%");
                    break;
                case "4":
                    Console.WriteLine("Demon armore gives you " +
                        "armore - 99%");
                    break;
                default:
                    Console.WriteLine("Your choose is wrong, please repeat your version");
                    continue;
                    break;
            }
            Console.WriteLine("It`s great that you are ready to go into this dengerous world" +
                $"Good lack Swordman{username}");
            break;
        case "2":
            Console.WriteLine("Wow you chose Bowman");
            end = true;
            Console.WriteLine($"Okey Bowman {username},now choose your armor and weapon");

            break;
        case "3":
            Console.WriteLine("Wow you chose Wizard");
            end = true;
            Console.WriteLine($"Okey Wizard {username},now choose your armor and weapon");
            break;
        case "4":
            Console.WriteLine("Wow you chose Tank");
            end = true;
            Console.WriteLine($"Okey Tank {username},now choose your armor and weapon");
            
            break;
        default:
            Console.WriteLine("Your choose is wrong, please repeat your version");
            continue;
            break;
    }
    
    while (!end)
    {

    }
}

