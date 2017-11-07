using System;
using System.Threading;

namespace Multithreading
{
    public class LockBasedBlockingArrayQueue<T> : IBlockingArrayQueue<T>
    {   
        private readonly Queue<T> _queue;
        private readonly object _lock;
        public const int BufferSize = 20;

        public LockBasedBlockingArrayQueue()
        {
            _queue = new Queue<T>(BufferSize);
            _lock = new object();
        }
        
        public IBlockingArrayQueue<T> Enqueue(T e)
        {
            lock (_lock)
            {
                while (_queue.Size() == _queue.BufferSize())
                {
                    Monitor.Wait(_lock);
                }
                _queue.Enqueue(e);
                Monitor.Pulse(_lock);
            }
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryEnqueue(T e)
        {
            if (!Monitor.TryEnter(_lock))
            {
                return (false, this);
            }
            var result = _queue.Size() != _queue.BufferSize();
            if (result)
            {
                _queue.Enqueue(e);
            }
            Monitor.Pulse(_lock);
            Monitor.Exit(_lock);
            return (result, this);
        }

        public T Dequeue()
        {
            var d = default(T);
            lock (_lock)
            {
                while (_queue.Empty())
                {
                    Monitor.Wait(_lock);
                }
                d = _queue.Dequeue();
                Monitor.Pulse(_lock);
            }
            return d;
        }

        public (bool, T) TryDequeue()
        {
            var result = false;
            var d = default(T);
            if (!Monitor.TryEnter(_lock))
            {
                return (result, d);
            }
            result = _queue.Empty();
            if (result)
            {
                d = _queue.Dequeue();
            }
            Monitor.Pulse(_lock);
            Monitor.Exit(_lock);
            return (result, d);
        }

        public IBlockingArrayQueue<T> Clear()
        {
            lock (_lock)
            {
                _queue.Clear();
            }
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryClear()
        {
            if (!Monitor.TryEnter(_lock))
            {
                return (false, this);
            }
            _queue.Clear();
            Monitor.Pulse(_lock);
            Monitor.Exit(_lock);
            return (false, this);
        }

        public int Size()
        {
            return _queue.Size();
        }
    }
}