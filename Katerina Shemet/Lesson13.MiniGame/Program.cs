using System;
using System.IO;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random random = new Random();

            bool isPlaying = true;

            int pacmanX, pacmanY;
            bool isAlive = true;

            int ghostX, ghostY;

            int pacmanDX = 0, pacmanDY = 1;
            int ghostDX = 0, ghostDY = -1;

            int allDots = 0, collectDots = 0;

            char[,] map = ReadMap("map1", out pacmanX, out pacmanY, out ghostX, out ghostY, ref allDots);

            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine($"Зібрано {collectDots}/{allDots}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }

                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    CollectDots(map, pacmanX, pacmanY, ref collectDots);
                    Move(map, '@', ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                }

                if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
                {
                    Move(map, '$', ref ghostX, ref ghostY, ghostDX, ghostDY);
                }
                else
                {
                    ChangeDirection(random, ref ghostDX, ref ghostDY);
                }

                System.Threading.Thread.Sleep(200);

                if (ghostX == pacmanX && ghostY == pacmanY)
                {
                    isAlive = false;
                }

                if (collectDots == allDots || isAlive == false)
                {
                    isPlaying = false;
                }
            }

            Console.SetCursorPosition(0, 22);

            if (collectDots == allDots)
            {
                Console.WriteLine("Ви виграли!");
            }
            else if (!isAlive)
            {
                Console.WriteLine("Вас з'їли :( ");
                Console.ReadKey();
            }
        }

        static void Move(char[,] map, char symbol, ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(map[X, Y]);

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write(symbol);
        }

        static void CollectDots(char[,] map, int pacmanX, int pacmanY, ref int collectDots)
        {
            if (map[pacmanX, pacmanY] == '.')
            {
                collectDots++;
                map[pacmanX, pacmanY] = ' ';
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;

                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;

                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }

        }

        static void ChangeDirection(Random random, ref int DX, ref int DY)
        {
            int ghostDir = random.Next(1, 5);

            switch (ghostDir)
            {
                case 1:
                    DX = -1; DY = 0;
                    break;

                case 2:
                    DX = 1; DY = 0;
                    break;

                case 3:
                    DX = 0; DY = -1;
                    break;

                case 4:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, out int ghostX, out int ghostY, ref int allDots)
        {
            pacmanX = 0;
            pacmanY = 0;
            ghostX = 0;
            ghostY = 0;

            string[] newFile = File.ReadAllLines($"{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i, j] == '$')
                    {
                        ghostX = i;
                        ghostY = j;
                        map[i, j] = '.';
                    }
                    else if (map[i, j] == ' ')
                    {
                        map[i, j] = '.';
                        allDots++;
                    }
                }
            }

            return map;
        }

    }

}

