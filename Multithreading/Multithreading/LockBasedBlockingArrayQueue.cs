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
            lock (_lock)
            {
                if (_queue.Size() != _queue.BufferSize())
                {
                    return (false, this);
                }
                _queue.Enqueue(e);
                Monitor.Pulse(_lock);
                return (true, this);
            }
        }

        public T Dequeue()
        {
            lock (_lock)
            {
                while (_queue.Empty())
                {
                    Monitor.Wait(_lock);
                }
                var d = _queue.Dequeue();
                Monitor.Pulse(_lock);
                return d;
            }
        }

        public (bool, T) TryDequeue()
        {
            lock (_lock)
            {
                var d = default(T);
                if (_queue.Empty())
                {
                    return (false, d);
                }
                d = _queue.Dequeue();
                Monitor.Pulse(_lock);
                return (true, d);
            }
        }

        public IBlockingArrayQueue<T> Clear()
        {
            lock (_lock)
            {
                _queue.Clear();
                Monitor.Pulse(_lock);
            }
            return this;
        }

        public int Size => _queue.Size();
    }
}