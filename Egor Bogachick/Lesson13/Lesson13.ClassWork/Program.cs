namespace Lesson13.ClassWork
{
    abstract class Animal
    {
        public string Name { get; set; }

        public abstract void Say();

        public static void M()
        {
            Console.WriteLine();
        }
    }

    interface IRunnable : IMovable
    {
        void Run();
    }

    interface IMovable
    {
        int Speed { get; }

        void Move()
        {
            Console.WriteLine("PLACEHOLDER");
        }
    }

    class Cat : Animal, IRunnable
    {
        public int Speed => 10;

        public void Abc()
        {
            ((IRunnable)this).Move();
        }

        public void Run()
        {
            Console.WriteLine($"Cat run with {Speed * 2} km/h");
        }

        public override void Say()
        {
            Console.WriteLine("May!");
        }
    }

    class Dog : Animal
    {
        public override void Say()
        {
            Console.WriteLine("Gaw!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Cat();
            a1.Name = "Lucy";
            a1.Say();

            Cat c = (Cat)a1;
            c.Run();

            ((IRunnable)c).Move();
            c.Abc();

            //Animal.M();

            Animal a2 = new Dog();
            a2.Name = "Bob";
            a2.Say();
        }
    }
}