using static System.Console;

namespace Lesson17.HomeWork
{
    internal class Program
    {
        private const int width = 35;
        private const int height = 20;
        private const char borderChar = '#';

        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            DrawBorder();
            ReadKey();
        }

        public static void DrawBorder()
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(borderChar);
                Console.SetCursorPosition(i, height);
                Console.Write(borderChar);
            }
            for (int i = 0; i < height ; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(borderChar);
                Console.SetCursorPosition(width, i);
                Console.Write(borderChar);
            }
        }
    }
}

