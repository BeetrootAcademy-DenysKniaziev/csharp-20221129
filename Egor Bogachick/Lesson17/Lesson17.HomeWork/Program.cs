using static System.Console;

namespace Lesson17.HomeWork
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            
            Pixel.DrawBorder();
            Snake snake = new Snake(10, 5);
            ReadKey();
        }


    }
}

