
using System;

public enum Season { summer = 0, winter = 1 };

public class Tyre
{
    int _diameter = 15;
    int _sectionWidth = 195;
    int _aspectRatio = 60;
    public Season _season = 0;

    public Season Season { get; set; }

    int Diameter
    {
        get => _diameter;
        set { _diameter = value; }
    }

    int SectionWidth
    {
        get => _sectionWidth;
        set { _sectionWidth = value; }
    }

    int AspectRatio
    {
        get => _aspectRatio;
        set { _aspectRatio = value; }
    }

    public Tyre()
    {

    }
    public Tyre(int sectionWidth, int aspectRatio, int diameter, Season season)
    {
        Diameter = diameter;
        SectionWidth = sectionWidth;
        AspectRatio = aspectRatio;
        Season = season;
    }

    public override string ToString()
    {
        return $"{SectionWidth}/{AspectRatio}R{Diameter} season:{Season}";
    }

}

class Auto
{
    Engine _engine;
    public Tyre[] _tyres;
    public string _vin;
    public string Brand { get; set; }

    public Auto(string brand, string VIN, Tyre tyre, SparkPlug sparkPlug)
    {
        Brand = brand;
        _vin = VIN;
        _tyres = new Tyre[] { tyre, tyre, tyre, tyre };
        _engine = new Engine(sparkPlug);
    }

    public Engine Engine
    {
        get { return _engine; }
    }

    public override string ToString()
    {
        return $"Brand: {Brand}\nVIN: {_vin}\nPower: {_engine._power} kW\nSpakplugs: {_engine._sparkPlugs[0]}" +
            $"\nTYRES\nLF: {_tyres[0]}\nRF: {_tyres[1]}\nRR: {_tyres[2]}\nLR: {_tyres[3]}";
    }

}

class SparkPlug
{
    public string _brand = "Denso";


    public SparkPlug(string brand)
    {
        _brand = brand;
    }
    public override string ToString()
    {
        return _brand;
    }
}

class Engine
{
    int _oilVolume = 5;
    int _numberOfCylindres = 6;
    public List<SparkPlug> _sparkPlugs;
    public int _power = 100;

    public Engine(SparkPlug sparkPlug)
    {
        _sparkPlugs = new List<SparkPlug> { };
        for (int i = 0; i < _numberOfCylindres; i++)
        {
            _sparkPlugs.Add(sparkPlug);
        }
    }

    public int OilVolume
    {
        get { return _oilVolume; }
    }

    public int NumberOfCylindres
    {
        get { return _numberOfCylindres; }
    }

    public void GetSparkPlugs()
    {
        foreach (var spark in _sparkPlugs)
        {
            Console.WriteLine(spark);
        }
    }

}

class AutoService
{
    string _title;
    double _priceForChangeOil = 10;
    double _oilCost = 5;
    double _priceForChangeSpark = 4.5;
    double _sparkCost = 8.8;
    double _priceForChangeTyre = 20;

    public double _account = 1000;

    public AutoService(string title)
    {
        _title = title;
    }

    public void ChangeOil(Auto auto)
    {
        _account += _priceForChangeOil + _oilCost * auto.Engine.OilVolume;
    }

    public void ChangeSparks(Auto auto, SparkPlug sparkPlug)
    {
        _account += (_priceForChangeSpark + _sparkCost) * auto.Engine.NumberOfCylindres;

        for (int i = 0; i < auto.Engine.NumberOfCylindres; i++)
        {
            auto.Engine._sparkPlugs[i] = sparkPlug;
        }
    }

    public void ChangeTyres(Auto auto, Tyre tyre)
    {
        _account += _priceForChangeTyre;

        for (int i = 0; i < auto._tyres.Length; i++)
        {
            auto._tyres[i] = tyre;
        }
    }

    public override string ToString()
    {
        return "Title: "+_title+"\n"+$"Account: ${ _account}" ;
    }
}



class Program
{
    static void Main(string[] args)
    {
        Tyre T1 = new Tyre();
        //Console.WriteLine(T1);

        Tyre T2 = new Tyre(205, 55, 16, Season.winter);

        //Console.WriteLine(T2);

        SparkPlug SP1 = new SparkPlug("Denso");

        SparkPlug SP2 = new SparkPlug("Champion");

        Auto Car = new Auto("ZAZ", "AB123CD", T1, SP1);

        var STO = new AutoService("STO");

        Console.WriteLine($"{STO._account}");

        STO.ChangeOil(Car);

        Console.WriteLine($"{STO._account}");

        Console.WriteLine(Car);

        STO.ChangeSparks(Car, SP2);

        Console.WriteLine($"{STO._account}");

        Console.WriteLine(Car);

        Console.WriteLine();

        STO.ChangeTyres(Car, T2);

        Console.WriteLine(Car);

        Console.WriteLine();

        Console.WriteLine(STO);

        Console.WriteLine();

        Car.Engine.GetSparkPlugs();
    }

}