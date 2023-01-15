//Create generic Stack<T> (what it is) class with next methods:

//Push(obj) - adds obj at the top of stack
//Pop() -returns top element of stack & removes it
//Clear() -clear stack
//Count - property return number of elements
//Peek() -returns top element but doesn’t remove it
//CopyTo(arr) -copies stack to array

namespace Homework15;

internal class Program
{
    static void Main(string[] args)
    {
        MyStack<string> stack = new MyStack<string>() { };
        stack.Push("Dima");
        stack.Push("Sasho");
        stack.Push("Taras");
        Console.WriteLine(stack.Count);
        foreach (var item in stack) Console.WriteLine(item);
        //Console.WriteLine(stack.Top.TheElement.ToString());
        Console.WriteLine("_______________________________________");
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        //stack.Clear();
        Console.WriteLine(stack.Count);
        Console.WriteLine(stack.Peek());

        Console.WriteLine("_______________________________________");
        stack.Push("Dima2");
        stack.Push("Sasho2");
        stack.Push("Taras2");
        Console.WriteLine(stack.Peek() + " " + stack.Count);
        Console.WriteLine("_______________________________________");
        string[] arr = new string[7];
        stack.CopyTo(arr);
        foreach (var item in arr) { Console.WriteLine(item); }

    }
}