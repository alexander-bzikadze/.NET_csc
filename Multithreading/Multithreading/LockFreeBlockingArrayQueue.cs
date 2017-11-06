using System;
using System.Threading;

namespace Multithreading
{
    public class LockFreeBlockingArrayQueue<T> : IBlockingArrayQueue<T>
    {
        private Queue<T> _queue;
        public const int BufferSize = 1000;

        public LockFreeBlockingArrayQueue()
        {
            _queue = new Queue<T>(BufferSize);
        }
        
        public IBlockingArrayQueue<T> Enqueue(T e)
        {
            while (!TryEnqueue(e).Item1)
            {
            }
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryEnqueue(T e)
        {
            var originalQueue = _queue;
            if (originalQueue.BufferSize() == originalQueue.Size())
            {
                return (false, this);
            }
            var modifiedQueue = originalQueue.Clone();
            modifiedQueue.Enqueue(e);
            Interlocked.CompareExchange(ref _queue, modifiedQueue, originalQueue);
            return (_queue == modifiedQueue, this);
        }

        public T Dequeue()
        {
            var (suc, value) = TryDequeue();
            while (!suc)
            {
                (suc, value) = TryDequeue();
            }
            return value;
        }

        public (bool, T) TryDequeue()
        {
            var originalQueue = _queue;
            if (originalQueue.Empty())
            {
                return (false, default(T));
            }
            var modifiedQueue = originalQueue.Clone();
            var d = modifiedQueue.Dequeue();
            Interlocked.CompareExchange(ref _queue, modifiedQueue, originalQueue);
            return (_queue == modifiedQueue, d);
        }

        public IBlockingArrayQueue<T> Clear()
        {
            var (suc, _) = TryClear();
            while (!suc)
            {
                (suc, _)= TryClear();
            }
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryClear()
        {
            var originalQueue = _queue;
            var modifiedQueue = new Queue<T>(_queue.BufferSize());
            Interlocked.CompareExchange(ref _queue, modifiedQueue, originalQueue);
            return (_queue == modifiedQueue, this);
        }

        public int Size()
        {
            return _queue.Size();
        }
    }
}