try
{
    Method1();
}
//catch (DivideByZeroException ex)
//{
//    Console.WriteLine("DivideByZeroException!");
//}
//catch (ArithmeticException ex)
//{
//    Console.WriteLine("ArithmeticException!");
//}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine($"Main Exception: {ex}");
    Console.WriteLine($"Main Inner Exception: {ex.InnerException}");
}
finally
{
    Console.WriteLine("Finally Main!");
}

Console.WriteLine("Next code...");

void Method1()
{
    try
    {
        Method2();
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Method1 catch: {ex}");
        throw new Exception(ex.Message, ex);
    }
    finally
    {
        Console.WriteLine("Finally Method1!");
    }
}

void Method2()
{
    try
    {
        //var a = 10;
        //var b = 0;
        //Console.WriteLine(a / b);

        //File.OpenRead(@"C:\ABC.txt");

        //throw new Exception("General Exception!");
        throw new ArithmeticException("ArithmeticException Exception!");
    }
    catch(Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Method2 catch: {ex}");
        throw;
    }
    finally
    {
        Console.WriteLine("Finally Method2!");
    }
}
