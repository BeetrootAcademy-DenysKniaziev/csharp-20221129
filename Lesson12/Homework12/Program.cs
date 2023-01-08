//Describe ‘auto service’ domain that defines several entities: vehicle, wheel, engine, etc.
//Extra:
//Create UML diagram for this domain

namespace Homework12;

internal class Program
{
    static void Main(string[] args)
    {
        ReparingProcess task1 = new ReparingProcess();
        task1.ProcessOwner("Borys Kashyrin");
        task1.ProcessFacility(3);
        task1.Vehicle = new Vehicle();
        task1.Parts = new List<Part> { new Wheel(), new Engine(), new ControlPanel(), task1.Vehicle };

        ////// Service Process
        foreach (var p in task1.Parts) p.DoBest();

    }

    interface IElectroSupplieble {
        void Test12Volts();
    }

    interface IReperable {
        void DoBest();
    }
    interface IChangeble {
        void DoBest();
    }

    abstract class Process  {
        public abstract void ProcessOwner(string name);
        public abstract void ProcessFacility(int number);
        int processNumber { get; set; }
    }

    class ReparingProcess: Process  {
        public Vehicle Vehicle { get; set; }
        public List<Part> Parts { get; set; }
        ReparingBox repBox = new ReparingBox();
        Master master = new Master();
        public override void ProcessOwner(string name)        {
            master.MasterName = name;
        }
        public override void ProcessFacility(int number)   {
            repBox.BoxNumber = number;
        }


    }
    class ReparingBox {
        public int BoxNumber { get; set; }
    }
    class Master {
        public string MasterName { get; set; }
    }
    class Part: IChangeble,IReperable { 
        int SerialNumber { get; set; }
        string PartName { get; set; }
        List<Part> Parts= new List<Part>();
        public virtual void DoBest() {
        }
    }

    class Wheel : Part, IChangeble {
        public override void DoBest() => Console.WriteLine("Wheel is not reperable, Best I can do is CHANGE your wheel.");
    }
    class Vehicle : Part, IReperable {
        public override void DoBest() => Console.WriteLine("In your car Everything is broken, but I can Repair most of parts and you don`t need to change a car");
    }
    class Engine :Part, IReperable {
        public override void DoBest() => Console.WriteLine("Engine is in bed condition, but, I can Repair it.");
    }
    class ControlPanel:Part, IChangeble, IElectroSupplieble {
        public override void DoBest() { 
            Console.WriteLine("Control Panel is totaly broken. Best I can do is CHANGE your Control panel.");
            Test12Volts();
        }
        public void Test12Volts() => Console.WriteLine("Now your new Control panel connected and can supply 12 Volts");
    }


}