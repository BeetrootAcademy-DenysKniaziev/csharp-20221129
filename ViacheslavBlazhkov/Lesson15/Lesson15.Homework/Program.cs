namespace Lesson15.Homework
{
    class Stack<T>
    {
        private T[] stackArray { get; set; }

        public int Count { get; private set; }

        public Stack(T[] array)
        {
            stackArray = array;
            Count = array.Length;
        }

        public void Push(T item)
        {
            T[] array = new T[stackArray.Length+1];
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = stackArray[i];
            }
            array[stackArray.Length ] = item;
            stackArray = array;
        }
        public T Pop()
        {
            T lastItem;
            T[] array = new T[stackArray.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = stackArray[i];
            }
            lastItem = stackArray[stackArray.Length - 1];
            stackArray = array;
            return lastItem;
        }
        public T Peek()
        {
            return stackArray[stackArray.Length - 1];
        }

        public void CopyTo(ref T[] array) 
        {
            array = stackArray;
        }

        public void Clear()
        {
            for (int i = 0; i < stackArray.Length; i++)
            {
                stackArray[i] = default;
            }
        }

        public void ShowStackElements()
        {
            Console.WriteLine("Stack elements: ");
            for (int i = 0; i < stackArray.Length; i++)
            {
                Console.WriteLine($" [{i}] = {stackArray[i]}");
            }
            Console.WriteLine();
        }

        // Reverse placing methods
        public void PushReverse(T item)
        {
            T[] array = new T[stackArray.Length + 1];
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = stackArray[i - 1];
            }
            array[0] = item;
            stackArray = array;
        }
        public T PopReverse()
        {
            T firstItem;
            T[] array = new T[stackArray.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = stackArray[i+1];
            }
            firstItem = stackArray[0];
            stackArray = array;
            return firstItem;
        }
        public T PeekReverse()
        {
            return stackArray[0];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arraystr = { "Porsche", "BMW", "Opel", "Peugeot" };
            int[] arrayint = { 2, 5, 8, 2, 7 };

            Stack<string> stackstr = new Stack<string>(arraystr);
            Stack<int> stackint = new Stack<int>(arrayint);
        }
    }
}