namespace Lesson12.Classwork2
{
    abstract class Animal
    {
        public string Name { get; set; }
        public abstract void Say();

    }

    interface IRunnable : IMovable
    {
        public int Speed { get; }
        void Run();
    }

    interface IMovable
    {
        public int Speed { get; }
        void Move();
    }

    class Cat : Animal, IRunnable
    {
        public int Speed => 10;

        public void Move()
        {
            Console.WriteLine($"Cat move with {Speed} km/h");
        }

        public void Run()
        {
            Console.WriteLine($"Cat run with {Speed * 2} km/h");
        }

        public override void Say()
        {
            Console.WriteLine("Miaw!");
        }
    }
    class Dog : Animal
    {
        public override void Say()
        {
            Console.WriteLine("Gaf!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Cat();
            a.Name = "Lucy";
            a.Say();

            Cat c = (Cat)a;
            c.Run();
            c.Move();

            Animal a2 = new Dog();
            a2.Name = "Bob";
            a2.Say();
        }
    }
}