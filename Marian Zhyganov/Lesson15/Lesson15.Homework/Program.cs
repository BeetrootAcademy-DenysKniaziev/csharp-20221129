using System;
using System.Collections;


internal class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(6);
        stack.Push(5);
        stack.Push(4);
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);
        
        int[] a = new int[stack.Count()];
        stack.CopyTo(a);

        Console.WriteLine("Stack A:");
        foreach (var item in a)
            Console.WriteLine(item);

        Console.WriteLine("Stack Pop:");
        stack.Pop();
        stack.Pop();
        int [] b = new int[stack.Count()];
        stack.CopyTo(b); 
        foreach (var item in b)
            Console.WriteLine(item);

        Console.WriteLine("Stack Clear");
        stack.Clear();
        int[] c = new int[stack.Count()];
        stack.CopyTo(c);
        foreach (var item in c)
            Console.WriteLine(item);

        
    }
}
class Stack<T>
{
    public T[] arr = new T[5];
    public int count = 0;

    public void Push(T val)
    {
        if (count == arr.Length)
        {
            T[] tmp = new T[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                tmp[i] = arr[i];
            }
            arr = tmp;
        }
        arr[count] = val;
        count++;

    }
    public T Pop()
    {
        count--;
        return arr[count];  
    }
    public void Clear()
    {
        count = 0;
        if (count == 0 )
        {
            Console.WriteLine("You have a clear srack");
        }
    }
    public int Count()
    {
        return count;
    }
    public T Peek() 
    {
        return arr[count - 1];
    }
    public void CopyTo(T[] array)
    {
        for (int i = 0; i < Math.Min(count, array.Length); i++)
        {
            array[i] = arr[count - i - 1];
        }
    }

}
