
enum Season { summer = 0, winter = 1};

public class Tyre
{
    int _diameter = 15;
    int _sectionWidth = 195;
    int _aspectRatio = 60;
    public Season _season = 0;

    public string Season 
    {
        get { return _season; }
        set { switch
             { case W
                    
            }   
            }
    }
        
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
    public Tyre(int sectionWidth, int aspectRatio, int diameter)
    {
        Diameter = diameter;
        SectionWidth = sectionWidth;
        AspectRatio = aspectRatio;
    }

    public override string ToString()
    {
        return $"{SectionWidth}/{AspectRatio}R{Diameter}";
    }

}

class Auto
{
    public string Brand { get; set; }
    Engine _engine;
    public Tyre[] tyres;
    

    Auto(string brand, Tyre tyre, Engine engine)
    {
        Brand= brand;
        tyres = new Tyre [] { tyre, tyre, tyre, tyre};
        _engine = oilVolume;

    }

}

class Engine
{
    int _power;
    int _oilVolume = 5;
    int _numberOfCylindres=4;
    int _oilLifetime = 10000;
    int _sparkplugLifeTime = 60000;

}

class AutoService
{ static void Main(string[] args)
    {

        Tyre T1 = new Tyre();
        Console.WriteLine(T1);

        Tyre T2 = new Tyre(205, 55, 16);

        Console.WriteLine(T2);


    }

}