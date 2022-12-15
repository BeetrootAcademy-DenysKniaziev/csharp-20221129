using System;

string input;
bool finished = false;

Console.WriteLine("Hello.\nWhat is your name?");
string name = Console.ReadLine();
Console.WriteLine($"Hello, {name}! \nDo you want to go hunting with me? (Y/N)");

while (!finished)
{
    input = Console.ReadLine();

    if ((input == "Y") || (input == "y"))
    {
        Console.WriteLine("Choose the weapon: A - axe, B - bow, H - will hunt with my hands");
        while (!finished)
        {
            input = Console.ReadLine();
            switch (input)
            {
                case "A":
                    Console.WriteLine("So axe, perfect!");
                    Console.WriteLine("Who do you want to hunt? (H - hare, B - boar, D - deer)");
                    while (!finished)
                    {
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "H":
                            Console.WriteLine("There are a hare - cath him! \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("Well done, looks like we have a dinner today!");
                                        finished = true;
                                    }
                                    else if ((input == "N") || (input == "n"))
                                    {
                                        Console.WriteLine("It's no surprise, harese are nimble. Let's try again!");
                                        Console.WriteLine("Did you managed? (Y/N)");
                                        while (!finished)
                                        {
                                            input = Console.ReadLine();
                                            if ((input == "Y") || (input == "y"))
                                            {
                                                Console.WriteLine("I dont think so! You should have brought a bow.");
                                            }
                                            else if ((input == "N") || (input == "n"))
                                            {
                                                Console.WriteLine("You should have brought a bow.");
                                            }
                                            else
                                            {
                                                finished = true;
                                             }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                        finished = true;
                                    }
                                }
                                finished = true;
                                break;

                            case "B":
                                Console.WriteLine("Therer are a boar! Try to hit him with your axe. \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("Well done, looks like we have a dinner today!" );
                                        finished = true;
                                    }
                                    else if ((input == "N") || (input == "n"))
                                    {
                                        Console.WriteLine("Too bad. Let's try again!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                        finished = true;
                                    }
                                }
                                break;

                            case "D":
                                Console.WriteLine("The deer is at those boushes. Try to hit him! \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("Nope! He is too fast for your axe.");
                                        finished = true;
                                     }
                                    else
                                    {
                                        Console.WriteLine("I though so. It's impossible to hunt a deer with this heavy axe!");
                                        finished = true;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                finished = true;
                                break;
                         }
                    }
                    finished = true;
                    break;

                case "B":
                    Console.WriteLine("Your bow looks good!");
                    Console.WriteLine("Who do you want to hunt? (H - hare, B - boar, D - deer)");
                    while (!finished)
                    {
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "H":
                                Console.WriteLine("There are a hare - cath him! \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("Well done, looks like we have a dinner today!");
                                        finished = true;
                                    }
                                    else if ((input == "N") || (input == "n"))
                                    {
                                        Console.WriteLine("Strange. Let's try again!");
                                        Console.WriteLine("Did you managed? (Y/N)");
                                        while (!finished)
                                        {
                                            input = Console.ReadLine();
                                            if ((input == "Y") || (input == "y"))
                                            {
                                                Console.WriteLine("Well done, looks like we have a dinner today!");
                                                finished = true;
                                            }
                                            else if ((input == "N") || (input == "n"))
                                            {
                                                Console.WriteLine("Maybe you sould lern how to use your bow");
                                                finished = true;
                                            }
                                            else
                                            {
                                                finished = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                        finished = true;
                                    }
                                }
                                finished = true;
                                break;

                            case "B":
                                Console.WriteLine("There are the boar! Try to shoot with your bow. \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("Well done, looks like we have a dinner today!");
                                        finished = true;
                                    }
                                    else if ((input == "N") || (input == "n"))
                                    {
                                        Console.WriteLine("This one is big, maybe you need to shout twice. \nDid you managed to hit him twice? (Y/N) ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                        finished = true;
                                    }
                                }
                                break;

                            case "D":
                                Console.WriteLine("The deer is at those boushes. Try to hit him! \nDid you managed? (Y/N)");
                                while (!finished)
                                {
                                    input = Console.ReadLine();
                                    if ((input == "Y") || (input == "y"))
                                    {
                                        Console.WriteLine("This one is big, maybe you need to shout twice. \nDid you managed to hit him twice? (Y/N)");
                                        while (!finished)
                                        {
                                            input = Console.ReadLine();
                                            if ((input == "Y") || (input == "y"))
                                            {
                                                Console.WriteLine("Well done, looks like we have a dinner today!");
                                                finished = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                                finished = true;
                                            }
                                         }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Maybe you sould lern how to use your bow");
                                        finished = true;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("It's not important! The dragon is approaching! Run for your life!");
                                finished = true;
                                break;
                        }
                    }
                    finished = true;
                    break;

                case "H":
                    Console.WriteLine("So you are tying to say that you will hunt a prey barehanded? HaHa. Let's see");
                    Console.WriteLine("Who do you want to hunt? (H - hare, B - boar, D - deer)");
                    input = Console.ReadLine();
                    Console.WriteLine("The dragon is approaching! And you have no weapon to fight him.\nYou're dead.");
                    finished = true;
                    break;

                default:
                    Console.WriteLine("I'm sorry, I didn't catch that. So what will it be: A - axe, B - bow, H - will hunt with my hands");
                    break;
            }
        }
    }
    else if ((input == "N") || (input == "n"))
    {
        Console.WriteLine("Ok, stay hungry");
        finished = true;
    }
    else
    {
        Console.WriteLine("Looks like you are crazy");
    }
    Console.WriteLine("FAREWELL");
}



