namespace Lesson12.HomeWork
{
     class Program
    {
        static void Main(string[] args)
        {
            Engine engine1 = new Engine(12, 12314, 12000, false);
            Engine engine2 = new Engine(11, 12000, 10000);
            engine1.Status();
            engine2.Status();
            Wheel wheel1 = new Wheel("Sport", "12.07.12", false);
            Wheel wheel2 = new Wheel("Common", "12.07.12");
            wheel1.Status();
            wheel2.Status();
            Car car1 = new Car("Mercedes", "12.07.12", engine1, wheel2);
            SportCar sportCar1 = new SportCar("Lamborghini", "12.07.18", engine2, wheel2);
            BusinessCar businessCar = new BusinessCar("Something", "22.04.22");
            car1.Status();
            car1.Move();
            sportCar1.Status();
            sportCar1.Move();
            businessCar.Status();
            businessCar.Move();

        }
    }
}