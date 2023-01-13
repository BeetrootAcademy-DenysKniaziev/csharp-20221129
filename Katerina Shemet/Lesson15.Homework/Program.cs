class Stack
{
    public static void Main()
    {
        Stack<int> numbers = new Stack<int>();
        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        numbers.Push(4);
        numbers.Push(5);

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nPop '{0}'", numbers.Pop());
        Console.WriteLine("Peek next item: {0}",
            numbers.Peek());
        Console.WriteLine("Pop '{0}'", numbers.Pop());

       
        Stack<int> stack2 = new Stack<int>(numbers.ToArray());

        Console.WriteLine("\nFirst copy:");
        foreach (int number in stack2)
        {
            Console.WriteLine(number);
        }


        int[] array2 = new int[numbers.Count * 2];
        numbers.CopyTo(array2, numbers.Count);

        Stack<int> stack3 = new Stack<int>(array2);

        Console.WriteLine("\nSecond copy, with duplicates and nulls:");
        foreach (int number in stack3)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nstack2.Contains(\"2\") = {0}",
            stack2.Contains(2));

        Console.WriteLine("\nstack2.Clear()");
        stack2.Clear();
        Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
    }
}

