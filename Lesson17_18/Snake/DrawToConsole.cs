using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake;

internal static class DrawToConsole
{
    public static void ShowStartingScreen()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetWindowSize(180, 60);
        Console.WriteLine(File.ReadAllText("snake.txt"));
        Thread.Sleep(2000);
        Console.ForegroundColor = ConsoleColor.Green;
    }
    public static void ShowField(Field field)
    {
        StringBuilder map = new StringBuilder();
        for (int i = 0; i <= field.Size.Item1-2; i++) map.Append("--");
        map.Append("\n");
        for (int y = 1; y < field.Size.Item2-1; y++)
        {
            map.Append("|");
            for (int x = 1; x < field.Size.Item1-1; x++)
            {
                map.Append(field[field.Map[x, y]]);
            }
            map.Append("|\n");
        }
        for (int i = 0; i <= field.Size.Item1-2; i++) map.Append("--");
        Console.Clear();
        Console.WriteLine(map.ToString());

    }
    public static void ShowScoreEtc(TheSnake snake, int objType)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\n Score: {snake.ScorePoints}");
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Rules:\n'>>' - speed up\n'<<' - speed down" +
            "\n'()' - grows longer\n'--' - cutting shoter, whith score reducing" +
            "\n':)' - super skin, more score points for collected objects while in super skin\n':(' - bad skin, less score points for objects");
        Console.ForegroundColor = ConsoleColor.Green;

    }


}
