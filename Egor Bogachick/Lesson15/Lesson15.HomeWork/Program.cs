using System.Collections;

namespace Lesson15.HomeWork
{
    public class Stack<T>
    {
        private const int Value = 10;
        public int Item { get; private set; }
        public T[] Arr { get; private set; }    

        public Stack() 
        {
            Arr = new T[Value];
            Item = 0;
        }
        public Stack(int lenth)
        {
            Arr = new T[lenth];
            Item = 0;
        }

        public bool IsEmpty()
        {
            return Item == 0;
        }

        public T Pop()
        {
            if (IsEmpty() || Item < 0)
            {
                Console.WriteLine("Array is empty");
                throw new IndexOutOfRangeException("Array is empty");
            }
            Item--;
            return Arr[Item];
        }
        public void Push(T item)
        {
            if (Item == Arr.Length)
            {
                T[] tempArr = new T[Arr.Length*2];
                Array.Copy(Arr, tempArr, Arr.Length);
                Arr = tempArr;
            }

            Arr[Item] = item;
            Item++;
        }

        public T Peek()
        {
            if (IsEmpty() || Item < 0)
            {
                Console.WriteLine("Array is empty");
                throw new IndexOutOfRangeException("Array is empty");
            }
            return Arr[Item - 1];
        }

        public int Count()
        {
            return Item;
        }

        public void Clear()
        {
            Item = 0;
        }

        public void CopyTo(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Arr[i];
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack1 = new Stack<int>(); 
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);

            Console.WriteLine(stack1.Pop());
            Console.WriteLine(stack1.Peek());

            int[] arr = new int[5];
            stack1.CopyTo(arr);
            foreach (int i in arr)
            {
                Console.Write($"{i}, ");
            }
            stack1.Clear();
            Console.WriteLine(stack1.IsEmpty());

            Stack<string> stack2 = new Stack<string>(20);
            stack2.Push("first");
            stack2.Push("second");
            stack2.Push("third");
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Peek());

        }
    }
}