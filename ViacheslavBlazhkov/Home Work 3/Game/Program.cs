int choice = 0;

Console.WriteLine("Hello. What's your name?");
Console.Write("My name is ");
string heroName = Console.ReadLine();

Console.Write($"{heroName}, choose your element(1 - fire, 2 - water, 3 - ground, 4 - air): ");
int heroElemNumb = int.Parse(Console.ReadLine());
string heroElem = "";
if (heroElemNumb == 1) heroElem = "Fire";
else if (heroElemNumb == 2) heroElem = "Water";
else if (heroElemNumb == 3) heroElem = "Ground";
else if (heroElemNumb == 4) heroElem = "Air";
else
{
    Console.WriteLine("Error");
    return;
}

Console.WriteLine("Okay. Press ENTER to start.");
Console.ReadLine();
Console.Clear();

Console.WriteLine("Where are you going to?");
Console.WriteLine("1 - Forest, 2 - Beach, 3 - Mountains, 4 - Desert");
int placeNumb = int.Parse(Console.ReadLine());
string place = "";
if (placeNumb == 1) place = "Forest";
else if (placeNumb == 2) place = "Beach";
else if (placeNumb == 3) place = "Mountains";
else if (placeNumb == 4) place = "Desert";


if (place == "Forest")
{
    Console.WriteLine("You faced wolf. Fight (1) or run (2)?");
    choice = int.Parse(Console.ReadLine());
    if (choice == 1) Console.WriteLine("Cool, you have eaten by wolf.");
    else if (choice == 2) Console.WriteLine("Nice, the wolf has bitten off your legs and you cannot escape.");
}
else if (place == "Beach")
{
    Console.WriteLine("You faced unicorn. Fight (1) or run (2)?");
    choice = int.Parse(Console.ReadLine());
    if (choice == 1) Console.WriteLine("Awesome, the unicorn pierced you with a horn.");
    else if (choice == 2) Console.WriteLine("Wonderful, the unicorn caughts up with you and pierced you with a horn.");
}
else if (place == "Mountains")
{
    Console.WriteLine("You faced troll. Fight (1) or run (2)?");
    choice = int.Parse(Console.ReadLine());
    if (choice == 1) Console.WriteLine("Amazing, the troll hammered you into the ground with a club like a nail with a hammer");
    else if (choice == 2) Console.WriteLine("Marvelous, you have ran away from troll and died for eld.");
}
else if (place == "Desert")
{
    Console.WriteLine("You faced big-big worm. Fight (1) or run (2)?");
    choice = int.Parse(Console.ReadLine());
    Console.WriteLine("What difference does it make if you die anyway.");
    Console.WriteLine("What difference does it make if you die anyway.");
}

Console.WriteLine();