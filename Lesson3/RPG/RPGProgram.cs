using System;

string[] E = new string[6] { "0. You entered a swampy place:\n1. Run away\n2. Go inside and check what the smell is\n3.Scream laud", "1. You are standing in front of the house, but there are no doors to enter inside\n1. Punch the wall\n2. Massage the wall\n3. Seatdown near the wall", "2. You see the light and come closer. There is a man seated near the fire\n1. Come silently from the beck and take his beg\n2. Say 'hi!'\n3. Come and seat near the fire", "3. You see the wide hole in the ground. Just Wonder how deep it is\n1. Jump into the hole\n2. Throw a stone to the hole\n3. Say 'Hi!' to the hole", "4. There is a strange tree growing right from the rock. And there are 3 kinds of fruits on it\n1. pick a green fruit\n2. Pick a red fruit\n3. Pick a black fruit", "5. What a peaceful place here, Why not lay down and sleep for a while?\n1. lay down and sleep\n2. lay down and think about the sense of life\n3. No time for rest, I need more practice" };
string[,] Answer = new string[6, 3] {
                   {"00000% All body is sweated and feet in dirt, but it looks like a good idea",
                    "00000% There is something on the ground\nYou come closer\nOh, what a smell. It looks like dead bo...\nThat moment horrible scream cut into ears and the dead body flyed up... it is banshee\n...in a half hour you find yourself running and falling down tired.",
                    "03+50% You screem and hear that some one or something repeating you.\n you did it once again and answer repeated too...\nYou fill some wild energy antering your body"},
                   {"00000% You punched the wall, but nothing heppened",
                    "00000% It look`s like stupid idie, but you start massaging the wall...\n your arms beckome hotter\n...and hotter\nfinaly you deffenetly know that it was stupid idia",
                    "00000% You seat silent a while...\nit`s become darker and eyes start closing, but just before starting sleep you so that one leg appears just through that wall near you\n than hand, part of the body and finally whole young lady standing right near you\nShe smiled and said it's late and dangerous outside come in\n but the wall..(you tried to say). She just took your hand and you both have passed through the wall\n... Next morning spellbook receive new spell 'S(l)ip through'" },
                   {"00000% ","00000% ","00000% " },
                   {"00000% ","00000% ","00000% " },
                   {"00000% ","00000% ","00000% " },
                   {"00000% ","00000% ","00000% " }};
string[] Art = new string[8] { "11 Stone Gloves : Strenght +1", "11 Knife : Strenght +1", "11 Sword : Strenght +3", "11 Clab : Strenght +1", "11 Chain : Strenght +1", "12 Short Sward : Strenght +2", "32 Magig Staff : Magic Power +2", "33 Wend of the Grand Mage : Magic Power +3" };
string[] Eqip = new string[6];
string weapon = "Hands";
string[] Monstr = new string[6] { "325000 Goblin", "537000 Skeleton", "537392 Skeleton Archer", "557002 Ghost", "877000 Giant Org", "615753 Mage" };
string[] MonsterStats = new string[6] { "325000", "537000", "537392", "557000", "877002", "615753" };
string[] Stat = new string[6] { "Life Points", "Strenght   ", "Armor      ", "Magic Power", "SpellPoints", "Sight      " };
int[] StatValue = new int[6] { 7, 5, 5, 3, 3, 2 };

//string[] Story = new string[2] { "1", "2" };
int Eitr = 0, Emax = 5;
int Mitr = 0, Mmax = 5;
int Aitr = 0, Amax = 5;

int worldsize = 30;
Console.SetWindowSize(worldsize * 3, worldsize * 2);
//Console.WriteLine("Hello, World!");
//int lifePoints = 7, strenght = 5, armor = 5, magic_power = 3, SpellPoints = 3, sight = 2;
int[,] map = new int[worldsize + 1, worldsize + 1];
string[,] story = new string[worldsize + 1, worldsize + 1];
for (int x = 1; x <= worldsize; x++)
{
    for (int y = 1; y <= worldsize; y++)
    {
        //Random rnd = new Random();
        //map[x, y] = rnd.Next(1, 3);
        //story[x, y] = "I";
        map[x, y] = 2;
    }
}
Random rnd = new Random();
int offset = worldsize / 2;
int X = 15, Y = 15;
int prevX = 15, prevY = 15;
for (int j = 1; j < 10; j++)
{

    X = offset; Y = offset;
    offset = rnd.Next(worldsize / 3, worldsize / 3 * 2);
    int prevbox = 0;
    for (int i = 1; i < worldsize * 3; i++)
    {
        if (X != 1 && X != worldsize && Y != 1 && Y != worldsize)
        {
            int nextbox = rnd.Next(1, 7);
            if (nextbox + prevbox == 4 || nextbox + prevbox == 6) nextbox = prevbox;
            if (nextbox == 5 || nextbox == 6) nextbox = prevbox;
            prevX = X; prevY = Y;
            switch (nextbox)
            {
                case 1: X = X + 1; break;
                case 2:
                    Y = Y + 1;
                    break;
                case 3:
                    X = X - 1;
                    break;
                case 4:
                    Y = Y - 1;
                    break;

            }
            if (X != 1 && X != worldsize && Y != 1 && Y != worldsize)
            {
                int empt = 0;
                if (map[X + 1, Y] == 1) empt++;
                if (map[X - 1, Y] == 1) empt++;
                if (map[X, Y + 1] == 1) empt++;
                if (map[X, Y - 1] == 1) empt++;
                if (empt >= 2) continue;
            }
            int evnt = rnd.Next(1, 16);
            if (evnt == 7)
            {
                if (nextbox == prevbox)
                {
                    Mitr = rnd.Next(0, 6);
                    story[X, Y] = Monstr[Mitr];
                    map[X, Y] = 9;
                    //Mitr += 1;
                    //if (Mitr > Mmax) Mitr = 0;
                }
                else
                {
                    map[X, Y] = 7; Aitr = rnd.Next(0, 6);
                    story[X, Y] = Art[Aitr];
                }
            }
            else if (evnt == 8)
            {
                story[X, Y] = E[Eitr];
                map[X, Y] = 8;
                Eitr += 1;
                if (Eitr > Emax) Eitr = 0;
            }
            else { map[X, Y] = 1; }
            prevbox = nextbox;
        }
        else
        {
            map[X, Y] = 5;
            map[prevX, prevY] = 9;
            Mitr = rnd.Next(0, 6);
            story[prevX, prevY] = Monstr[Mitr];
            break;
        }
    }
    //map[X, Y] = 10;
}
story[15, 15] = "I";
int MyPositionX = 15, MyPositionY = 15;
map[15, 15] = 88;
int prvPosX = 0, prvPosY = 0;

while (true)
{
    for (int y = 1; y <= worldsize; y++)
    {
        string row = "";
        for (int x = 1; x <= worldsize; x++)
        {
            string predict = " ";
            if (MyPositionX == x && MyPositionY == y) { row = row + predict + "@"; }
            //if(map[x,y] == 88) { predict = "Ipop"; };
            else
            {
                if (map[x, y] == 1) row += predict + " ";
                else if (map[x, y] == 2) row = row + (char)91 + (char)93;
                else if (map[x, y] == 5) row = row + predict + "D";
                else if (map[x, y] == 8) row = row + predict + "E";
                else if (map[x, y] == 9) row = row + predict + "M";
                else if (map[x, y] == 7) row = row + predict + "A";
                else if (map[x, y] == 88) row = row + predict + "H";
            }
            //Console.BackgroundColor = ConsoleColor.Black;


            //else if (map[x, y] == 10) row = row + "BA";
            //row = row + map[x,y].ToString() + map[x, y].ToString();

        }
        //Console.Clear();
        System.Console.WriteLine(row);
    }
    string stats = "";
    for (int i = 0; i < 6; i++)
    {
        stats += "\n" + StatValue[i] + " - " + Stat[i];
    }

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(stats);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\n\nCurrent Weapon " + weapon);
    var k = Console.ReadKey();


    prvPosX = MyPositionX; prvPosY = MyPositionY;
    //story[MyPositionX, MyPositionY,0] = " ";
    if (k.Key == ConsoleKey.UpArrow) MyPositionY -= 1;
    if (k.Key == ConsoleKey.RightArrow) MyPositionX += 1;
    if (k.Key == ConsoleKey.DownArrow) MyPositionY += 1;
    if (k.Key == ConsoleKey.LeftArrow) MyPositionX -= 1;

    if (map[MyPositionX, MyPositionY] != 2 && MyPositionX >= 1 && MyPositionX < worldsize && MyPositionY >= 1 && MyPositionY < worldsize)
    {
        // story[MyPositionX, MyPositionY, 0] = "I";
    }
    else { MyPositionX = prvPosX; MyPositionY = prvPosY; }//story[MyPositionX, MyPositionY,0] = "I"; }
    if (map[MyPositionX, MyPositionY] == 9)
    {
        //Console.BackgroundColor = ConsoleColor.Red;

        Console.WriteLine("\nAAAAAA the MONSTER is here!!! It`s\n" + story[MyPositionX, MyPositionY] + "\n");
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < 6; i++)
        {
            int MStat = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][i]);
            Console.WriteLine(MStat + " - " + Stat[i]);
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("(A)tack!");
        Console.ForegroundColor = ConsoleColor.White;
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.A)
        {
            string nowStrike = "You";// rnd.Next(2, 5);
            int MonsterLife = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][0]);
            while (true)
            {
                Console.Clear();
                //Console.WriteLine(nowStrike);
                ////// Fight
                Console.WriteLine("You     VS    " + story[MyPositionX, MyPositionY]);

                Console.WriteLine(StatValue[0] + "  -  " + Stat[0] + "  -  " + MonsterLife);
                for (int i = 1; i < 6; i++)
                {
                    int MStat = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][i]);
                    Console.WriteLine(StatValue[i] + "  -  " + Stat[i] + "  -  " + MStat);
                }

                if (nowStrike == "You")
                {
                    Console.WriteLine("\nNow your atack\nAtack with (M)agic or with (W) " + weapon);
                    var K = Console.ReadKey();
                    if (K.Key == ConsoleKey.M)
                    {
                        int power = rnd.Next(1, StatValue[3] + 1);
                        MonsterLife = MonsterLife - power;

                        Console.WriteLine("\nYou used Magic atack and striked " + story[MyPositionX, MyPositionY] + " for " + power + " points");
                    }
                    else
                    {
                        int power = rnd.Next(1, StatValue[1] + 1);
                        int defence = rnd.Next(1, (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][2]) + 1);
                        int impact = power - defence;
                        if (impact < 0) impact = 0;
                        MonsterLife = MonsterLife - impact;

                        Console.WriteLine("\nYou atacked " + story[MyPositionX, MyPositionY] + " for " + power + " points " + story[MyPositionX, MyPositionY] + " resist " + defence + " points with armor. The demage is  " + impact);
                    }
                    //Console.WriteLine("ML " + MonsterLife);
                    if (MonsterLife <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You WIN, now you can pass");
                        map[MyPositionX, MyPositionY] = 1; Console.ReadKey(); break;
                    }
                    Console.ReadKey();
                    nowStrike = "Monster";

                }
                else
                {
                    Console.WriteLine("Now " + story[MyPositionX, MyPositionY] + " atack");
                    if ((int)Char.GetNumericValue(story[MyPositionX, MyPositionY][1]) < (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][3]))//Dystanciina ataka
                    {
                        int power = rnd.Next(1, (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][3]) + 1);
                        StatValue[0] = StatValue[0] - power;
                        Console.WriteLine("\n" + story[MyPositionX, MyPositionY] + " used Magic atack for " + power + " points");
                        Console.ReadKey();
                    }
                    else //Ataka z blyz`ka
                    {
                        int power = rnd.Next(1, (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][1]) + 1);
                        int defence = rnd.Next(1, StatValue[2] + 1);
                        int impact = power - defence;
                        if (impact < 0) impact = 0;
                        StatValue[0] = StatValue[0] - impact;
                        Console.WriteLine("\n" + story[MyPositionX, MyPositionY] + " atack you for " + power + " points. You armor resist " + defence + "points. you recived demage " + impact + " points");
                        Console.ReadKey();

                    }
                    if (StatValue[0] <= 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You are dead\nGAME OVER"); Console.ReadLine(); Environment.Exit(0); }
                    nowStrike = "You";
                }
            }

            //Console.ReadKey();

        }
        else { MyPositionX = prvPosX; MyPositionY = prvPosY; }
    }
    if (map[MyPositionX, MyPositionY] == 7)
    {
        //int rarity = rnd.Next(1, 10);
        Console.WriteLine("\nLooks Like I found someting!");
        int AStat = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][0]);
        int AValue = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][1]);
        Console.WriteLine("It`s " + story[MyPositionX, MyPositionY] + "\nDo you want to (P)ick it up and replase your old one?");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.P)
        {
            ////// Change an Eqip
        }
        //Console.ReadKey();
    }
    if (map[MyPositionX, MyPositionY] == 8)
    {
        Console.WriteLine(story[MyPositionX, MyPositionY] + "\nChoose your action (1-3)");
        while (true)
        {
            var ans = Console.ReadKey();
            int index = (int)Char.GetNumericValue(story[MyPositionX, MyPositionY][0]);
            Console.WriteLine();
            int itr = -1;
            if (ans.Key == ConsoleKey.D1) itr = 0;
            if (ans.Key == ConsoleKey.D2) itr = 1;
            if (ans.Key == ConsoleKey.D3) itr = 2;
            if (itr != -1)
            {
                Console.WriteLine(Answer[index, itr]);
                int indexstat = (int)Char.GetNumericValue(Answer[index, itr][1]);
                string change = Answer[index, itr][2].ToString() + Answer[index, itr][3].ToString();
                int.TryParse(change, out int Value);
                StatValue[indexstat] += Value;
                Console.ReadKey(); break;
            }
            else Console.WriteLine("Nope, it`s not an option...");
        }
    }
    Console.Clear();
}