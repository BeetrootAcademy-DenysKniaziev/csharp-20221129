namespace Lesson12.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Engine pBoxEngine = new Engine("MA2.2 turbo H4", "unknown", 2.0, 300);
            Wheel pBoxWheel = new Wheel("PBW001" ,TireType.Performance, 18);
            SportCar pBox718 = new SportCar("Porsche", "718 Boxster (982)", pBoxEngine, pBoxWheel);
            

            pBoxWheel.IsBroken = true;
            pBox718.Drive();
        }
    }
}