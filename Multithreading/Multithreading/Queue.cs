using System;

namespace Multithreading
{
    public class Queue<T>
    {
        private int _first;
        private int _last;
        private readonly T[] _array;

        internal Queue(int bufferSize)
        {
            _array = new T[bufferSize];
            _first = 0;
            _last = 0;
        }

        internal void Enqueue(T e)
        {
            if (Size() == BufferSize())
            {
                throw new InvalidOperationException("Buffer is full");
            }
            _last %= BufferSize();
            _array[_last++] = e;
        }

        internal T Dequeue()
        {
            if (Empty())
            {
                throw new InvalidOperationException("Buffer is empty");
            }
            var d = _array[_first++];
            if (_first < BufferSize())
            {
                return d;
            }
            _first %= BufferSize();
            _last %= BufferSize();
            return d;
        }

        internal void Clear()
        {
            _first = _last = 0;
        }

        internal bool Empty()
        {
            return _first == _last;
        }

        internal int Size()
        {
            return _first > _last ? BufferSize() - _first + _last : _last - _first;
        }

        internal int BufferSize()
        {
            return _array.Length;
        }

        public Queue<T> Clone()
        {
            var q = new Queue<T>(BufferSize());
            for (var i = _first; i != _last; i = i + 1 % BufferSize())
            {
                q.Enqueue(_array[i]);
            }
            return q;
        }
    }
}