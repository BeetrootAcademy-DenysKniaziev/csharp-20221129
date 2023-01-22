using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake;

internal class GameEvents
{
    public static void GameOverBeep()
    {
        Console.Beep();
    }
    public static void GameOverPicture() 
    {
        Console.WriteLine("GAME OVER");
    }
    public static void ExitConsole()
    {
        Environment.Exit(1);
    }
}
