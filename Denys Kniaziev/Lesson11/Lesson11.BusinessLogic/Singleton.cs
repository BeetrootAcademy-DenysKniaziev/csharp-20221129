namespace Lesson11.BusinessLogic
{
    public class Singleton
    {
        public static Singleton Instance { get; } = new Singleton();

        private Singleton()
        {
        }

        public void Method()
        {
            Console.WriteLine("Singleton Method");
        }
    }
}
