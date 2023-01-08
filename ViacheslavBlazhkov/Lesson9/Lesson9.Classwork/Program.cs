try
{
    Method1();
}
//catch (DivideByZeroException ex)
//{
//    Console.WriteLine("DivideByZero");
//}
//catch (ArithmeticException ex)
//{
//    Console.WriteLine("ArithExcep!");
//}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine("Main Exp " + ex);
    Console.WriteLine("Main Inner Exp" + ex.InnerException);
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
    catch(Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine("Method 1" + ex);
        throw new Exception(ex.Message, ex);
    }
    finally { 
        Console.WriteLine("Finally Method 1"); 
    }
}

void Method2()
{
    try
    {
        //var a = 10;
        //var b = 0;
        //Console.WriteLine(a / b);

        //File.OpenRead("dw");

        //throw new Exception("General Exp!");
        throw new ArithmeticException("ArithGeneral Exp!");
    }
    catch(Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine("Method 2 Catch " + ex);
        throw ex;
    }
    finally
    {
        Console.WriteLine("Finally Method2");
    }
}
