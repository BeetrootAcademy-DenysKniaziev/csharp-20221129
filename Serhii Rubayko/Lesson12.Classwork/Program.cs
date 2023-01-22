
public class Tyre
{
    int _diameter = 15;
    int _sectionWidth = 195;
    int _aspectRatio = 60;
        
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

    public Tyre[] tyres;
    public double OilVolume { get; set; }

    Auto(string brand, Tyre tyre, double oilVolume)
    {
        Brand= brand;
        tyres = new Tyre [] { tyre, tyre, tyre, tyre};
        OilVolume = oilVolume;

    }




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