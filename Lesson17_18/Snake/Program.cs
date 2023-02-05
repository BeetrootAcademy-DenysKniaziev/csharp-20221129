using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using static System.Console;
using System.Xml.Linq;

namespace Snake;

internal class Program
{
    public static Field MainField = new();

    public delegate void GameOverHandler();
    public static event GameOverHandler GameOver;

    public delegate void EatingObjectsHandler(TheSnake sender, int e);
    public static event EatingObjectsHandler EatingObjects;

    public static void OnGameOver() { GameOver?.Invoke(); }
    public static void OnEatingObjects(TheSnake sender, int e) { EatingObjects?.Invoke(sender, e); }

    static void  Main(string[] args)
    {
        MainField.Size = (35, 35);
        MainField.GenerateField();
        TheSnake MainSnake = new TheSnake(5, MainField);
        MainSnake.Direction = (-1, 0);

        DrawToConsole.ShowScoreEtc(MainSnake, 0);
        DrawToConsole.ShowStartingScreen();

        GameOver += GameEvents.GameOverBeep;
        GameOver += GameEvents.GameOverPicture;
        GameOver += GameEvents.ExitConsole;

        EatingObjects += Obj.TypeClarifing;
        EatingObjects += Obj.ScoreCounting;
        EatingObjects += Obj.NewItemAdding;
        //EatingObjects += DrawToConsole.ShowScoreEtc;


        while  (true)
        {
            Thread.Sleep(MainSnake.speedDelay);
            Thread EnvironimantThread = new Thread(MainSnake.InterAct);
            EnvironimantThread.Start();
            Thread SnakeThread = new Thread(MainSnake.MoveBody);
            SnakeThread.Start();
            Thread ControlThread = new Thread(MainSnake.SnakeControl);
            ControlThread.Start();
        }
    }


}