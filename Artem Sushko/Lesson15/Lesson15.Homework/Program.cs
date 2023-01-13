using System.Collections;

namespace Lesson15.Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NewArr = new int[5];
            Stack<int> s1 = new Stack<int>();
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s1.CopyTo(NewArr);
            s1.Peek();
            s1.POP();
            s1.Clear();
        }
    }

    class Stack<T>
    {
        public T[] arr = new T[10];

        private int _count = 0;

        public void Push(T value)
        {
            if (_count == arr.Length)
            {
                T[] tmp = new T[arr.Length * 2];
                for (int i = 0; i < arr.Length; i++)
                {
                    tmp[i] = arr[i];
                }
                arr = tmp;

            }
            arr[_count] = value;

            _count++;
        }

        public T POP()
        {
            if (_count < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _count--;
            return arr[_count];
        }

        public T Peek()
        {
            if (_count < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return arr[_count - 1];
        }

        public int Count()
        {
            return _count;
        }

        public void Clear()
        {
            _count = 0;
        }

        public void CopyTo(T[] newArr)
        {
            for (int i = 0; i < Math.Min(_count, newArr.Length); i++)
            {
                newArr[i] = arr[i];
            }
        }
    }
}