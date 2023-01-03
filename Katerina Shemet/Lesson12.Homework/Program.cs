namespace AutoService
{
    class Program
    {
        static void Main(string[] args)
        {
            Car SportCar = new Car("Ferrari");
            SportCar.EngineV1();
            CarDetails SportcarDetails = new CarDetails("305/35 R22 110Y", "Michelin Pilot Super Sport");
            SportcarDetails.Wheel();
            SportCar.Colour("Yellow");

            Car Minivan = new Car("Nissan");
            Minivan.EngineV2();
            CarDetails MinivanDetails = new CarDetails("225/65 R17 102T", "Goodyear UltraGrip");
            MinivanDetails.Wheel();
            Minivan.Colour("Red");

            Car Bus = new Car("Ford");
            Bus.EngineV3();
            CarDetails BusDetails = new CarDetails("235/65 R16C 115/113R", "Michelin Agilis Alpin");
            BusDetails.Wheel();
            Bus.Colour("White");

            Console.ReadKey();
        }
    }

    class Car : CarBase, CarColour
    {
        public Car(String CarName) : base(CarName)
        {
        }

    public CarDetails CarDetails;

        public void Colour(String color)
        {
            Console.WriteLine($"Car Colour is : {color}");
        }

    }

    class CarDetails
    {
        public string lid;
        public string tire;

        public CarDetails(string _lid, string _tire)
        {
            lid = _lid;
            tire = _tire;
        }
        public void Wheel()
        {
            Console.WriteLine($"Wheels is {lid} {tire}");
        }
    }

    class CarBase
    {
        public CarBase(String CarName)
        {
            Console.WriteLine($"\nCar is {CarName}");
        }

        public void EngineV1()
        {
            Console.WriteLine("Engine Type is V.1");
        }

        public void EngineV2()
        {
            Console.WriteLine("Engine Type is V.2");
        }

        public void EngineV3()
        {
            Console.WriteLine("Engine Type is V.3");
        }

    }
    interface CarColour
    {
        void Colour(String color);
    }
}
