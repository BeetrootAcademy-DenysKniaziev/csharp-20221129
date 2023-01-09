using System.Text;
using System.IO;

namespace Lesson13.Homework
{
    internal class Program
    {
        static void Fail(char[,] map, ref char[] bag, ref int x, ref int y)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'O')
                    {
                        map[i, j] = 'X';
                    }
                }
            }
            char[] tmp = new char[1];
            bag = tmp;
            x = 6;
            y = 10;
            Console.SetCursorPosition(50, 8);
            Console.WriteLine("Вы проиграли! Повезет в следующий раз!");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
        }
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[] stringMap = File.ReadAllLines("map.txt");

            char[,] map = new char[stringMap.Length, stringMap[0].Length];
            char[] charTmp;

            for (int i = 0; i < stringMap.Length; i++)
            {
                charTmp = stringMap[i].ToCharArray();
                for (int j = 0; j < stringMap[i].Length; j++)
                {
                    map[i, j] = charTmp[j];
                }
            }

            int amountOfTreasure = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'X')
                    {
                        amountOfTreasure++;
                    }
                }
            }
            char[] bag = new char[1];
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int x = 6, y = 10;

            while (true)
            {

                Console.SetCursorPosition(22, 0);
                Console.WriteLine($"Соберите {amountOfTreasure} сокровищ!(X)");

                Console.SetCursorPosition(22, 2);
                Console.WriteLine("Не Косайтесь стен!(*)");

                Console.SetCursorPosition(22, 4);
                Console.WriteLine("Используйте Стрелочки для управления");

                Console.SetCursorPosition(0, 21);
                Console.Write("Сумка: ");
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(y, x);
                Console.Write('@');

                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.UpArrow:
                        if (map[x - 1, y] != '*')
                        {
                            x--;
                        }
                        else
                        {
                            Fail(map, ref bag, ref x, ref y);
                            break;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (map[x + 1, y] != '*')
                        {
                            x++;
                        }
                        else
                        {
                            Fail(map, ref bag, ref x, ref y);
                            break;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (map[x, y - 1] != '*')
                        {
                            y--;
                        }
                        else
                        {
                            Fail(map, ref bag, ref x, ref y);
                            break;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (map[x, y + 1] != '*')
                        {
                            y++;
                        }
                        else
                        {
                            Fail(map, ref bag, ref x, ref y);
                            break;
                        }
                        break;
                }

                if (map[x, y] == 'X')
                {
                    map[x, y] = 'O';
                    char[] tempBag = new char[bag.Length + 1];
                    for (int i = 0; i < bag.Length; i++)
                    {
                        tempBag[i] = bag[i];

                    }
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;
                    if (bag.Length == amountOfTreasure + 1)
                    {
                        Console.SetCursorPosition(50, 10);
                        Console.WriteLine("Вы победили! Конец Игры!");
                        Console.SetCursorPosition(50, 12);
                        Console.WriteLine("Нажмите любую кнопку...");
                        Console.ReadKey();
                        break;
                    }
                }
                Console.Clear();
            }
        }
    }
}