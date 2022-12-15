class Program
{
   
    
    static int GreatestCommonDivisor(int x, int y)
    {

        if (x == 1 || y == 1) return 1;
        if (x%2==0&&y%2==0)
           return 2*GreatestCommonDivisor(x/2,y/2); 
            
        //    return 1;
        //else return 2;

    }




    static void Main()
    {

        var x = 4;
        var y = 2;

        Console.WriteLine($"Greater common divisor {x} & {y} is {GreatestCommonDivisor(x, y)}");

    
    
    
    
    }













}