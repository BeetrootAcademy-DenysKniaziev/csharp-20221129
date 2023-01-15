namespace Snake;

internal class Program
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(80, 45);
        Console.ForegroundColor= ConsoleColor.Green;
        Field MainField = new();
        MainField.Size = (30, 30);
        MainField.GenerateField();
        TheSnake MainSnake = new TheSnake(5);
        MainField.InterAct(MainSnake);
        MainField.Show();
    }
}