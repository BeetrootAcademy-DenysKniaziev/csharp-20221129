Console.WriteLine("Hello there, I am urged to inform that a giant meteor" +
    "is about to hit our planet, what would you do?");
Console.WriteLine("Hide inside the fridge / Go to the nearest watch tower and see the disaster yourself");
Console.WriteLine("Hide / Watch");
string input = Console.ReadLine();
bool gameIsFinished = false;


while (!gameIsFinished)
{
    if (input == "Watch")
    {
        Console.WriteLine("Afrer a few minutes of running and climbing thousands of stairs you finally get" +
            "to see the meteor. It is landing in a few miles away and you see a huge flash which comes along" +
            "with a great wave that knocks you unconscious.");
        Console.WriteLine("Unfrotunately, you died.");
        gameIsFinished = true;
        break;
    }
    else if (input == "Hide")
    {
        Console.WriteLine("You have somehow managed to squeeze into the fridge and shut the door." +
            "Your house was destroyed by an expolsion but you did survive.");
        Console.WriteLine("So, what's next? Are we going to try to go otside?");
        Console.WriteLine("Yes / No");
        input = Console.ReadLine();
        if(input == "Yes")
        {
            Console.WriteLine("Luckily, the door was not blocked by anything and you are able" +
                "to go outgside and meet new lords of your civilization :)");
            break;
        }
        else if(input == "No")
        {
            Console.WriteLine("You continued to sit inside your fridge with no ability to move." +
                "Suddenly you and feel that something smashed your door. Now it is blocked and you are stuck here forever");
            gameIsFinished = true;
            break;
        }
        else
        {
            Console.WriteLine("Wrong input");
            break;
        }
    }
    else
    {
        Console.WriteLine("Wrong input");
        break;
    }
}
