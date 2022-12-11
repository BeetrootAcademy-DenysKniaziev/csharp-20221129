

class Program
{
    static void Main(string[] args)
    {
        Repeat("str", 3);
    }
    static void Repeat(string input, int numberOfTimes)
    {
        for(int i = 0; i < numberOfTimes; i++)
        {
            Console.Write(input);
        }
        
    }
}