class Program
{
    static void Main()
    {
        var stack = new Stack<int>();
        stack.Push(2);
        stack.Push(5);
        stack.Push(6);
        stack.Push(10);
        stack.Push(8);
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Count());
        stack.Push(25);
        Console.WriteLine(stack.Count());
        Console.WriteLine(stack.Peek());

    }
}
class Stack<T>
{
    private T[] _array;
    private int _count = 0;
    public Stack(int capacity = 1)
    {
        _array = new T[capacity];
    }
    public int Count()
    {
        return _count;
    }

    public void Push(T item)
    {
        if(_array.Length == _count)
        {
            T[] array = _array[0..^0];
            _array = new T[_count*2];
            array.CopyTo(_array, 0);
        }
        _array[_count] = item;
        _count++;
    }
    public T Pop()
    {
        if( _count == 0 )
            throw new IndexOutOfRangeException();
        _count--;
        return _array[_count];
    }
    public void Clear()
    {
        _count = 0;
    }
    public T Peek()
    {
        return _array[_count - 1];
    }
    public T[] CopyTo(T array)
    {
        return _array[0..(_count+1)];
    }

}