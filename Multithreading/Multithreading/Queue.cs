using System;

namespace Multithreading
{
    public class Queue<T>
    {
        public int First { get; private set; }
        public int Last { get; private set; }
        private readonly T[] _array;

        internal Queue(int bufferSize)
        {
            _array = new T[bufferSize];
            First = 0;
            Last = 0;
        }

        internal void Enqueue(T e)
        {
            if (Size() == BufferSize())
            {
                throw new InvalidOperationException("Buffer is full");
            }
            Last %= BufferSize();
            _array[Last++] = e;
        }

        internal T Dequeue()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Buffer is empty");
            }
            var d = _array[First++];
            if (First < BufferSize())
            {
                return d;
            }
            First %= BufferSize();
            Last %= BufferSize();
            return d;
        }

        internal void Clear()
        {
            First = Last = 0;
        }

        internal bool Empty()
        {
            return First == Last;
        }

        internal int Size()
        {
            return First > Last ? BufferSize() - First + Last : Last - First;
        }

        internal int BufferSize()
        {
            return _array.Length;
        }

        public Queue<T> Clone()
        {
            var q = new Queue<T>(BufferSize());
            for (var i = First; i != Last; i = i + 1 % BufferSize())
            {
                q.Enqueue(_array[i]);
            }
            return q;
        }
    }
}